/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2018/5/16
 * Time: 15:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace  Helpers
{
 
	public class AppHelpers
	{
		public static void HoldConsole()
		{
			Console.ForegroundColor=ConsoleColor.Yellow;
			Console.Write("按任意键退出. . . ");
			Console.ResetColor();
			Console.ReadKey(true);
		}
	}
}
