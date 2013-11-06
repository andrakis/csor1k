using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSor1k.Compat
{
	public abstract class ArrayView<View, Type>
		where View : IArrayBuffer
		where Type : struct
	{
		protected View io;

		protected ArrayView(View source)
		{
			io = source;
		}

		public Type this[int location]
		{
			get { return this[(uint)location]; }
			set { this[(uint)location] = value; }
		}
		public abstract Type this[uint location] { get; set; }
	}

	public class Uint8Array : ArrayView<ArrayBuffer.IO_Uint8, byte>
	{
		public Uint8Array(ArrayBuffer source, int offset)
			: base(new ArrayBuffer.IO_Uint8(source, offset))
		{
		}

		public override byte this[uint location]
		{
			get { return io.Read(location); }
			set { io.Write(location, value); }
		}
	}

	public class Int32Array : ArrayView<ArrayBuffer.IO_Sint32, Int32>
	{
		public Int32Array(ArrayBuffer source, int offset)
			: base(new ArrayBuffer.IO_Sint32(source, offset))
		{
		}

		public override Int32 this[uint location]
		{
			get { return io.Read(location); }
			set { io.Write(location, value); }
		}
	}
}
