
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
namespace Helpers
{
	public class ImageHelpers
	{
		
		public static double PX2CM(double px, float resolution)
		{
			return px / resolution * 2.539999918;
		}
		public static double CM2PX(double cm, float resolution)
		{
			return cm / 2.539999918 * resolution;
		}
		public 	static void SaveJpeg(string path, Bitmap image)
		{
			SaveJpeg(path, image, 95L);
		}
		public 	static void SaveJpeg(string path, Bitmap image, long quality)
		{
			using (EncoderParameters encoderParameters = new EncoderParameters(1))
			using (EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality)) {
				ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
				encoderParameters.Param[0] = encoderParameter;
				image.Save(path, codecInfo, encoderParameters);
			}
		}
		public static void GenerateFixedWidthImage(string fileName, int width)
		{
			const float DPI = 254;
			
			var src = Image.FromFile(fileName);
			var length =	Math.Max(src.Width, src.Height);
			var targetHeight = 0f;
			
			var x = 0f;
			var y = 0f;
			var targetWidth = 0f;
			if (Math.Abs(src.HorizontalResolution - DPI) > 0) {
				var cw=PX2CM(src.Width, src.HorizontalResolution);
			
				targetWidth =	(float)CM2PX(cw, DPI);
				targetHeight=targetWidth/src.Width*src.Height;
				
				Console.WriteLine(fileName.GetFileName().Append().AppendString(src.HorizontalResolution+"分辨率")
				                  .AppendString(string.Format("{0}x{1}像素",src.Width,src.Height))
				                  .AppendString(string.Format("{0:0.00}x{1:0.00}厘米",cw,PX2CM(src.Height, src.VerticalResolution)))
				                  
				                  .ToString());
				
			} else {
				targetWidth = src.Width;
				targetHeight=src.Height;
				
			}
			
//			if (length < width) {
//				targetHeight = Math.Min(src.Width, src.Height);
//			} else {
//				targetHeight = length;
//			}
//			
			var bitmap = new Bitmap(width, (int)targetHeight, src.PixelFormat);
			
			bitmap.SetResolution(DPI, DPI);
			
			 
			using (var g = Graphics.FromImage(bitmap)) {
				g.Clear(Color.White);
				g.DrawImage(src, x, y, targetWidth, targetHeight);
			}
			var outFileName=fileName.ChangeFileName("_print");
			SaveJpeg(outFileName, bitmap);
			
			Console.WriteLine("生成文件".Append().AppendString(outFileName.GetFileName()).AppendString(width+"x"+targetHeight+"像素").ToString());
		}
	}
}
