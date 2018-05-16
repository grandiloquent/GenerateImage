
using System;
using Helpers;

namespace GenerateImage
{
	class Program
	{
		public static void Main(string[] args)
		{
			foreach (var element in args) {
				if (element.IsJPGFile())
				{
					ImageHelpers.GenerateFixedWidthImage(element,(int)ImageHelpers.CM2PX(60.96,254));
				}
			}
		
			AppHelpers.HoldConsole();
			
		}
	}
}