using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public partial class Lua
	{
		public struct LuaState
		{
			public LuaState (IntPtr state)
				: this ()
			{
				this.state = state;
			}

			static public implicit operator LuaState (IntPtr ptr)
			{
				return new LuaState (ptr);
			}

			static public implicit operator IntPtr (LuaState state)
			{
				return state.state;
			}

			IntPtr state;
		}
	}
}
