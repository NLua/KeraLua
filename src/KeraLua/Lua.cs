using System;
using System.Runtime.InteropServices;

namespace KeraLua
{

public class Lua
{
#if MONOTOUCH || MONODROID
		const string LIBNAME = "__Internal";
#else
		const string LIBNAME = "liblua51";
#endif

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr luaL_newstate();

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_close(IntPtr luaState);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void luaL_openlibs(IntPtr luaState);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaL_loadstring(IntPtr luaState, string chunk);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

	public static int luaL_dostring(IntPtr luaState, string chunk)
	{
		int result = Lua.luaL_loadstring(luaState, chunk);
		if (result != 0)
			return result;

		return Lua.lua_pcall(luaState, 0, -1, 0);
	}
}

}

