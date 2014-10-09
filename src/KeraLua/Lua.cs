using System;
using System.Runtime.InteropServices;


namespace KeraLua
{
	public delegate int LuaNativeFunction (KeraLua.LuaState luaState);

	public static partial class Lua
	{
		public static int LuaGC (IntPtr luaState, int what, int data)
		{
			return NativeMethods.LuaGC (luaState, what, data);
		}

		public static CharPtr LuaTypeName (IntPtr luaState, int type)
		{
			return NativeMethods.LuaTypeName (luaState, type);
		}

		public static void LuaLError (IntPtr luaState, string message)
		{
			NativeMethods.LuaLError (luaState, message);
		}

		public static void LuaLWhere (IntPtr luaState, int level)
		{
			NativeMethods.LuaLWhere (luaState, level);
		}

		public static IntPtr LuaLNewState ()
		{
			return NativeMethods.LuaLNewState ();
		}

		public static void LuaClose (IntPtr luaState)
		{
			NativeMethods.LuaClose (luaState);
		}

		public static void LuaLOpenLibs (IntPtr luaState)
		{
			NativeMethods.LuaLOpenLibs (luaState);
		}

		public static int LuaLLoadString (IntPtr luaState, string chunk)
		{
			return NativeMethods.LuaLLoadString (luaState, chunk);
		}

		public static int LuaLLoadString (IntPtr luaState, byte [] chunk)
		{
			return NativeMethods.LuaLLoadString (luaState, chunk);
		}

		public static void LuaCreateTable (IntPtr luaState, int narr, int nrec)
		{
			NativeMethods.LuaCreateTable (luaState, narr, nrec);
		}

		public static void LuaGetTable (IntPtr luaState, int index)
		{
			NativeMethods.LuaGetTable (luaState, index);
		}

		public static void LuaSetTop (IntPtr luaState, int newTop)
		{
			NativeMethods.LuaSetTop (luaState, newTop);
		}

		public static void LuaInsert (IntPtr luaState, int newTop)
		{
			NativeMethods.LuaInsert (luaState, newTop);
		}


		public static void LuaRemove (IntPtr luaState, int index)
		{
			NativeMethods.LuaRemove (luaState, index);
		}


		public static void LuaRawGet (IntPtr luaState, int index)
		{
			NativeMethods.LuaRawGet (luaState, index);
		}


		public static void LuaSetTable (IntPtr luaState, int index)
		{
			NativeMethods.LuaSetTable (luaState, index);
		}


		public static void LuaRawSet (IntPtr luaState, int index)
		{
			NativeMethods.LuaRawSet (luaState, index);
		}


		public static void LuaSetMetatable (IntPtr luaState, int objIndex)
		{
			NativeMethods.LuaSetMetatable (luaState, objIndex);
		}


		public static int LuaGetMetatable (IntPtr luaState, int objIndex)
		{
			return NativeMethods.LuaGetMetatable (luaState, objIndex);
		}


		public static int LuaNetEqual (IntPtr luaState, int index1, int index2)
		{
			return NativeMethods.LuaNetEqual (luaState, index1, index2);
		}


		public static void LuaPushValue (IntPtr luaState, int index)
		{
			NativeMethods.LuaPushValue (luaState, index);
		}


		public static void LuaReplace (IntPtr luaState, int index)
		{
			NativeMethods.LuaReplace (luaState, index);
		}


		public static int LuaGetTop (IntPtr luaState)
		{
			return NativeMethods.LuaGetTop (luaState);
		}


		public static int LuaType (IntPtr luaState, int index)
		{
			return NativeMethods.LuaType (luaState, index);
		}


		public static int LuaLRef (IntPtr luaState, int registryIndex)
		{
			return NativeMethods.LuaLRef (luaState, registryIndex);
		}

		public static void LuaRawGetI (IntPtr luaState, int tableIndex, int index)
		{
			NativeMethods.LuaRawGetI (luaState, tableIndex, index);
		}


		public static void LuaRawSetI (IntPtr luaState, int tableIndex, int index)
		{
			NativeMethods.LuaRawSetI (luaState, tableIndex, index);
		}

		[CLSCompliantAttribute (false)]
		public static IntPtr LuaNewUserData (IntPtr luaState, uint size)
		{
			return NativeMethods.LuaNewUserData (luaState, size);
		}
		
		public static IntPtr LuaToUserData (IntPtr luaState, int index)
		{
			return NativeMethods.LuaToUserData (luaState, index);
		}


		public static void LuaLUnref (IntPtr luaState, int registryIndex, int reference)
		{
			NativeMethods.LuaLUnref (luaState, registryIndex, reference);
		}


		public static int LuaIsString (IntPtr luaState, int index)
		{
			return NativeMethods.LuaIsString (luaState, index);
		}

		public static int LuaNetIsStringStrict (IntPtr luaState, int index)
		{
			return NativeMethods.LuaNetIsStringStrict (luaState, index);
		}


		public static bool LuaIsCFunction (IntPtr luaState, int index)
		{
			return NativeMethods.LuaIsCFunction (luaState, index) != 0;
		}


		public static void LuaPushNil (IntPtr luaState)
		{
			NativeMethods.LuaPushNil (luaState);
		}


		public static int LuaNetPCall (IntPtr luaState, int nArgs, int nResults, int errfunc)
		{
			return NativeMethods.LuaNetPCall (luaState, nArgs, nResults, errfunc);
		}

		public static LuaNativeFunction LuaToCFunction (IntPtr luaState, int index)
		{
			IntPtr ptr = NativeMethods.LuaToCFunction (luaState, index);
			if (ptr == IntPtr.Zero)
				return null;
			LuaNativeFunction function = Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaNativeFunction)) as LuaNativeFunction;
			return function;
		}


		public static double LuaNetToNumber (IntPtr luaState, int index)
		{
			return NativeMethods.LuaNetToNumber (luaState, index);
		}


		public static int LuaToBoolean (IntPtr luaState, int index)
		{
			return NativeMethods.LuaToBoolean (luaState, index);
		}

		[CLSCompliantAttribute (false)]
		public static CharPtr LuaToLString (IntPtr luaState, int index, out uint strLen)
		{
			return NativeMethods.LuaToLString (luaState, index, out strLen);
		}

		public static void LuaAtPanic (IntPtr luaState, LuaNativeFunction panicf)
		{
			IntPtr fnpanic = Marshal.GetFunctionPointerForDelegate (panicf);
			NativeMethods.LuaAtPanic (luaState, fnpanic);
		}

		public static void LuaPushStdCallCFunction (IntPtr luaState, LuaNativeFunction fn)
		{
			IntPtr pfunc = Marshal.GetFunctionPointerForDelegate (fn);
			NativeMethods.LuaPushStdCallCFunction (luaState, pfunc);
		}

		public static void LuaPushNumber (IntPtr luaState, double number)
		{
			NativeMethods.LuaPushNumber (luaState, number);
		}

		public static void LuaPushBoolean (IntPtr luaState, int value)
		{
			NativeMethods.LuaPushBoolean (luaState, value);
		}

		[CLSCompliantAttribute (false)]
		public static void LuaNetPushLString (IntPtr luaState, string str, uint size)
		{
			NativeMethods.LuaNetPushLString (luaState, str, size);
		}

		public static void LuaPushString (IntPtr luaState, string str)
		{
			NativeMethods.LuaPushString (luaState, str);
		}

		public static int LuaLNewMetatable (IntPtr luaState, string meta)
		{
			return NativeMethods.LuaLNewMetatable (luaState, meta);
		}

		public static void LuaGetField (IntPtr luaState, int stackPos, string meta)
		{
			NativeMethods.LuaGetField (luaState, stackPos, meta);
		}

		public static IntPtr LuaLCheckUData (IntPtr luaState, int stackPos, string meta)
		{
			return NativeMethods.LuaLCheckUData (luaState, stackPos, meta);
		}

		public static int LuaLGetMetafield (IntPtr luaState, int stackPos, string field)
		{
			return NativeMethods.LuaLGetMetafield (luaState, stackPos, field);
		}

		[CLSCompliantAttribute (false)]
		public static int LuaNetLoadBuffer (IntPtr luaState, string buff, uint size, string name)
		{
			return NativeMethods.LuaNetLoadBuffer (luaState, buff, size, name);

		}

		[CLSCompliantAttribute (false)]
		public static int LuaNetLoadBuffer (IntPtr luaState, byte [] buff, uint size, string name)
		{
			return NativeMethods.LuaNetLoadBuffer (luaState, buff, size, name);
		}

		public static int LuaNetLoadFile (IntPtr luaState, string filename)
		{
			return NativeMethods.LuaNetLoadFile (luaState, filename);
		}

		public static void LuaError (IntPtr luaState)
		{
			NativeMethods.LuaError (luaState);
		}

		public static int LuaCheckStack (IntPtr luaState, int extra)
		{
			return NativeMethods.LuaCheckStack (luaState, extra);
		}

		public static int LuaNext (IntPtr luaState, int index)
		{
			return NativeMethods.LuaNext (luaState, index);
		}

		public static void LuaPushLightUserData (IntPtr luaState, IntPtr udata)
		{
			NativeMethods.LuaPushLightUserData (luaState, udata);
		}

		public static bool LuaLCheckMetatable (IntPtr luaState, int obj)
		{
			return NativeMethods.LuaLCheckMetatable (luaState, obj) != 0;
		}

		public static int LuaGetHookMask (IntPtr luaState)
		{
			return NativeMethods.LuaGetHookMask (luaState);
		}

		public static int LuaSetHook (IntPtr luaState, LuaHook func, int mask, int count)
		{
			IntPtr funcHook = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (func);
			return NativeMethods.LuaSetHook (luaState, funcHook, mask, count);
		}

		public static int LuaGetHookCount (IntPtr luaState)
		{
			return NativeMethods.LuaGetHookCount (luaState);
		}

		public static CharPtr LuaGetLocal (IntPtr luaState, LuaDebug ar, int n)
		{

			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			CharPtr local = IntPtr.Zero;

			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				local = NativeMethods.LuaGetLocal (luaState, pDebug, n);

			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return local;
		}

		public static CharPtr LuaSetLocal (IntPtr luaState, LuaDebug ar, int n)
		{
			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			CharPtr local = IntPtr.Zero;

			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				local = NativeMethods.LuaSetLocal (luaState, pDebug, n);

			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return local;
		}

		public static int LuaGetInfo (IntPtr luaState, string what,ref LuaDebug ar)
		{
			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			int ret = 0;

			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				ret = NativeMethods.LuaGetInfo (luaState, what, pDebug);
				ar = (LuaDebug)Marshal.PtrToStructure (pDebug, typeof (LuaDebug));
			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return ret;
		}

		public static int LuaGetStack (IntPtr luaState, int level,ref LuaDebug ar)
		{
			IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
			int ret = 0;
			try {
				Marshal.StructureToPtr (ar, pDebug, false);
				ret = NativeMethods.LuaGetStack (luaState, level, pDebug);
				ar = (LuaDebug)Marshal.PtrToStructure (pDebug, typeof (LuaDebug));
			} finally {
				Marshal.FreeHGlobal (pDebug);
			}
			return ret;
		}

  
		public static CharPtr LuaGetUpValue (IntPtr luaState, int funcindex, int n)
		{
			return NativeMethods.LuaGetUpValue (luaState, funcindex, n);
		}

		public static CharPtr LuaSetUpValue (IntPtr luaState, int funcindex, int n)
		{
			return NativeMethods.LuaSetUpValue (luaState, funcindex, n);
		}

		public static int LuaNetToNetObject (IntPtr luaState, int index)
		{
			return NativeMethods.LuaNetToNetObject (luaState, index);
		}

		public static int LuaNetRegistryIndex ()
		{
			return NativeMethods.LuaNetRegistryIndex ();
		}

		public static void LuaNetNewUData (IntPtr luaState, int val)
		{
			NativeMethods.LuaNetNewUData (luaState, val);
		}

		public static int LuaNetRawNetObj (IntPtr luaState, int obj)
		{
			return NativeMethods.LuaNetRawNetObj (luaState, obj);
		}

		public static int LuaNetCheckUData (IntPtr luaState, int ud, string tname)
		{
			return NativeMethods.LuaNetCheckUData (luaState, ud, tname);
		}

		public static IntPtr LuaNetGetTag ()
		{
			return NativeMethods.LuaNetGetTag ();
		}

		public static void LuaNetPushGlobalTable (IntPtr luaState)
		{
			NativeMethods.LuaNetPushGlobalTable (luaState);
		}

		public static void LuaNetPopGlobalTable (IntPtr luaState)
		{
			NativeMethods.LuaNetPopGlobalTable (luaState);
		}

		public static void LuaNetSetGlobal (IntPtr luaState, string name)
		{
			NativeMethods.LuaNetSetGlobal (luaState, name);
		}

		public static void LuaNetGetGlobal (IntPtr luaState, string name)
		{
			NativeMethods.LuaNetGetGlobal (luaState, name);
		}

		public static IntPtr LuaNetGetMainState (IntPtr luaState)
		{
			return NativeMethods.LuaNetGetMainState (luaState);
		}
	}

}

