using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public partial class Lua
	{
		public struct lua_State
		{
			public lua_State (IntPtr state)
				: this ()
			{
				this.state = state;
			}

			static public implicit operator lua_State (IntPtr ptr)
			{
				return new lua_State (ptr);
			}

			static public implicit operator IntPtr (lua_State state)
			{
				return state.state;
			}

			IntPtr state;
		}
	}
}
