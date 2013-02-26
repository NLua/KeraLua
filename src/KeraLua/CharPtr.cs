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
				if (str == null || str == IntPtr.Zero)
					return "";

				return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (str);
			}

			public string ToString (uint lenght)
			{
				if (str == null || str == IntPtr.Zero)
					return "";

				return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (str, (int)lenght);
			}


			IntPtr str;
		}
	}
}
