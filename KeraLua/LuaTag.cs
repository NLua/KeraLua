using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeraLua
{
	public struct LuaTag
	{
		public LuaTag (IntPtr tag)

			: this ()
		{
			this.Tag = tag;
		}

		static public implicit operator LuaTag (IntPtr ptr)
		{
			return new LuaTag (ptr);
		}
		public IntPtr Tag { get; set; }

	}
}
