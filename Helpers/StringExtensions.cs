

namespace Helpers
{
	
	
	using System;
	using System.Text;
	
	public static class StringExtensions
	{
		public static StringBuilder Append(this string s)
		{
			
			var sb = new StringBuilder();
			sb.Append(s);
			
			return sb;
		}
		
		public static StringBuilder AppendString(this StringBuilder s,string str){
			s.Append(" | ").Append(str);
			
			return s;
		}
	}
}
