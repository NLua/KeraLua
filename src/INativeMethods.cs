
using size_t = System.UIntPtr;
using lua_State = System.IntPtr;
using lua_CFunction = System.IntPtr;
using voidptr_t = System.IntPtr;
using charptr_t = System.IntPtr;
using lua_KContext = System.IntPtr;
using lua_KFunction = System.IntPtr;
using lua_Writer = System.IntPtr;
using lua_Reader = System.IntPtr;
using lua_Alloc = System.IntPtr;
using lua_Hook = System.IntPtr;
using lua_Integer = System.Int64;
using lua_Number = System.Double;
using lua_Number_ptr = System.IntPtr;
using lua_Debug = System.IntPtr;
using System.Runtime.InteropServices;

namespace KeraLua
{
    public interface INativeMethods
    {

        int lua_absindex(lua_State luaState, int idx);

        void lua_arith(lua_State luaState, int op);

        lua_CFunction lua_atpanic(lua_State luaState, lua_CFunction panicf);

        
        void lua_callk(lua_State luaState, int nargs, int nresults, lua_KContext ctx, lua_KFunction k);

        
        int lua_checkstack(lua_State luaState, int extra);

        
        void lua_close(lua_State luaState);

        
        int lua_compare(lua_State luaState, int index1, int index2, int op);

        
        void lua_concat(lua_State luaState, int n);

        
        void lua_copy(lua_State luaState, int fromIndex, int toIndex);

        
        void lua_createtable(lua_State luaState, int elements, int records);

        
        int lua_dump(lua_State luaState, lua_Writer writer, voidptr_t data, int strip);

        
        int lua_error(lua_State luaState);

        
        int lua_gc(lua_State luaState, int what, int data);

        
        lua_Alloc lua_getallocf(lua_State luaState, ref voidptr_t ud);

        
        int lua_getfield(lua_State luaState, int index, string k);

        
        int lua_getglobal(lua_State luaState, string name);

        
        lua_Hook lua_gethook(lua_State luaState);

        
        int lua_gethookcount(lua_State luaState);

        
        int lua_gethookmask(lua_State luaState);

        
        int lua_geti(lua_State luaState, int index, long i);

        
        int lua_getinfo(lua_State luaState, string what, lua_Debug ar);

        
        string lua_getlocal(lua_State luaState, lua_Debug ar, int n);

        
        int lua_getmetatable(lua_State luaState, int index);

        
        int lua_getstack(lua_State luaState, int level, lua_Debug n);

        
        int lua_gettable(lua_State luaState, int index);

        
        int lua_gettop(lua_State luaState);

        
        string lua_getupvalue(lua_State luaState, int funcIndex, int n);

        
        int lua_getuservalue(lua_State luaState, int index);

        
        int lua_iscfunction(lua_State luaState, int index);

        
        int lua_isinteger(lua_State luaState, int index);

        
        int lua_isnumber(lua_State luaState, int index);

        
        int lua_isstring(lua_State luaState, int index);

        
        int lua_isuserdata(lua_State luaState, int index);

        
        int lua_isyieldable(lua_State luaState);

        
        void lua_len(lua_State luaState, int index);

        
        int lua_load
           (lua_State luaState,
            lua_Reader reader,
            voidptr_t data,
            string chunkName,
            string mode);

        
        lua_State lua_newstate(lua_Alloc allocFunction, voidptr_t ud);

        
        lua_State lua_newthread(lua_State luaState);

        
        voidptr_t lua_newuserdata(lua_State luaState, size_t size);

        
        int lua_next(lua_State luaState, int index);

        
        int lua_pcallk
            (lua_State luaState,
            int nargs,
            int nresults,
            int errorfunc,
            lua_KContext ctx,
            lua_KFunction k);

        
        void lua_pushboolean(lua_State luaState, int value);

        
        void lua_pushcclosure(lua_State luaState, lua_CFunction f, int n);

        
        void lua_pushinteger(lua_State luaState, lua_Integer n);

        
        void lua_pushlightuserdata(lua_State luaState, voidptr_t udata);

        
        charptr_t lua_pushlstring(lua_State luaState, byte[] s, size_t len);

        
        void lua_pushnil(lua_State luaState);

        
        void lua_pushnumber(lua_State luaState, lua_Number number);

        
        int lua_pushthread(lua_State luaState);

        
        void lua_pushvalue(lua_State luaState, int index);

        
        int lua_rawequal(lua_State luaState, int index1, int index2);

        
        int lua_rawget(lua_State luaState, int index);

        
        int lua_rawgeti(lua_State luaState, int index, lua_Integer n);

        
        int lua_rawgetp(lua_State luaState, int index, voidptr_t p);

        
        size_t lua_rawlen(lua_State luaState, int index);

        
        void lua_rawset(lua_State luaState, int index);

        
        void lua_rawseti(lua_State luaState, int index, lua_Integer i);

        
        void lua_rawsetp(lua_State luaState, int index, voidptr_t p);

        
        int lua_resume(lua_State luaState, lua_State from, int nargs);

        
        void lua_rotate(lua_State luaState, int index, int n);

        
        void lua_setallocf(lua_State luaState, lua_Alloc f, voidptr_t ud);

        
        void lua_setfield(lua_State luaState, int index, string key);

        
        void lua_setglobal(lua_State luaState, string key);

        
        void lua_sethook(lua_State luaState, lua_Hook f, int mask, int count);

        
        void lua_seti(lua_State luaState, int index, long n);

        
        string lua_setlocal(lua_State luaState, lua_Debug ar, int n);

        
        void lua_setmetatable(lua_State luaState, int objIndex);

        
        void lua_settable(lua_State luaState, int index);

        
        void lua_settop(lua_State luaState, int newTop);

        
        string lua_setupvalue(lua_State luaState, int funcIndex, int n);

        
        void lua_setuservalue(lua_State luaState, int index);

        
        int lua_status(lua_State luaState);

        
        size_t lua_stringtonumber(lua_State luaState, string s);

        
        int lua_toboolean(lua_State luaState, int index);

        
        lua_CFunction lua_tocfunction(lua_State luaState, int index);

        
        lua_Integer lua_tointegerx(lua_State luaState, int index, out int isNum);

        
        charptr_t lua_tolstring(lua_State luaState, int index, out size_t strLen);

        
        lua_Number lua_tonumberx(lua_State luaState, int index, out int isNum);

        
        voidptr_t lua_topointer(lua_State luaState, int index);

        
        lua_State lua_tothread(lua_State luaState, int index);

        
        voidptr_t lua_touserdata(lua_State luaState, int index);

        
        int lua_type(lua_State luaState, int index);

        
        string lua_typename(lua_State luaState, int type);

        
        voidptr_t lua_upvalueid(lua_State luaState, int funcIndex, int n);

        
        void lua_upvaluejoin(lua_State luaState, int funcIndex1, int n1, int funcIndex2, int n2);

        
        lua_Number_ptr lua_version(lua_State luaState);

        
        void lua_xmove(lua_State from, lua_State to, int n);

        
        int lua_yieldk(lua_State luaState,
            int nresults,
            lua_KContext ctx,
            lua_KFunction k);

        
        int luaL_argerror(lua_State luaState, int arg, string message);

        
        int luaL_callmeta(lua_State luaState, int obj, string e);

        
        void luaL_checkany(lua_State luaState, int arg);

        
        lua_Integer luaL_checkinteger(lua_State luaState, int arg);

        
        charptr_t luaL_checklstring(lua_State luaState, int arg, out size_t len);

        
        lua_Number luaL_checknumber(lua_State luaState, int arg);

        
        int luaL_checkoption(lua_State luaState, int arg, string def, string[] list);

        
        void luaL_checkstack(lua_State luaState, int sz, string message);

        
        void luaL_checktype(lua_State luaState, int arg, int type);

        
        voidptr_t luaL_checkudata(lua_State luaState, int arg, string tName);


        void luaL_checkversion_(lua_State luaState, lua_Number ver, size_t sz);


        int luaL_error(lua_State luaState, string message);

        
        int luaL_execresult(lua_State luaState, int stat);

        
        int luaL_fileresult(lua_State luaState, int stat, string fileName);

        
        int luaL_getmetafield(lua_State luaState, int obj, string e);

        
        int luaL_getsubtable(lua_State luaState, int index, string name);

        
        lua_Integer luaL_len(lua_State luaState, int index);

        
        int luaL_loadbufferx
            (lua_State luaState,
            byte[] buff,
            size_t sz,
            string name,
            string mode);

        
        int luaL_loadfilex(lua_State luaState, string name, string mode);

        
        int luaL_newmetatable(lua_State luaState, string name);

        
        lua_State luaL_newstate();

        
        void luaL_openlibs(lua_State luaState);

        
        lua_Integer luaL_optinteger(lua_State luaState, int arg, lua_Integer d);

        
        lua_Number luaL_optnumber(lua_State luaState, int arg, lua_Number d);

        
        int luaL_ref(lua_State luaState, int registryIndex);

        
        void luaL_requiref(lua_State luaState, string moduleName, lua_CFunction openFunction, int global);

        
        void luaL_setfuncs(lua_State luaState, [In] LuaRegister[] luaReg, int numUp);

        
        void luaL_setmetatable(lua_State luaState, string tName);

        
        voidptr_t luaL_testudata(lua_State luaState, int arg, string tName);

        
        charptr_t luaL_tolstring(lua_State luaState, int index, out size_t len);

        
        charptr_t luaL_traceback
           (lua_State luaState,
            lua_State luaState2,
            string message,
            int level);

        
        string luaL_typename(lua_State luaState, int index);

        
        void luaL_unref(lua_State luaState, int registryIndex, int reference);

        
        void luaL_where(lua_State luaState, int level);
    }
}
