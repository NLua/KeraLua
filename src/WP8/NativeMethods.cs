using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeraLua
{
    class NativeMethods
   	{
        internal static  int LuaGC (IntPtr luaState, int what, int data)
        {
            return LuaCX.Interop.LuaGC (luaState, what, data);
        }
        
        internal static IntPtr LuaTypeName (IntPtr luaState, int type)
        {
            return LuaCX.Interop.LuaTypeName (luaState, type);
        }

        internal static void LuaLError(IntPtr luaState, string message)
        {
            LuaCX.Interop.LuaLError(luaState, message);
        }

        internal static void LuaLWhere(IntPtr luaState, int level)
        {
            LuaCX.Interop.LuaLWhere(luaState, level);
        }

        internal static IntPtr LuaLNewState()
        {
            return LuaCX.Interop.LuaLNewState();
        }

        internal static void LuaClose(IntPtr luaState)
        {
            LuaCX.Interop.LuaClose(luaState);
        }

        internal static void LuaLOpenLibs(IntPtr luaState)
        {
            LuaCX.Interop.LuaLOpenLibs(luaState);
        }

        internal static int LuaLLoadString(IntPtr luaState, string chunk)
        {
            return LuaCX.Interop.LuaLLoadString(luaState, chunk);
        }

        internal static int LuaLLoadString(IntPtr luaState, byte [] chunk)
        {
            return LuaCX.Interop.LuaLLoadStringArray (luaState, chunk);
        }

        internal static void LuaCreateTable(IntPtr luaState, int narr, int nrec)
        {
            LuaCX.Interop.LuaCreateTable(luaState, narr, nrec);
        }

        internal static void LuaGetTable(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaGetTable(luaState, index);
        }
        
        internal static void LuaSetTop(IntPtr luaState, int newTop)
        {
            LuaCX.Interop.LuaSetTop(luaState, newTop);
        }

        internal static void LuaInsert(IntPtr luaState, int newTop)
        {
            LuaCX.Interop.LuaInsert(luaState, newTop);
        }
        
        internal static void LuaRemove(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaRemove(luaState, index);
        }

        internal static void LuaRawGet(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaRawGet(luaState, index);
        }

        internal static void LuaSetTable(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaSetTable(luaState, index);
        }

        internal static void LuaRawSet(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaRawSet(luaState, index);
        }


        internal static void LuaSetMetatable(IntPtr luaState, int objIndex)
        {
            LuaCX.Interop.LuaSetMetatable(luaState, objIndex);
        }


        internal static int LuaGetMetatable(IntPtr luaState, int objIndex)
        {
            return LuaCX.Interop.LuaGetMetatable(luaState, objIndex);
        }


        internal static int LuaNetEqual(IntPtr luaState, int index1, int index2)
        {
            return LuaCX.Interop.LuaNetEqual(luaState, index1, index2);
        }


        internal static void LuaPushValue(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaPushValue(luaState, index);
        }


        internal static void LuaReplace(IntPtr luaState, int index)
        {
            LuaCX.Interop.LuaReplace(luaState, index);
        }


        internal static int LuaGetTop(IntPtr luaState)
        {
            return LuaCX.Interop.LuaGetTop(luaState);
        }


        internal static int LuaType(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaType(luaState, index);
        }


        internal static int LuaLRef(IntPtr luaState, int registryIndex)
        {
            return LuaCX.Interop.LuaLRef(luaState, registryIndex);
        }


        internal static void LuaRawGetI(IntPtr luaState, int tableIndex, int index)
        {
            LuaCX.Interop.LuaRawGetI(luaState, tableIndex, index);
        }


        internal static void LuaRawSetI(IntPtr luaState, int tableIndex, int index)
        {
            LuaCX.Interop.LuaRawSetI(luaState, tableIndex, index);
        }


        internal static IntPtr LuaNewUserData(IntPtr luaState, uint size)
        {
            return LuaCX.Interop.LuaNewUserData(luaState, size);
        }


        internal static IntPtr LuaToUserData(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaToUserData(luaState, index);
        }


        internal static void LuaLUnref(IntPtr luaState, int registryIndex, int reference)
        {
            LuaCX.Interop.LuaLUnref(luaState, registryIndex, reference);
        }


        internal static int LuaIsString(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaIsString(luaState, index);
        }


        internal static int LuaIsCFunction(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaIsCFunction(luaState, index);
        }


        internal static void LuaPushNil(IntPtr luaState)
        {
            LuaCX.Interop.LuaPushNil(luaState);
        }


        internal static int LuaCall(IntPtr luaState, int nArgs, int nResults)
        {
            return LuaCX.Interop.LuaCall(luaState, nArgs, nResults);
        }


        internal static int LuaNetPCall(IntPtr luaState, int nArgs, int nResults, int errfunc)
        {
            return LuaCX.Interop.LuaNetPCall(luaState, nArgs, nResults, errfunc);
        }


        internal static IntPtr LuaToCFunction(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaToCFunction(luaState, index);
        }


        internal static double LuaNetToNumber(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaNetToNumber(luaState, index);
        }

        internal static int LuaToBoolean(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaToBoolean(luaState, index);
        }

        internal static IntPtr LuaToLString(IntPtr luaState, int index, out uint strLen)
        {
            return LuaCX.Interop.LuaToLString(luaState, index, out strLen);
        }
        
        internal static void LuaAtPanic(IntPtr luaState, IntPtr panicf)
        {
            LuaCX.Interop.LuaAtPanic(luaState, panicf);
        }
        
        internal static void LuaPushStdCallCFunction(IntPtr luaState, IntPtr function)
        {
            LuaCX.Interop.LuaPushStdCallCFunction(luaState, function);
        }
        
        internal static void LuaPushNumber(IntPtr luaState, double number)
        {
            LuaCX.Interop.LuaPushNumber(luaState, number);
        }
        
        internal static void LuaPushBoolean(IntPtr luaState, int value)
        {
            LuaCX.Interop.LuaPushBoolean(luaState, value);
        }
        
        internal static void LuaNetPushLString(IntPtr luaState, string str, uint size)
        {
            LuaCX.Interop.LuaNetPushLString(luaState, str, size);
        }
        
        internal static void LuaPushString(IntPtr luaState, string str)
        {
            LuaCX.Interop.LuaPushString(luaState, str);
        }
        
        internal static int LuaLNewMetatable(IntPtr luaState, string meta)
        {
            return LuaCX.Interop.LuaLNewMetatable(luaState, meta);
        }

        internal static void LuaGetField(IntPtr luaState, int stackPos, string meta)
        {
            LuaCX.Interop.LuaGetField(luaState, stackPos, meta);
        }

        internal static IntPtr LuaLCheckUData(IntPtr luaState, int stackPos, string meta)
        {
            return LuaCX.Interop.LuaLCheckUData(luaState, stackPos, meta);
        }

        internal static int LuaLGetMetafield(IntPtr luaState, int stackPos, string field)
        {
            return LuaCX.Interop.LuaLGetMetafield(luaState, stackPos, field);
        }

        internal static int LuaNetLoadBuffer(IntPtr luaState, string buff, uint size, string name)
        {
            return LuaCX.Interop.LuaNetLoadBuffer(luaState, buff, size, name);
        }

        internal static int LuaNetLoadBuffer(IntPtr luaState, byte [] buff, uint size, string name)
        {
            return LuaCX.Interop.LuaNetLoadBufferArray(luaState, buff, size, name);
        }

        internal static int LuaNetLoadFile(IntPtr luaState, string filename)
        {
            return LuaCX.Interop.LuaNetLoadFile(luaState, filename);
        }

        internal static void LuaError(IntPtr luaState)
        {
            LuaCX.Interop.LuaError(luaState);
        }

        internal static int LuaCheckStack(IntPtr luaState, int extra)
        {
            return LuaCX.Interop.LuaCheckStack(luaState, extra);
        }
		
		internal static  int LuaNext (IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaNext(luaState, index);
        }

        internal static void LuaPushLightUserData(IntPtr luaState, IntPtr udata)
        {
            LuaCX.Interop.LuaPushLightUserData(luaState, udata);
        }

        internal static int LuaLCheckMetatable(IntPtr luaState, int obj)
        {
            return LuaCX.Interop.LuaLCheckMetatable(luaState, obj);
        }

        internal static int LuaGetHookMask(IntPtr luaState)
        {
            return LuaCX.Interop.LuaGetHookMask(luaState);
        }

        internal static int LuaSetHook(IntPtr luaState, IntPtr func, int mask, int count)
        {
            return LuaCX.Interop.LuaSetHook(luaState, func, mask, count);
        }

        internal static int LuaGetHookCount(IntPtr luaState)
        {
            return LuaCX.Interop.LuaGetHookCount(luaState);
        }

        internal static IntPtr LuaGetLocal(IntPtr luaState, IntPtr ar, int n)
        {
            return LuaCX.Interop.LuaGetLocal(luaState, ar, n);
        }

        internal static IntPtr LuaSetLocal(IntPtr luaState, IntPtr ar, int n)
        {
            return LuaCX.Interop.LuaSetLocal(luaState, ar, n);
        }

        internal static IntPtr LuaGetUpValue(IntPtr luaState, int funcindex, int n)
        {
            return LuaCX.Interop.LuaGetUpValue(luaState, funcindex, n);
        }

        internal static IntPtr LuaSetUpValue(IntPtr luaState, int funcindex, int n)
        {
            return LuaCX.Interop.LuaSetUpValue(luaState, funcindex, n);
        }

        internal static int LuaNetToNetObject(IntPtr luaState, int index)
        {
            return LuaCX.Interop.LuaNetToNetObject(luaState, index);
        }

        internal static void LuaNetNewUData(IntPtr luaState, int val)
        {
            LuaCX.Interop.LuaNetNewUData(luaState, val);
        }

        internal static int LuaNetRawNetObj(IntPtr luaState, int obj)
        {
            return LuaCX.Interop.LuaNetRawNetObj(luaState, obj);
        }

        internal static int LuaNetCheckUData(IntPtr luaState, int ud, string tname)
        {
            return LuaCX.Interop.LuaNetCheckUData(luaState, ud, tname);
        }

        internal static IntPtr LuaNetGetTag()
        {
            return LuaCX.Interop.LuaNetGetTag();
        }

        internal static void LuaNetPushGlobalTable(IntPtr luaState)
        {
            LuaCX.Interop.LuaNetPushGlobalTable(luaState);
        }

        internal static void LuaNetPopGlobalTable(IntPtr luaState)
        {
            LuaCX.Interop.LuaNetPopGlobalTable(luaState);
        }

        internal static void LuaNetGetGlobal(IntPtr luaState, string name)
        {
            LuaCX.Interop.LuaNetGetGlobal(luaState, name);
        }

        internal static void LuaNetSetGlobal(IntPtr luaState, string name)
        {
            LuaCX.Interop.LuaNetSetGlobal(luaState, name);
        }

        internal static int LuaNetRegistryIndex()
        {
            return LuaCX.Interop.LuaNetRegistryIndex();
        }
	}
}
