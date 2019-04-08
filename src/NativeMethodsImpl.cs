using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace KeraLua
{
    public class NativeMethodsImpl : INativeMethods
    {
        public System.Int32 luaL_loadbufferx(System.IntPtr luaState, System.Byte[] buff, System.UIntPtr sz, System.String name, System.String mode)
        {
            return NativeMethods.luaL_loadbufferx(luaState, buff, sz, name, mode);
        }

        public System.Int32 luaL_loadfilex(System.IntPtr luaState, System.String name, System.String mode)
        {
            return NativeMethods.luaL_loadfilex(luaState, name, mode);
        }

        public System.Int32 luaL_newmetatable(System.IntPtr luaState, System.String name)
        {
            return NativeMethods.luaL_newmetatable(luaState, name);
        }

        public System.IntPtr luaL_newstate()
        {
            return NativeMethods.luaL_newstate();
        }

        public void luaL_openlibs(System.IntPtr luaState)
        {
            NativeMethods.luaL_openlibs(luaState);
        }

        public System.Int64 luaL_optinteger(System.IntPtr luaState, System.Int32 arg, System.Int64 d)
        {
            return NativeMethods.luaL_optinteger(luaState, arg, d);
        }

        public System.Double luaL_optnumber(System.IntPtr luaState, System.Int32 arg, System.Double d)
        {
            return NativeMethods.luaL_optnumber(luaState, arg, d);
        }

        public System.Int32 luaL_ref(System.IntPtr luaState, System.Int32 registryIndex)
        {
            return NativeMethods.luaL_ref(luaState, registryIndex);
        }

        public void luaL_requiref(System.IntPtr luaState, System.String moduleName, System.IntPtr openFunction, System.Int32 global)
        {
            NativeMethods.luaL_requiref(luaState, moduleName, openFunction, global);
        }

        public void luaL_setfuncs(System.IntPtr luaState, KeraLua.LuaRegister[] luaReg, System.Int32 numUp)
        {
            NativeMethods.luaL_setfuncs(luaState, luaReg, numUp);
        }

        public void luaL_setmetatable(System.IntPtr luaState, System.String tName)
        {
            NativeMethods.luaL_setmetatable(luaState, tName);
        }

        public System.IntPtr luaL_testudata(System.IntPtr luaState, System.Int32 arg, System.String tName)
        {
            return NativeMethods.luaL_testudata(luaState, arg, tName);
        }

        public System.IntPtr luaL_tolstring(System.IntPtr luaState, System.Int32 index, out System.UIntPtr len)
        {
            return NativeMethods.luaL_tolstring(luaState, index, out len);
        }

        public System.IntPtr luaL_traceback(System.IntPtr luaState, System.IntPtr luaState2, System.String message, System.Int32 level)
        {
            return NativeMethods.luaL_traceback(luaState, luaState2, message, level);
        }

        public System.String luaL_typename(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.luaL_typename(luaState, index);
        }

        public void luaL_unref(System.IntPtr luaState, System.Int32 registryIndex, System.Int32 reference)
        {
            NativeMethods.luaL_unref(luaState, registryIndex, reference);
        }

        public void luaL_where(System.IntPtr luaState, System.Int32 level)
        {
            NativeMethods.luaL_where(luaState, level);
        }

        public void lua_upvaluejoin(System.IntPtr luaState, System.Int32 funcIndex1, System.Int32 n1, System.Int32 funcIndex2, System.Int32 n2)
        {
            NativeMethods.lua_upvaluejoin(luaState, funcIndex1, n1, funcIndex2, n2);
        }

        public System.IntPtr lua_version(System.IntPtr luaState)
        {
            return NativeMethods.lua_version(luaState);
        }

        public void lua_xmove(System.IntPtr from, System.IntPtr to, System.Int32 n)
        {
            NativeMethods.lua_xmove(from, to, n);
        }

        public System.Int32 lua_yieldk(System.IntPtr luaState, System.Int32 nresults, System.IntPtr ctx, System.IntPtr k)
        {
            return NativeMethods.lua_yieldk(luaState, nresults, ctx, k);
        }

        public System.Int32 luaL_argerror(System.IntPtr luaState, System.Int32 arg, System.String message)
        {
            return NativeMethods.luaL_argerror(luaState, arg, message);
        }

        public System.Int32 luaL_callmeta(System.IntPtr luaState, System.Int32 obj, System.String e)
        {
            return NativeMethods.luaL_callmeta(luaState, obj, e);
        }

        public void luaL_checkany(System.IntPtr luaState, System.Int32 arg)
        {
            NativeMethods.luaL_checkany(luaState, arg);
        }

        public System.Int64 luaL_checkinteger(System.IntPtr luaState, System.Int32 arg)
        {
            return NativeMethods.luaL_checkinteger(luaState, arg);
        }

        public System.IntPtr luaL_checklstring(System.IntPtr luaState, System.Int32 arg, out System.UIntPtr len)
        {
            return NativeMethods.luaL_checklstring(luaState, arg, out len);
        }

        public System.Double luaL_checknumber(System.IntPtr luaState, System.Int32 arg)
        {
            return NativeMethods.luaL_checknumber(luaState, arg);
        }

        public System.Int32 luaL_checkoption(System.IntPtr luaState, System.Int32 arg, System.String def, System.String[] list)
        {
            return NativeMethods.luaL_checkoption(luaState, arg, def, list);
        }

        public void luaL_checkstack(System.IntPtr luaState, System.Int32 sz, System.String message)
        {
            NativeMethods.luaL_checkstack(luaState, sz, message);
        }

        public void luaL_checktype(System.IntPtr luaState, System.Int32 arg, System.Int32 type)
        {
            NativeMethods.luaL_checktype(luaState, arg, type);
        }

        public System.IntPtr luaL_checkudata(System.IntPtr luaState, System.Int32 arg, System.String tName)
        {
            return NativeMethods.luaL_checkudata(luaState, arg, tName);
        }

        public void luaL_checkversion_(System.IntPtr luaState, System.Double ver, System.UIntPtr sz)
        {
            NativeMethods.luaL_checkversion_(luaState, ver, sz);
        }

        public System.Int32 luaL_error(System.IntPtr luaState, System.String message)
        {
            return NativeMethods.luaL_error(luaState, message);
        }

        public System.Int32 luaL_execresult(System.IntPtr luaState, System.Int32 stat)
        {
            return NativeMethods.luaL_execresult(luaState, stat);
        }

        public System.Int32 luaL_fileresult(System.IntPtr luaState, System.Int32 stat, System.String fileName)
        {
            return NativeMethods.luaL_fileresult(luaState, stat, fileName);
        }

        public System.Int32 luaL_getmetafield(System.IntPtr luaState, System.Int32 obj, System.String e)
        {
            return NativeMethods.luaL_getmetafield(luaState, obj, e);
        }

        public System.Int32 luaL_getsubtable(System.IntPtr luaState, System.Int32 index, System.String name)
        {
            return NativeMethods.luaL_getsubtable(luaState, index, name);
        }

        public System.Int64 luaL_len(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.luaL_len(luaState, index);
        }

        public void lua_sethook(System.IntPtr luaState, System.IntPtr f, System.Int32 mask, System.Int32 count)
        {
            NativeMethods.lua_sethook(luaState, f, mask, count);
        }

        public void lua_seti(System.IntPtr luaState, System.Int32 index, System.Int64 n)
        {
            NativeMethods.lua_seti(luaState, index, n);
        }

        public System.String lua_setlocal(System.IntPtr luaState, System.IntPtr ar, System.Int32 n)
        {
            return NativeMethods.lua_setlocal(luaState, ar, n);
        }

        public void lua_setmetatable(System.IntPtr luaState, System.Int32 objIndex)
        {
            NativeMethods.lua_setmetatable(luaState, objIndex);
        }

        public void lua_settable(System.IntPtr luaState, System.Int32 index)
        {
            NativeMethods.lua_settable(luaState, index);
        }

        public void lua_settop(System.IntPtr luaState, System.Int32 newTop)
        {
            NativeMethods.lua_settop(luaState, newTop);
        }

        public System.String lua_setupvalue(System.IntPtr luaState, System.Int32 funcIndex, System.Int32 n)
        {
            return NativeMethods.lua_setupvalue(luaState, funcIndex, n);
        }

        public void lua_setuservalue(System.IntPtr luaState, System.Int32 index)
        {
            NativeMethods.lua_setuservalue(luaState, index);
        }

        public System.Int32 lua_status(System.IntPtr luaState)
        {
            return NativeMethods.lua_status(luaState);
        }

        public System.UIntPtr lua_stringtonumber(System.IntPtr luaState, System.String s)
        {
            return NativeMethods.lua_stringtonumber(luaState, s);
        }

        public System.Int32 lua_toboolean(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_toboolean(luaState, index);
        }

        public System.IntPtr lua_tocfunction(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_tocfunction(luaState, index);
        }

        public System.Int64 lua_tointegerx(System.IntPtr luaState, System.Int32 index, out System.Int32 isNum)
        {
            return NativeMethods.lua_tointegerx(luaState, index, out isNum);
        }

        public System.IntPtr lua_tolstring(System.IntPtr luaState, System.Int32 index, out System.UIntPtr strLen)
        {
            return NativeMethods.lua_tolstring(luaState, index, out strLen);
        }

        public System.Double lua_tonumberx(System.IntPtr luaState, System.Int32 index, out System.Int32 isNum)
        {
            return NativeMethods.lua_tonumberx(luaState, index, out isNum);
        }

        public System.IntPtr lua_topointer(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_topointer(luaState, index);
        }

        public System.IntPtr lua_tothread(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_tothread(luaState, index);
        }

        public System.IntPtr lua_touserdata(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_touserdata(luaState, index);
        }

        public System.Int32 lua_type(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_type(luaState, index);
        }

        public System.String lua_typename(System.IntPtr luaState, System.Int32 type)
        {
            return NativeMethods.lua_typename(luaState, type);
        }

        public System.IntPtr lua_upvalueid(System.IntPtr luaState, System.Int32 funcIndex, System.Int32 n)
        {
            return NativeMethods.lua_upvalueid(luaState, funcIndex, n);
        }

        public void lua_pushcclosure(System.IntPtr luaState, System.IntPtr f, System.Int32 n)
        {
            NativeMethods.lua_pushcclosure(luaState, f, n);
        }

        public void lua_pushinteger(System.IntPtr luaState, System.Int64 n)
        {
            NativeMethods.lua_pushinteger(luaState, n);
        }

        public void lua_pushlightuserdata(System.IntPtr luaState, System.IntPtr udata)
        {
            NativeMethods.lua_pushlightuserdata(luaState, udata);
        }

        public System.IntPtr lua_pushlstring(System.IntPtr luaState, System.Byte[] s, System.UIntPtr len)
        {
            return NativeMethods.lua_pushlstring(luaState, s, len);
        }

        public void lua_pushnil(System.IntPtr luaState)
        {
            NativeMethods.lua_pushnil(luaState);
        }

        public void lua_pushnumber(System.IntPtr luaState, System.Double number)
        {
            NativeMethods.lua_pushnumber(luaState, number);
        }

        public System.Int32 lua_pushthread(System.IntPtr luaState)
        {
            return NativeMethods.lua_pushthread(luaState);
        }

        public void lua_pushvalue(System.IntPtr luaState, System.Int32 index)
        {
            NativeMethods.lua_pushvalue(luaState, index);
        }

        public System.Int32 lua_rawequal(System.IntPtr luaState, System.Int32 index1, System.Int32 index2)
        {
            return NativeMethods.lua_rawequal(luaState, index1, index2);
        }

        public System.Int32 lua_rawget(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_rawget(luaState, index);
        }

        public System.Int32 lua_rawgeti(System.IntPtr luaState, System.Int32 index, System.Int64 n)
        {
            return NativeMethods.lua_rawgeti(luaState, index, n);
        }

        public System.Int32 lua_rawgetp(System.IntPtr luaState, System.Int32 index, System.IntPtr p)
        {
            return NativeMethods.lua_rawgetp(luaState, index, p);
        }

        public System.UIntPtr lua_rawlen(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_rawlen(luaState, index);
        }

        public void lua_rawset(System.IntPtr luaState, System.Int32 index)
        {
            NativeMethods.lua_rawset(luaState, index);
        }

        public void lua_rawseti(System.IntPtr luaState, System.Int32 index, System.Int64 i)
        {
            NativeMethods.lua_rawseti(luaState, index, i);
        }

        public void lua_rawsetp(System.IntPtr luaState, System.Int32 index, System.IntPtr p)
        {
            NativeMethods.lua_rawsetp(luaState, index, p);
        }

        public System.Int32 lua_resume(System.IntPtr luaState, System.IntPtr from, System.Int32 nargs)
        {
            return NativeMethods.lua_resume(luaState, from, nargs);
        }

        public void lua_rotate(System.IntPtr luaState, System.Int32 index, System.Int32 n)
        {
            NativeMethods.lua_rotate(luaState, index, n);
        }

        public void lua_setallocf(System.IntPtr luaState, System.IntPtr f, System.IntPtr ud)
        {
            NativeMethods.lua_setallocf(luaState, f, ud);
        }

        public void lua_setfield(System.IntPtr luaState, System.Int32 index, System.String key)
        {
            NativeMethods.lua_setfield(luaState, index, key);
        }

        public void lua_setglobal(System.IntPtr luaState, System.String key)
        {
            NativeMethods.lua_setglobal(luaState, key);
        }

        public System.String lua_getlocal(System.IntPtr luaState, System.IntPtr ar, System.Int32 n)
        {
            return NativeMethods.lua_getlocal(luaState, ar, n);
        }

        public System.Int32 lua_getmetatable(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_getmetatable(luaState, index);
        }

        public System.Int32 lua_getstack(System.IntPtr luaState, System.Int32 level, System.IntPtr n)
        {
            return NativeMethods.lua_getstack(luaState, level, n);
        }

        public System.Int32 lua_gettable(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_gettable(luaState, index);
        }

        public System.Int32 lua_gettop(System.IntPtr luaState)
        {
            return NativeMethods.lua_gettop(luaState);
        }

        public System.String lua_getupvalue(System.IntPtr luaState, System.Int32 funcIndex, System.Int32 n)
        {
            return NativeMethods.lua_getupvalue(luaState, funcIndex, n);
        }

        public System.Int32 lua_getuservalue(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_getuservalue(luaState, index);
        }

        public System.Int32 lua_iscfunction(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_iscfunction(luaState, index);
        }

        public System.Int32 lua_isinteger(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_isinteger(luaState, index);
        }

        public System.Int32 lua_isnumber(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_isnumber(luaState, index);
        }

        public System.Int32 lua_isstring(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_isstring(luaState, index);
        }

        public System.Int32 lua_isuserdata(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_isuserdata(luaState, index);
        }

        public System.Int32 lua_isyieldable(System.IntPtr luaState)
        {
            return NativeMethods.lua_isyieldable(luaState);
        }

        public void lua_len(System.IntPtr luaState, System.Int32 index)
        {
            NativeMethods.lua_len(luaState, index);
        }

        public System.Int32 lua_load(System.IntPtr luaState, System.IntPtr reader, System.IntPtr data, System.String chunkName, System.String mode)
        {
            return NativeMethods.lua_load(luaState, reader, data, chunkName, mode);
        }

        public System.IntPtr lua_newstate(System.IntPtr allocFunction, System.IntPtr ud)
        {
            return NativeMethods.lua_newstate(allocFunction, ud);
        }

        public System.IntPtr lua_newthread(System.IntPtr luaState)
        {
            return NativeMethods.lua_newthread(luaState);
        }

        public System.IntPtr lua_newuserdata(System.IntPtr luaState, System.UIntPtr size)
        {
            return NativeMethods.lua_newuserdata(luaState, size);
        }

        public System.Int32 lua_next(System.IntPtr luaState, System.Int32 index)
        {
            return NativeMethods.lua_next(luaState, index);
        }

        public System.Int32 lua_pcallk(System.IntPtr luaState, System.Int32 nargs, System.Int32 nresults, System.Int32 errorfunc, System.IntPtr ctx, System.IntPtr k)
        {
            return NativeMethods.lua_pcallk(luaState, nargs, nresults, errorfunc, ctx, k);
        }

        public void lua_pushboolean(System.IntPtr luaState, System.Int32 value)
        {
            NativeMethods.lua_pushboolean(luaState, value);
        }

        public System.Int32 lua_absindex(System.IntPtr luaState, System.Int32 idx)
        {
            return NativeMethods.lua_absindex(luaState, idx);
        }

        public void lua_arith(System.IntPtr luaState, System.Int32 op)
        {
            NativeMethods.lua_arith(luaState, op);
        }

        public System.IntPtr lua_atpanic(System.IntPtr luaState, System.IntPtr panicf)
        {
            return NativeMethods.lua_atpanic(luaState, panicf);
        }

        public void lua_callk(System.IntPtr luaState, System.Int32 nargs, System.Int32 nresults, System.IntPtr ctx, System.IntPtr k)
        {
            NativeMethods.lua_callk(luaState, nargs, nresults, ctx, k);
        }

        public System.Int32 lua_checkstack(System.IntPtr luaState, System.Int32 extra)
        {
            return NativeMethods.lua_checkstack(luaState, extra);
        }

        public void lua_close(System.IntPtr luaState)
        {
            NativeMethods.lua_close(luaState);
        }

        public System.Int32 lua_compare(System.IntPtr luaState, System.Int32 index1, System.Int32 index2, System.Int32 op)
        {
            return NativeMethods.lua_compare(luaState, index1, index2, op);
        }

        public void lua_concat(System.IntPtr luaState, System.Int32 n)
        {
            NativeMethods.lua_concat(luaState, n);
        }

        public void lua_copy(System.IntPtr luaState, System.Int32 fromIndex, System.Int32 toIndex)
        {
            NativeMethods.lua_copy(luaState, fromIndex, toIndex);
        }

        public void lua_createtable(System.IntPtr luaState, System.Int32 elements, System.Int32 records)
        {
            NativeMethods.lua_createtable(luaState, elements, records);
        }

        public System.Int32 lua_dump(System.IntPtr luaState, System.IntPtr writer, System.IntPtr data, System.Int32 strip)
        {
            return NativeMethods.lua_dump(luaState, writer, data, strip);
        }

        public System.Int32 lua_error(System.IntPtr luaState)
        {
            return NativeMethods.lua_error(luaState);
        }

        public System.Int32 lua_gc(System.IntPtr luaState, System.Int32 what, System.Int32 data)
        {
            return NativeMethods.lua_gc(luaState, what, data);
        }

        public System.IntPtr lua_getallocf(System.IntPtr luaState, ref System.IntPtr ud)
        {
            return NativeMethods.lua_getallocf(luaState, ref ud);
        }

        public System.Int32 lua_getfield(System.IntPtr luaState, System.Int32 index, System.String k)
        {
            return NativeMethods.lua_getfield(luaState, index, k);
        }

        public System.Int32 lua_getglobal(System.IntPtr luaState, System.String name)
        {
            return NativeMethods.lua_getglobal(luaState, name);
        }

        public System.IntPtr lua_gethook(System.IntPtr luaState)
        {
            return NativeMethods.lua_gethook(luaState);
        }

        public System.Int32 lua_gethookcount(System.IntPtr luaState)
        {
            return NativeMethods.lua_gethookcount(luaState);
        }

        public System.Int32 lua_gethookmask(System.IntPtr luaState)
        {
            return NativeMethods.lua_gethookmask(luaState);
        }

        public System.Int32 lua_geti(System.IntPtr luaState, System.Int32 index, System.Int64 i)
        {
            return NativeMethods.lua_geti(luaState, index, i);
        }

        public System.Int32 lua_getinfo(System.IntPtr luaState, System.String what, System.IntPtr ar)
        {
            return NativeMethods.lua_getinfo(luaState, what, ar);
        }


    }
}
