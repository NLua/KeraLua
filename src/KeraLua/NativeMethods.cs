using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeraLua
{
	static class NativeMethods
	{

#if MONOTOUCH
		const string LIBNAME = "__Internal";
#else
#if DEBUGLUA
		const string LIBNAME = "lua52d";
#else
		const string LIBNAME = "lua52";
#endif
#endif

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_gc")]
		internal static extern int lua_gc (IntPtr luaState, int what, int data);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_typename")]
		internal static extern IntPtr lua_typename (IntPtr luaState, int type);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luaL_error")]
		internal static extern void luaL_error (IntPtr luaState, string message);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_where")]
		internal static extern void luaL_where (IntPtr luaState, int level);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_newstate")]
		internal static extern IntPtr luaL_newstate ();

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_close")]
		internal static extern void lua_close (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_openlibs")]
		internal static extern void luaL_openlibs (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luaL_loadstring")]
		internal static extern int luaL_loadstring (IntPtr luaState, string chunk);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_loadstring")]
		internal static extern int luaL_loadstring (IntPtr luaState, byte [] chunk);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_createtable")]
		internal static extern void lua_createtable (IntPtr luaState, int narr, int nrec);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_gettable")]
		internal static extern void lua_gettable (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_settop")]
		internal static extern void lua_settop (IntPtr luaState, int newTop);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_insert")]
		internal static extern void lua_insert (IntPtr luaState, int newTop);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_remove")]
		internal static extern void lua_remove (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_rawget")]
		internal static extern void lua_rawget (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_settable")]
		internal static extern void lua_settable (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_rawset")]
		internal static extern void lua_rawset (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_setmetatable")]
		internal static extern void lua_setmetatable (IntPtr luaState, int objIndex);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_getmetatable")]
		internal static extern int lua_getmetatable (IntPtr luaState, int objIndex);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_equal")]
		internal static extern int luanet_equal (IntPtr luaState, int index1, int index2);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushvalue")]
		internal static extern void lua_pushvalue (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_replace")]
		internal static extern void lua_replace (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_gettop")]
		internal static extern int lua_gettop (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_type")]
		internal static extern int lua_type (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_ref")]
		internal static extern int luaL_ref (IntPtr luaState, int registryIndex);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_rawgeti")]
		internal static extern void lua_rawgeti (IntPtr luaState, int tableIndex, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_rawseti")]
		internal static extern void lua_rawseti (IntPtr luaState, int tableIndex, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_newuserdata")]
		internal static extern IntPtr lua_newuserdata (IntPtr luaState, uint size);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_touserdata")]
		internal static extern IntPtr lua_touserdata (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_unref")]
		internal static extern void luaL_unref (IntPtr luaState, int registryIndex, int reference);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_isstring")]
		internal static extern int lua_isstring (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_iscfunction")]
		internal static extern int lua_iscfunction_int (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushnil")]
		internal static extern void lua_pushnil (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_call")]
		internal static extern int lua_call (IntPtr luaState, int nArgs, int nResults);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_pcall")]
		internal static extern int luanet_pcall (IntPtr luaState, int nArgs, int nResults, int errfunc);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_tocfunction")]
		internal static extern IntPtr lua_tocfunction_ptr (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_tonumber")]
		internal static extern double luanet_tonumber (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_toboolean")]
		internal static extern int lua_toboolean (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_tolstring")]
		internal static extern IntPtr lua_tolstring_ptr (IntPtr luaState, int index, out uint strLen);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_atpanic")]
		internal static extern void lua_atpanic (IntPtr luaState, IntPtr panicf);
		
		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushstdcallcfunction")]
		internal static extern void lua_pushstdcallcfunction (IntPtr luaState, IntPtr function);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushnumber")]
		internal static extern void lua_pushnumber (IntPtr luaState, double number);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushboolean")]
		internal static extern void lua_pushboolean (IntPtr luaState, int value);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_pushlstring")]
		internal static extern void luanet_pushlstring (IntPtr luaState, string str, uint size);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "lua_pushstring")]
		internal static extern void lua_pushstring (IntPtr luaState, string str);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luaL_newmetatable")]
		internal static extern int luaL_newmetatable (IntPtr luaState, string meta);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "lua_getfield")]
		internal static extern void lua_getfield (IntPtr luaState, int stackPos, string meta);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luaL_checkudata")]
		internal static extern IntPtr luaL_checkudata (IntPtr luaState, int stackPos, string meta);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luaL_getmetafield")]
		internal static extern int luaL_getmetafield (IntPtr luaState, int stackPos, string field);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_loadbuffer")]
		internal static extern int luanet_loadbuffer (IntPtr luaState, string buff, uint size, string name);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_loadbuffer")]
		internal static extern int luanet_loadbuffer (IntPtr luaState, byte [] buff, uint size, string name);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_loadfile")]
		internal static extern int luanet_loadfile (IntPtr luaState, string filename);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_error")]
		internal static extern void lua_error (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_checkstack")]
		internal static extern int lua_checkstack (IntPtr luaState, int extra);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_next")]
		internal static extern int lua_next (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_pushlightuserdata")]
		internal static extern void lua_pushlightuserdata (IntPtr luaState, IntPtr udata);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luaL_checkmetatable")]
		internal static extern int luaL_checkmetatable_int (IntPtr luaState, int obj);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_gethookmask")]
		internal static extern int lua_gethookmask (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_sethook")]
		internal static extern int lua_sethook (IntPtr luaState, IntPtr func, int mask, int count);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_gethookcount")]
		internal static extern int lua_gethookcount (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_getlocal")]
		internal static extern IntPtr lua_getlocal (IntPtr luaState, IntPtr ar, int n);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_setlocal")]
		internal static extern IntPtr lua_setlocal (IntPtr luaState, IntPtr ar, int n);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_getupvalue")]
		internal static extern IntPtr lua_getupvalue (IntPtr luaState, int funcindex, int n);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lua_setupvalue")]
		internal static extern IntPtr lua_setupvalue (IntPtr luaState, int funcindex, int n);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_tonetobject")]
		internal static extern int luanet_tonetobject (IntPtr luaState, int index);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_newudata")]
		internal static extern void luanet_newudata (IntPtr luaState, int val);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_rawnetobj")]
		internal static extern int luanet_rawnetobj (IntPtr luaState, int obj);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_checkudata")]
		internal static extern int luanet_checkudata (IntPtr luaState, int ud, string tname);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_gettag")]
		internal static extern IntPtr luanet_gettag ();

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_pushglobaltable")]
		internal static extern void luanet_pushglobaltable (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_popglobaltable")]
		internal static extern void luanet_popglobaltable (IntPtr luaState);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_getglobal")]
		internal static extern void luanet_getglobal (IntPtr luaState, string name);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "luanet_setglobal")]
		internal static extern void luanet_setglobal (IntPtr luaState, string name);

		[DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "luanet_registryindex")]
		internal static extern int luanet_registryindex ();
	}
}
