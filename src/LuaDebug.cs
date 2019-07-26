using System;
using System.Text;
using System.Runtime.InteropServices;

namespace KeraLua
{
    /// <summary>
    /// Structure for lua debug information
    /// </summary>
    /// <remarks>
    /// Do not change this struct because it must match the lua structure lua_Debug
    /// </remarks>
    /// <author>Reinhard Ostermeier</author>
    [StructLayout(LayoutKind.Sequential)]
    public struct LuaDebug
    {
        /// <summary>
        /// Get a LuaDebug from IntPtr
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static LuaDebug FromIntPtr(IntPtr ar)
        {
#if NETFRAMEWORK
                return (LuaDebug)Marshal.PtrToStructure(ar, typeof(LuaDebug));
#else
                return Marshal.PtrToStructure<LuaDebug>(ar);
#endif
        }
        /// <summary>
        /// Debug event code
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public LuaHookEvent Event;
        /// <summary>
        ///  a reasonable name for the given function. Because functions in Lua are first-class values, they do not have a fixed name: some functions can be the value of multiple global variables, while others can be stored only in a table field
        /// </summary>
        public string Name => Marshal.PtrToStringAnsi(name);
        IntPtr name;
        /// <summary>
        /// explains the name field. The value of namewhat can be "global", "local", "method", "field", "upvalue", or "" (the empty string)
        /// </summary>
        public string NameWhat => Marshal.PtrToStringAnsi(what);
        IntPtr nameWhat;
        /// <summary>
        ///  the string "Lua" if the function is a Lua function, "C" if it is a C function, "main" if it is the main part of a chunk
        /// </summary>
        public string What => Marshal.PtrToStringAnsi(what);
        IntPtr what;
        /// <summary>
        ///  the name of the chunk that created the function. If source starts with a '@', it means that the function was defined in a file where the file name follows the '@'.
        /// </summary>
        /// 
        public string Source => Marshal.PtrToStringAnsi(source);
        IntPtr source;
        /// <summary>
        ///  the current line where the given function is executing. When no line information is available, currentline is set to -1
        /// </summary>
        public int CurrentLine;
        /// <summary>
        /// 
        /// </summary>
        public int LineDefined;
        /// <summary>
        ///  the line number where the definition of the function ends. 
        /// </summary>
        public int LastLineDefined;
        /// <summary>
        /// number of upvalues
        /// </summary>
        public byte NumberUpValues;
        /// <summary>
        /// number of parameters
        /// </summary>
        public byte NumberParameters;
        /// <summary>
        ///  true if the function is a vararg function (always true for C functions).
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool IsVarArg;        /* (u) */
        /// <summary>
        ///  true if this function invocation was called by a tail call. In this case, the caller of this level is not in the stack.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool IsTailCall; /* (t) */
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        byte [] shortSource;

        /// <summary>
        /// a "printable" version of source, to be used in error messages
        /// </summary>
        public string ShortSource
        {
            get
            {
                if (shortSource[0] == 0)
                    return string.Empty;

                int count = 0;

                while (count < shortSource.Length && shortSource[count] != 0)
                {
                    count++;
                }

                return Encoding.ASCII.GetString(shortSource, 0, count);
            }
        }
        IntPtr i_ci;
    }
}
