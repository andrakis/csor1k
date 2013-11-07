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
			if (addr >= 0) {
				return this.int32mem[addr >> 2];
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					return dev.ReadReg32(uaddr - dev.deviceaddr);
				}
			}

			throw new Exception("Error in ReadMemory32: RAM region " + addr.ToString("X") + " is not accessible");
		}

		public void WriteMemory32(Int32 addr, Int32 x)
		{
			if (addr >= 0) {
				this.int32mem[addr >> 2] = x;
				return;
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					dev.WriteReg32(uaddr - dev.deviceaddr, x);
					return;
				}
			}

			throw new Exception("Error in WriteMemory32: RAM region " + addr.ToString("X") + " is not accessible");
		}

		public Int16 ReadMemory16(Int32 addr)
		{
			if (addr >= 0) {
				return (Int16)(this.uint8mem[(addr ^ 2) + 1] << 8 | this.uint8mem[(addr ^ 2)]);
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					return dev.ReadReg16(uaddr - dev.deviceaddr);
				}
			}

			throw new Exception("Error in ReadMemory16: RAM region " + addr.ToString("X") + " is not accessible");
		}

		public void WriteMemory16(Int32 addr, Int16 x)
		{
			if (addr >= 0) {
				this.uint8mem[(addr ^ 2) + 1] = (byte)((x >> 8) & 0xFF);
				this.uint8mem[(addr ^ 2)] = (byte)(x & 0xFF);
				return;
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					dev.WriteReg16(uaddr - dev.deviceaddr, x);
					return;
				}
			}

			throw new Exception("Error in WriteMemory16: RAM region " + addr.ToString("X") + " is not accessible");
		}

		public byte ReadMemory8(Int32 addr)
		{
			if (addr >= 0) {
				return this.uint8mem[addr ^ 3];
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					return dev.ReadReg8(uaddr - dev.deviceaddr);
				}
			}

			throw new Exception("Error in ReadMemory8: RAM region " + addr.ToString("X") + " is not accessible");
		}

		public void WriteMemory8(Int32 addr, byte x)
		{
			if (addr >= 0) {
				this.uint8mem[addr ^ 3] = x;
				return;
			}

			UInt32 uaddr = (UInt32)addr;
			foreach (Device dev in this.devices) {
				if (dev.WithinAddress(uaddr)) {
					dev.WriteReg8(uaddr - dev.deviceaddr, x);
					return;
				}
			}

			throw new Exception("Error in WriteMemory8: RAM region " + addr.ToString("X") + " is not accessible");
		}
	}


}
