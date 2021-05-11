using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeraLua
{
	public struct CharPtr
	{
		public CharPtr (IntPtr ptrString)
			: this ()
		{
			str = ptrString;
		}

		static public implicit operator CharPtr (IntPtr ptr)
		{
			return new CharPtr (ptr);
		}

		public static string StringFromNativeUtf8 (IntPtr nativeUtf8, int len = 0)
		{
			if (len == 0) {
				while (System.Runtime.InteropServices.Marshal.ReadByte (nativeUtf8, len) != 0)
					++len;
			}

			if (len == 0) 
				return string.Empty;

			byte [] buffer = new byte [len];
			System.Runtime.InteropServices.Marshal.Copy (nativeUtf8, buffer, 0, buffer.Length);

			return Encoding.UTF8.GetString (buffer, 0, len);
		}
		
		static private string PointerToString (IntPtr ptr)
		{
#if WSTRING
			return StringFromNativeUtf8 (ptr);
#else
			return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (ptr);
#endif
		}

		static private string PointerToString (IntPtr ptr, int length)
		{
#if WSTRING
			return StringFromNativeUtf8 (ptr, length);
#else
			return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (ptr, length);
#endif
		}

		static private byte [] PointerToBuffer (IntPtr ptr, int length)
		{
			byte [] buff = new byte [length];
			System.Runtime.InteropServices.Marshal.Copy (ptr, buff, 0, length);
			return buff;
		}

		public override string ToString ()
		{
			if (str == IntPtr.Zero)
				return "";

			return PointerToString (str);
		}

		// Changed 2013-05-18 by Dirk Weltz
		// Changed because binary chunks, which are also transfered as strings
		// get corrupted by conversion to strings because of the encoding.
		public string ToString (int length)
		{
			if (str == IntPtr.Zero)
				return "";

			byte [] buff = PointerToBuffer (str, length);
			// Are the first four bytes "ESC Lua". If yes, than it is a binary chunk.
			// Didn't check on version of Lua, because it isn't relevant.
			if (length > 3 && buff [0] == 0x1B && buff [1] == 0x4C && buff [2] == 0x75 && buff [3] == 0x61) {
				// It is a binary chunk
				StringBuilder s = new StringBuilder (length);
				foreach (byte b in buff)
					s.Append ((char)b);
				return s.ToString ();
			} else
#if WSTRING
#if WINDOWS_PHONE || NETFX_CORE
				return Encoding.UTF8.GetString (buff, 0, buff.Length);
#else
				return Encoding.UTF8.GetString (buff);
#endif
#else
				return PointerToString(str, length);
#endif
		}

		IntPtr str;
	}
}
