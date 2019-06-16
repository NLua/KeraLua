using System;
using System.Runtime.InteropServices;

namespace KeraLua
{
    static class DelegateExtensions
    {
        public static LuaFunction ToLuaFunction(this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaFunction) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaFunction));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaFunction>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer(this LuaFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaFunction>(d);
#endif
        }

        public static LuaHookFunction ToLuaHookFunction (this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;

#if NETFRAMEWORK
            return (LuaHookFunction) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaHookFunction));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaHookFunction>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer (this LuaHookFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaHookFunction>(d);
#endif
        }

        public static LuaKFunction ToLuaKFunction (this IntPtr ptr)
        {
           if(ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaKFunction) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaKFunction));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaKFunction>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer (this LuaKFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaKFunction>(d);
#endif
        }

        public static LuaReader ToLuaReader (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaReader) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaReader));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaReader>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer (this LuaReader d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaReader>(d);
#endif
        }

        public static LuaWriter ToLuaWriter (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaWriter) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaWriter));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaWriter>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer (this LuaWriter d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaWriter>(d);
#endif
        }

        public static LuaAlloc ToLuaAlloc (this IntPtr ptr)
        {
            if(ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaAlloc) Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaAlloc));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaAlloc>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer (this LuaAlloc d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaAlloc>(d);
#endif
        }

        public static LuaWarnFunction ToLuaWarning(this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return null;
#if NETFRAMEWORK
            return (LuaWarnFunction)Marshal.GetDelegateForFunctionPointer(ptr, typeof(LuaWarnFunction));
#else
            return Marshal.GetDelegateForFunctionPointer<LuaWarnFunction>(ptr);
#endif
        }

        public static IntPtr ToFunctionPointer(this LuaWarnFunction d)
        {
            if (d == null)
                return IntPtr.Zero;

#if NETFRAMEWORK
            return Marshal.GetFunctionPointerForDelegate(d);
#else
            return Marshal.GetFunctionPointerForDelegate<LuaWarnFunction>(d);
#endif
        }
    }
}
