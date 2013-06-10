using System;
using System.Runtime.InteropServices;


namespace KeraLua
{
	public partial class Lua
	{
		public delegate int lua_CFunction (lua_State L);

		public static int lua_gc (IntPtr luaState, int what, int data)
		{
			return NativeMethods.lua_gc (luaState, what, data);
		}

		public static CharPtr lua_typename (IntPtr luaState, int type)
		{
			return NativeMethods.lua_typename (luaState, type);
		}


		public static void luaL_error (IntPtr luaState, string message)
		{
			NativeMethods.luaL_error (luaState, message);
		}

		public static void luaL_where (IntPtr luaState, int level)
		{
			NativeMethods.luaL_where (luaState, level);
		}

		public static IntPtr luaL_newstate ()
		{
			return NativeMethods.luaL_newstate ();
		}

		public static void lua_close (IntPtr luaState)
		{
			NativeMethods.lua_close (luaState);
		}

		public static void luaL_openlibs (IntPtr luaState)
		{
			NativeMethods.luaL_openlibs (luaState);
		}

		public static int luaL_loadstring (IntPtr luaState, string chunk)
		{
			return NativeMethods.luaL_loadstring (luaState, chunk);
		}

		public static int luaL_loadstring (IntPtr luaState, byte [] chunk)
		{
			return NativeMethods.luaL_loadstring (luaState, chunk);
		}

		public static void lua_createtable (IntPtr luaState, int narr, int nrec)
		{
			NativeMethods.lua_createtable (luaState, narr, nrec);
		}

		public static void lua_gettable (IntPtr luaState, int index)
		{
			NativeMethods.lua_gettable (luaState, index);
		}

		public static void lua_settop (IntPtr luaState, int newTop)
		{
			NativeMethods.lua_settop (luaState, newTop);
		}

		public static void lua_insert (IntPtr luaState, int newTop)
		{
			NativeMethods.lua_insert (luaState, newTop);
		}


		public static void lua_remove (IntPtr luaState, int index)
		{
			NativeMethods.lua_remove (luaState, index);
		}


		public static void lua_rawget (IntPtr luaState, int index)
		{
			NativeMethods.lua_rawget (luaState, index);
		}


		public static void lua_settable (IntPtr luaState, int index)
		{
			NativeMethods.lua_settable (luaState, index);
		}


		public static void lua_rawset (IntPtr luaState, int index)
		{
			NativeMethods.lua_rawset (luaState, index);
		}


		public static void lua_setmetatable (IntPtr luaState, int objIndex)
		{
			NativeMethods.lua_setmetatable (luaState, objIndex);
		}


		public static int lua_getmetatable (IntPtr luaState, int objIndex)
		{
			return NativeMethods.lua_getmetatable (luaState, objIndex);
		}


		public static int lua_equal (IntPtr luaState, int index1, int index2)
		{
			return NativeMethods.luanet_equal (luaState, index2, index2);
		}


		public static void lua_pushvalue (IntPtr luaState, int index)
		{
			NativeMethods.lua_pushvalue (luaState, index);
		}


		public static void lua_replace (IntPtr luaState, int index)
		{
			NativeMethods.lua_replace (luaState, index);
		}


		public static int lua_gettop (IntPtr luaState)
		{
			return NativeMethods.lua_gettop (luaState);
		}


		public static int lua_type (IntPtr luaState, int index)
		{
			return NativeMethods.lua_type (luaState, index);
		}


		public static int luaL_ref (IntPtr luaState, int registryIndex)
		{
			return NativeMethods.luaL_ref (luaState, registryIndex);
		}

		public static void lua_rawgeti (IntPtr luaState, int tableIndex, int index)
		{
			NativeMethods.lua_rawgeti (luaState, tableIndex, index);
		}


		public static void lua_rawseti (IntPtr luaState, int tableIndex, int index)
		{
			NativeMethods.lua_rawseti (luaState, tableIndex, index);
		}

		[CLSCompliantAttribute (false)]
		public static IntPtr lua_newuserdata (IntPtr luaState, uint size)
		{
			return NativeMethods.lua_newuserdata (luaState, size);
		}
		
		public static IntPtr lua_touserdata (IntPtr luaState, int index)
		{
			return NativeMethods.lua_touserdata (luaState, index);
		}


		public static void luaL_unref (IntPtr luaState, int registryIndex, int reference)
		{
			NativeMethods.luaL_unref (luaState, registryIndex, reference);
		}


		public static int lua_isstring (IntPtr luaState, int index)
		{
			return NativeMethods.lua_isstring (luaState, index);
		}


		public static bool lua_iscfunction (IntPtr luaState, int index)
		{
			return NativeMethods.lua_iscfunction_int (luaState, index) != 0;
		}


		public static void lua_pushnil (IntPtr luaState)
		{
			NativeMethods.lua_pushnil (luaState);
		}


		public static int lua_call (IntPtr luaState, int nArgs, int nResults)
		{
			return NativeMethods.lua_call (luaState, nArgs, nResults);
		}

		public static int luanet_pcall (IntPtr luaState, int nArgs, int nResults, int errfunc)
		{
			return NativeMethods.luanet_pcall (luaState, nArgs, nResults, errfunc);
		}

		public static lua_CFunction lua_tocfunction (IntPtr luaState, int index)
		{
			IntPtr ptr = NativeMethods.lua_tocfunction_ptr (luaState, index);
			if (ptr == IntPtr.Zero)
				return null;
			lua_CFunction function = Marshal.GetDelegateForFunctionPointer (ptr, typeof (lua_CFunction)) as lua_CFunction;
			return function;
		}


		public static double luanet_tonumber (IntPtr luaState, int index)
		{
			return NativeMethods.luanet_tonumber (luaState, index);
		}


		public static int lua_toboolean (IntPtr luaState, int index)
		{
			return NativeMethods.lua_toboolean (luaState, index);
		}

		[CLSCompliantAttribute (false)]
		public static CharPtr lua_tolstring (IntPtr luaState, int index, out uint strLen)
		{
			return NativeMethods.lua_tolstring_ptr (luaState, index, out strLen);
		}

		public static void lua_atpanic (IntPtr luaState, lua_CFunction panicf)
		{
			IntPtr fnpanic = Marshal.GetFunctionPointerForDelegate (panicf);
			NativeMethods.lua_atpanic (luaState, fnpanic);
		}

		public static void lua_pushcfunction (IntPtr luaState, lua_CFunction fn)
		{
			IntPtr pfunc = Marshal.GetFunctionPointerForDelegate (fn);
			NativeMethods.lua_pushstdcallcfunction (luaState, pfunc);
		}

		public static void lua_pushnumber (IntPtr luaState, double number)
		{
			NativeMethods.lua_pushnumber (luaState, number);
		}

		public static void lua_pushboolean (IntPtr luaState, int value)
		{
			NativeMethods.lua_pushboolean (luaState, value);
		}

		[CLSCompliantAttribute (false)]
		public static void lua_pushlstring (IntPtr luaState, string str, uint size)
		{
			NativeMethods.lua_pushlstring (luaState, str, size);
		}

		public static void lua_pushstring (IntPtr luaState, string str)
		{
			NativeMethods.lua_pushstring (luaState, str);
		}

		public static int luaL_newmetatable (IntPtr luaState, string meta)
		{
			return NativeMethods.luaL_newmetatable (luaState, meta);
		}

		public static void lua_getfield (IntPtr luaState, int stackPos, string meta)
		{
			NativeMethods.lua_getfield (luaState, stackPos, meta);
		}

		public static IntPtr luaL_checkudata (IntPtr luaState, int stackPos, string meta)
		{
			return NativeMethods.luaL_checkudata (luaState, stackPos, meta);
		}

		public static int luaL_getmetafield (IntPtr luaState, int stackPos, string field)
		{
			return NativeMethods.luaL_getmetafield (luaState, stackPos, field);
		}

		[CLSCompliantAttribute (false)]
		public static int luanet_loadbuffer (IntPtr luaState, string buff, uint size, string name)
		{
			return NativeMethods.luanet_loadbuffer (luaState, buff, size, name);

		}

		[CLSCompliantAttribute (false)]
		public static int luanet_loadbuffer (IntPtr luaState, byte [] buff, uint size, string name)
		{
			return NativeMethods.luanet_loadbuffer (luaState, buff, size, name);
		}

		public static int luanet_loadfile (IntPtr luaState, string filename)
		{
			return NativeMethods.luanet_loadfile (luaState, filename);
		}

		public static void lua_error (IntPtr luaState)
		{
			NativeMethods.lua_error (luaState);
		}

		public static int lua_checkstack (IntPtr luaState, int extra)
		{
			return NativeMethods.lua_checkstack (luaState, extra);
		}

		public static int lua_next (IntPtr luaState, int index)
		{
			return NativeMethods.lua_next (luaState, index);
		}

		public static void lua_pushlightuserdata (IntPtr luaState, IntPtr udata)
		{
			NativeMethods.lua_pushlightuserdata (luaState, udata);
		}

		public static bool luaL_checkmetatable (IntPtr luaState, int obj)
		{
			return NativeMethods.luaL_checkmetatable_int (luaState, obj) != 0;
		}

		public static int lua_gethookmask (IntPtr luaState)
		{
			return NativeMethods.lua_gethookmask (luaState);
		}

		public static int lua_sethook (IntPtr luaState, lua_Hook func, int mask, int count)
		{
			IntPtr funcHook = Marshal.GetFunctionPointerForDelegate (func);
			return NativeMethods.lua_sethook (luaState, funcHook, mask, count);
		}

		public static int lua_gethookcount (IntPtr luaState)
		{
			return NativeMethods.lua_gethookcount (luaState);
		}

		public static CharPtr lua_getlocal (IntPtr luaState, lua_Debug ar, int n)
		{

			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			CharPtr local = IntPtr.Zero;

			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				local = NativeMethods.lua_getlocal (luaState, pDebug, n);

			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return local;
		}

		public static CharPtr lua_setlocal (IntPtr luaState, lua_Debug ar, int n)
		{
			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			CharPtr local = IntPtr.Zero;

			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				local = NativeMethods.lua_setlocal (luaState, pDebug, n);

			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return local;
		}


		public static CharPtr lua_getupvalue (IntPtr luaState, int funcindex, int n)
		{
			return NativeMethods.lua_getupvalue (luaState, funcindex, n);
		}

		public static CharPtr lua_setupvalue (IntPtr luaState, int funcindex, int n)
		{
			return NativeMethods.lua_setupvalue (luaState, funcindex, n);
		}

		public static int luanet_tonetobject (IntPtr luaState, int index)
		{
			return NativeMethods.luanet_tonetobject (luaState, index);
		}

		public static int luanet_registryindex ()
		{
			return NativeMethods.luanet_registryindex ();
		}

		public static void luanet_newudata (IntPtr luaState, int val)
		{
			NativeMethods.luanet_newudata (luaState, val);
		}

		public static int luanet_rawnetobj (IntPtr luaState, int obj)
		{
			return NativeMethods.luanet_rawnetobj (luaState, obj);
		}

		public static int luanet_checkudata (IntPtr luaState, int ud, string tname)
		{
			return NativeMethods.luanet_checkudata (luaState, ud, tname);
		}

		public static IntPtr luanet_gettag ()
		{
			return NativeMethods.luanet_gettag ();
		}

		public static void luanet_pushglobaltable (IntPtr luaState)
		{
			NativeMethods.luanet_pushglobaltable (luaState);
		}

		public static void luanet_popglobaltable (IntPtr luaState)
		{
			NativeMethods.luanet_popglobaltable (luaState);
		}

		public static void luanet_setglobal (IntPtr luaState, string name)
		{
			NativeMethods.luanet_setglobal (luaState, name);
		}

		public static void luanet_getglobal (IntPtr luaState, string name)
		{
			NativeMethods.luanet_getglobal (luaState, name);
		}
	}

}

