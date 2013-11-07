using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSor1k
{
	public abstract class Device
	{
		public UInt32 deviceaddr;
		public UInt32 devicesize;

		public Device(UInt32 addr, UInt32 size)
		{
			deviceaddr = addr;
			devicesize = size;
		}

		public bool WithinAddress(UInt32 addr)
		{
			return addr >= deviceaddr && addr <= (deviceaddr + devicesize);
		}

		public virtual byte ReadReg8(UInt32 addr) { throw new NotImplementedException(); }
		public virtual void WriteReg8(UInt32 addr, byte value) { throw new NotImplementedException(); }

		public virtual Int16 ReadReg16(UInt32 addr) { throw new NotImplementedException(); }
		public virtual void WriteReg16(UInt32 addr, Int16 value) { throw new NotImplementedException(); }

		public virtual Int32 ReadReg32(UInt32 addr) { throw new NotImplementedException(); }
		public virtual void WriteReg32(UInt32 addr, Int32 value) { throw new NotImplementedException(); }
	}
}
