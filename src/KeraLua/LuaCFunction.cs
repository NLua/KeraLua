using System.Runtime.InteropServices;

namespace KeraLua
{
	// typedef int (*lua_CFunction) (lua_State *L);
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I4)]
	public delegate int LuaCFunction(LuaState luaState);
}
