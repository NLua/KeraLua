using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeraLua
{
	public partial class Lua
	{
		public struct CharPtr
		{
			public CharPtr (IntPtr str)
				: this ()
			{
				this.str = str;
			}

			static public implicit operator CharPtr (IntPtr ptr)
			{
				return new CharPtr (ptr);
			}

			public override string ToString ()
			{
				if (str == IntPtr.Zero)
					return "";

				return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (str);
			}

			public string ToString (int lenght)
			{
				if (str == IntPtr.Zero)
					return "";

				return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (str, lenght);
			}


			IntPtr str;
		}
	}
}
