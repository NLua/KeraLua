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

			// Changed 2013-05-18 by Dirk Weltz
			// Changed because binary chunks, which are also transfered as strings
			// get corrupted by conversion to strings because of the encoding.
			public string ToString (int length)
			{
				if (str == IntPtr.Zero)
					return "";

				byte[] buff = new byte[length];
				System.Runtime.InteropServices.Marshal.Copy(str, buff, 0, length);

				// Are the first four bytes "ESC Lua". If yes, than it is a binary chunk.
				// Didn't check on version of Lua, because it isn't relevant.
				if (length > 3 && buff [0] == 0x1B && buff [1] == 0x4C && buff [2] == 0x75 && buff [3] == 0x61) {
					// It is a binary chunk
					StringBuilder s = new StringBuilder (length);
					foreach (byte b in buff)
						s.Append ((char)b);
					return s.ToString ();
				} else
					return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (str, length);
			}

			IntPtr str;
		}
	}
}
