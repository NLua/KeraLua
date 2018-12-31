using System;
using System.Runtime.InteropServices;

namespace KeraLua
{
    static class DelegateExtensions
    {
        public static LuaFunction ToLuaFunction (this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;

            return (LuaFunction) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaFunction));
        }

        public static IntPtr ToFunctionPointer (this LuaFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }

        public static LuaHookFunction ToLuaHookFunction (this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;

            return (LuaHookFunction) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaHookFunction));
        }

        public static IntPtr ToFunctionPointer (this LuaHookFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }

        public static LuaKFunction ToLuaKFunction (this IntPtr ptr)
        {
           if(ptr == IntPtr.Zero)
                return null;
            return (LuaKFunction) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaHookFunction));
        }

        public static IntPtr ToFunctionPointer (this LuaKFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }

        public static LuaReader ToLuaReader (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
            return (LuaReader) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaReader));
        }

        public static IntPtr ToFunctionPointer (this LuaReader d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }

        public static LuaWriter ToLuaWriter (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
            return (LuaWriter) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaWriter));
        }

        public static IntPtr ToFunctionPointer (this LuaWriter d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }

        public static LuaAlloc ToLuaAlloc (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
            return (LuaAlloc) Marshal.GetDelegateForFunctionPointer (ptr, typeof (LuaAlloc));
        }

        public static IntPtr ToFunctionPointer (this LuaAlloc d)
        {
            if (d == null)
                return IntPtr.Zero;

            return Marshal.GetFunctionPointerForDelegate(d);
        }
    }
}
