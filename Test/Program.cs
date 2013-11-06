using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	interface ITest
	{
		void Test();
	}

	internal class Test
	{
		class Exception : System.Exception
		{
			
		}

		protected static void assert(bool condition)
		{
			if (!condition)
				throw new Exception();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			new ArrayTest();

			Console.WriteLine("{0}Finished", System.Environment.NewLine);
			Console.ReadLine();
		}
	}
}
