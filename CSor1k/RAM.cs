using CSor1k.Compat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSor1k
{
	public class RAM
	{
		public readonly ArrayBuffer mem;
		public readonly Int32Array int32mem;
		public readonly Uint8Array uint8mem;

		protected List<Device> devices = new List<Device>();

		public RAM(ArrayBuffer heap, int ramoffset)
		{
			this.mem = heap;
			this.int32mem = new Int32Array(this.mem, ramoffset);
			this.uint8mem = new Uint8Array(this.mem, ramoffset);
		}

		public void AddDevice(Device device, UInt32 devaddr, UInt32 devsize)
		{
			device.deviceaddr = devaddr;
			device.devicesize = devsize;
			this.devices.Add(device);
		}

		public Int32 ReadMemory32(Int32 addr)
		{
			if (addr >= 0)
			{
				return this.int32mem[addr >> 2];
			}

			UInt32 uaddr = (uint)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					return dev.ReadReg32(uaddr - dev.deviceaddr);
				}
			}

			throw new Exception();
		}
	}


}
