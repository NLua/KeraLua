using System;
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
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LuaDebug
    {
        /// <summary>
        /// Debug event code
        /// </summary>
        public int eventCode;
        /// <summary>
        ///  a reasonable name for the given function. Because functions in Lua are first-class values, they do not have a fixed name: some functions can be the value of multiple global variables, while others can be stored only in a table field
        /// </summary>
        public string name;
        /// <summary>
        /// explains the name field. The value of namewhat can be "global", "local", "method", "field", "upvalue", or "" (the empty string)
        /// </summary>
        public string nameWhat;
        /// <summary>
        ///  the string "Lua" if the function is a Lua function, "C" if it is a C function, "main" if it is the main part of a chunk
        /// </summary>
        public string what;
        /// <summary>
        ///  the name of the chunk that created the function. If source starts with a '@', it means that the function was defined in a file where the file name follows the '@'.
        /// </summary>
        public string source;
        /// <summary>
        ///  the current line where the given function is executing. When no line information is available, currentline is set to -1
        /// </summary>
        public int currentLine;
        /// <summary>
        /// 
        /// </summary>
        public int lineDefined;
        /// <summary>
        ///  the line number where the definition of the function ends. 
        /// </summary>
        public int lastLineDefined;
        /// <summary>
        /// number of upvalues
        /// </summary>
        public byte numberUpValues;
        /// <summary>
        /// number of parameters
        /// </summary>
        public byte numberParameters;
        /// <summary>
        ///  true if the function is a vararg function (always true for C functions).
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool isVarArg;        /* (u) */
        /// <summary>
        ///  true if this function invocation was called by a tail call. In this case, the caller of this level is not in the stack.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool isTailCall; /* (t) */
        /// <summary>
        /// a "printable" version of source, to be used in error messages
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
        public string short_src;
        IntPtr i_ci;
    }
}
