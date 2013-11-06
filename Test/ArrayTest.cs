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
			var buffer = new ArrayBuffer(12);
			var x = new Int32Array(buffer, 0);
			// Make another view of last 4 bytes of the buffer
			var y = new Int32Array(buffer, 4);
			x[1] = 7;
			Console.WriteLine("y[0] = {0}", y[0]);
			assert(y[0] == 7);
			assert(y[0] == x[1]);

			var z = new Uint8Array(buffer, 0);
			z[1] = 255;
			Console.WriteLine("x[0] = {0}", x[0]);
			assert(x[0] == (7 + (255 << 8)));
		}
	}
}
