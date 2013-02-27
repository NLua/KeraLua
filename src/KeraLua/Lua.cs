using System;
using System.Runtime.InteropServices;

namespace KeraLua
{

public partial class Lua
{
	public delegate int lua_CFunction(lua_State L);

#if MONOTOUCH
		const string LIBNAME = "__Internal";
#else
		const string LIBNAME = "lua51";
#endif

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_gc(IntPtr luaState, int what, int data);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern CharPtr lua_typename(IntPtr luaState, int type);
			
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
	public static extern IntPtr lua_newuserdata(IntPtr luaState, uint size);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern IntPtr lua_touserdata(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void luaL_unref(IntPtr luaState, int registryIndex, int reference);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_isstring(IntPtr luaState, int index);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_iscfunction")]
	private static extern int lua_iscfunction_int(IntPtr luaState, int index);

	public static bool lua_iscfunction (IntPtr luaState, int index)
	{
		return lua_iscfunction_int (luaState, index) != 0;
	}

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushnil(IntPtr luaState);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_call(IntPtr luaState, int nArgs, int nResults);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl, EntryPoint = "lua_tocfunction")]
	private static extern IntPtr lua_tocfunction_ptr(IntPtr luaState, int index);

	public static lua_CFunction lua_tocfunction (IntPtr luaState, int index)
	{
		IntPtr ptr = lua_tocfunction_ptr (luaState, index);
		if (ptr == IntPtr.Zero)
			return null;
		lua_CFunction function = Marshal.GetDelegateForFunctionPointer (ptr, typeof (lua_CFunction)) as lua_CFunction;
		return function;
	}

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern double lua_tonumber(IntPtr luaState, int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_toboolean(IntPtr luaState, int index);
	
	[DllImport(LIBNAME,CallingConvention = CallingConvention.Cdecl)]
	public static extern CharPtr lua_tolstring(IntPtr luaState, int index, out uint strLen);
	
	public static void lua_atpanic(IntPtr luaState,  lua_CFunction panicf)
	{
			IntPtr fnpanic = Marshal.GetFunctionPointerForDelegate (panicf);
			lua_atpanic (luaState, fnpanic);
	}

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_atpanic(IntPtr luaState, IntPtr panicf);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	private static extern void  lua_pushcclosure (IntPtr luaState, IntPtr fn, int n);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_pushstdcallcfunction (IntPtr luaState, IntPtr function);

	public static void  lua_pushcfunction (IntPtr luaState, lua_CFunction fn)
	{
			IntPtr pfunc = Marshal.GetFunctionPointerForDelegate (fn);
			lua_pushstdcallcfunction (luaState, pfunc);
	}
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushnumber(IntPtr luaState, double number);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushboolean(IntPtr luaState, int value);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushlstring(IntPtr luaState, string str, uint size);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushstring(IntPtr luaState, string str);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_newmetatable(IntPtr luaState, string meta);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void lua_getfield(IntPtr luaState, int stackPos, string meta);
	
	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr luaL_checkudata(IntPtr luaState, int stackPos, string meta);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_getmetafield(IntPtr luaState, int stackPos, string field);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_loadbuffer(IntPtr luaState, string buff, uint size, string name);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int luaL_loadfile(IntPtr luaState, string filename);
	
	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_error(IntPtr luaState);

	[DllImport(LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_checkstack(IntPtr luaState,int extra);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern int lua_next(IntPtr luaState,int index);

	[DllImport(LIBNAME,CallingConvention=CallingConvention.Cdecl)]
	public static extern void lua_pushlightuserdata(IntPtr luaState, IntPtr udata);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_checkmetatable")]
	private static extern int luaL_checkmetatable_int (IntPtr luaState, int obj);

	public static bool luaL_checkmetatable (IntPtr luaState, int obj)
	{
		return luaL_checkmetatable_int (luaState, obj) != 0;
	}

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_gethookmask (IntPtr luaState);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	private static extern int lua_sethook (IntPtr luaState, IntPtr func, int mask, int count);

	public static int lua_sethook (IntPtr luaState, lua_Hook func, int mask, int count)
	{
		IntPtr funcHook = Marshal.GetFunctionPointerForDelegate (func);
		return lua_sethook (luaState, funcHook, mask, count);
	}

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int lua_gethookcount (IntPtr luaState);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern CharPtr lua_getlocal (IntPtr luaState, IntPtr ar, int n);

	public static CharPtr lua_getlocal (IntPtr luaState, lua_Debug ar, int n)
	{

		IntPtr pDebug = Marshal.AllocHGlobal(Marshal.SizeOf(ar));
		CharPtr local = IntPtr.Zero;
		
		try {
			Marshal.StructureToPtr (ar, pDebug, false);
			local = lua_getlocal (luaState, pDebug, n);
			
		} finally {
			Marshal.FreeHGlobal(pDebug);
		}
		return local;
	}

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	private static extern IntPtr lua_setlocal (IntPtr luaState, IntPtr ar, int n);

	public static CharPtr lua_setlocal (IntPtr luaState, lua_Debug ar, int n)
	{

		IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
		CharPtr local = IntPtr.Zero;

		try {
			Marshal.StructureToPtr (ar, pDebug, false);
			local = lua_setlocal (luaState, pDebug, n);

		} finally {
			Marshal.FreeHGlobal (pDebug);
		}
		return local;
	}

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern CharPtr lua_getupvalue (IntPtr luaState, int funcindex, int n);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern CharPtr lua_setupvalue (IntPtr luaState, int funcindex, int n);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luanet_tonetobject (IntPtr luaState, int index);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern void luanet_newudata (IntPtr luaState, int val);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luanet_rawnetobj (IntPtr luaState, int obj);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luanet_checkudata (IntPtr luaState, int ud, string tname);

	[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr luanet_gettag ();
}

}

