using System.Runtime.InteropServices;
using System.Security;

using size_t = System.UIntPtr;
using lua_State = System.IntPtr;
using voidptr_t = System.IntPtr;
using charptr_t = System.IntPtr;
using lua_KContext = System.IntPtr;
using lua_Debug = System.IntPtr;

namespace KeraLua
{
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate int LuaFunction(lua_State luaState);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void LuaHookFunction (lua_State luaState, lua_Debug ar);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate int LuaKFunction (lua_State L, int status, lua_KContext ctx);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate charptr_t LuaReader (lua_State L, voidptr_t ud, ref size_t sz);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate int LuaWriter (lua_State L, voidptr_t p, size_t size, voidptr_t ud);

    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate voidptr_t LuaAlloc (voidptr_t ud, voidptr_t ptr, size_t osize, size_t nsize);

}
