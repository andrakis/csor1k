using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSor1k.Compat;

namespace Test
{
	class ArrayTest : Test
	{
		public ArrayTest()
		{
			/**
			 * The following code can be run in a (recent) web browser, and should perform the same.
			 * You'll need this code above the code below, though:
			 * 
			 * function assert(y) { if (!y) throw new Exception("assert failed"); }; var Int32 = { MaxValue: 2147483647, MinValue: -2147483648 };
			 */
			var buffer = new ArrayBuffer(20);
			var x32 = new Int32Array(buffer, 0);
			var y32 = new Int32Array(buffer, 4);

			// Modifying data before the view doesn't affect the other view
			x32[0] = 42;
			assert(y32[0] == 0);

			// Modifying data in the view does affect the other
			x32[1] = 64;
			assert(y32[0] == 64);

			// Use a Uint8Array to write a 32bit int
			x32[0] = 0;
			assert(x32[0] == 0);
			var z8 = new Uint8Array(buffer, 16);
			z8[0] = 255;
			z8[1] = 255;
			z8[2] = 255;
			z8[3] = 127;
			assert(x32[4] == Int32.MaxValue);
		}
	}
}
