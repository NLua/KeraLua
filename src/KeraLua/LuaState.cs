using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public struct LuaState
	{

		public LuaState (IntPtr ptrState)

			: this ()
		{
			state = ptrState;
		}

		static public implicit operator LuaState (IntPtr ptr)
		{
			return new LuaState (ptr);
		}


		static public implicit operator IntPtr (LuaState luastate)
		{
			return luastate.state;
		}

		IntPtr state;
	}
}
