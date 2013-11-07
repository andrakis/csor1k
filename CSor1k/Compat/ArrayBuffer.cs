using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSor1k.Compat
{
	public interface IArrayBuffer
	{
	}

	public interface IArrayBufferView<T> : IArrayBuffer
	{
		T Read(uint offset);
		void Write(uint offset, T value);
	}

	public class ArrayBuffer
	{
		protected byte[] buffer;

		public ArrayBuffer(uint size)
		{
			buffer = new byte[size];
		}

		public abstract class ArrayBufferView<T> : IArrayBufferView<T>
		{
			protected ArrayBuffer source;
			protected int offset;

			public ArrayBufferView(ArrayBuffer source, int offset)
			{
				this.source = source;
				this.offset = offset;
			}

			public abstract T Read(uint location);
			public abstract void Write(uint location, T value);

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			protected static uint to_byte_offset(uint location, uint bits)
			{
				return location * (bits / 8);
			}
		}

		public sealed class IO_Uint8 : ArrayBufferView<byte>
		{
			public IO_Uint8(ArrayBuffer source, int offset)
				: base(source, offset)
			{
			}

			public override byte Read(uint location)
			{
				return this.source.buffer[this.offset + location];
			}

			public override void Write(uint location, byte value)
			{
				this.source.buffer[this.offset + location] = value;
			}
		}

		public sealed class IO_Sint32 : ArrayBufferView<Int32>
		{
			public IO_Sint32(ArrayBuffer source, int offset)
				: base(source, offset)
			{
			}

			public override Int32 Read(uint location)
			{
				return BitConverter.ToInt32(source.buffer, this.offset + (int)to_byte_offset(location, 32));
			}

			public override void Write(uint location, Int32 value)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				bytes.CopyTo(source.buffer, this.offset + (int)to_byte_offset(location, 32));
			}
		}
	}
}
