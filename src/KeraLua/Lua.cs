using System;
using System.Runtime.InteropServices;

namespace KeraLua
{

public class Lua
{
	public delegate int lua_CFunction(IntPtr L);

#if MONOTOUCH || MONODROID
		const string LIBNAME = "__Internal";
#else
		const string LIBNAME = "liblua51";
#endif

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_gc(IntPtr luaState, int what, int data);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern string lua_typename(IntPtr luaState, int type);
			
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void luaL_error(IntPtr luaState, string message);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void luaL_where (IntPtr luaState, int level);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr luaL_newstate();
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_close(IntPtr luaState);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void luaL_openlibs(IntPtr luaState);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaL_loadstring(IntPtr luaState, string chunk);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_createtable(IntPtr luaState, int narr, int nrec);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_gettable(IntPtr luaState, int index);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_settop(IntPtr luaState, int newTop);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_insert(IntPtr luaState, int newTop);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_remove(IntPtr luaState, int index);
			
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_rawget(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_settable(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_rawset(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_setmetatable(IntPtr luaState, int objIndex);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_getmetatable(IntPtr luaState, int objIndex);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_equal(IntPtr luaState, int index1, int index2);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushvalue(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_replace(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_gettop(IntPtr luaState);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_type(IntPtr luaState, int index);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_ref(IntPtr luaState, int registryIndex);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_rawgeti(IntPtr luaState, int tableIndex, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_rawseti(IntPtr luaState, int tableIndex, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern IntPtr lua_newuserdata(IntPtr luaState, int size);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern IntPtr lua_touserdata(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void luaL_unref(IntPtr luaState, int registryIndex, int reference);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_isstring(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern bool lua_iscfunction(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushnil(IntPtr luaState);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_call(IntPtr luaState, int nArgs, int nResults);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_rawcall(IntPtr luaState, int nArgs, int nResults);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern IntPtr lua_tocfunction(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern double lua_tonumber(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern bool lua_toboolean(IntPtr luaState, int index);
	
	[DllImport(LIBNAME,CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr lua_tolstring(IntPtr luaState, int index, out int strLen);
	
	public static void lua_atpanic(IntPtr luaState,  lua_CFunction panicf)
	{
			IntPtr fnpanic = Marshal.GetFunctionPointerForDelegate (panicf);
			lua_atpanic (luaState, fnpanic);
	}

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_atpanic(IntPtr luaState, IntPtr panicf);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void  lua_pushcclosure (IntPtr luaState, IntPtr fn, int n);

	public static void  lua_pushcfunction (IntPtr luaState, lua_CFunction fn)
	{
			IntPtr pfunc = Marshal.GetFunctionPointerForDelegate (fn);
			lua_pushcclosure (luaState, pfunc, 0);
	}
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushnumber(IntPtr luaState, double number);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushboolean(IntPtr luaState, bool value);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushlstring(IntPtr luaState, string str, int size);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushstring(IntPtr luaState, string str);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_newmetatable(IntPtr luaState, string meta);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_getfield(IntPtr luaState, int stackPos, string meta);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr luaL_checkudata(IntPtr luaState, int stackPos, string meta);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern bool luaL_getmetafield(IntPtr luaState, int stackPos, string field);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_loadbuffer(IntPtr luaState, string buff, int size, string name);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_loadfile(IntPtr luaState, string filename);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_error(IntPtr luaState);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern bool lua_checkstack(IntPtr luaState,int extra);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_next(IntPtr luaState,int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushlightuserdata(IntPtr luaState, IntPtr udata);

	public static void lua_pushlightuserdata(IntPtr luaState, object udata)
	{
		// TODO: 
	}
}

}

