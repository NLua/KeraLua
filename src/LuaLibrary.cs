using System;

namespace KeraLua
{
    /// <summary>
    /// The lua standard libraries
    /// </summary>
    [Flags]
    public enum LuaLibrary
    {
        /// <summary>
        /// no library.
        /// </summary>
        None = 0,
        /// <summary>
        /// the basic library.
        /// </summary>
        Basic = 1,
        /// <summary>
        /// the package library.
        /// </summary>
        Package = Basic << 1,
        /// <summary>
        /// the coroutine library.
        /// </summary>
        Coroutine = Package << 1,
        /// <summary>
        /// the string library.
        /// </summary>
        String = Os << 1,
        /// <summary>
        /// the UTF-8 library.
        /// </summary>
        Utf8 = Table << 1,
        /// <summary>
        /// the table library.
        /// </summary>
        Table = String << 1,
        /// <summary>
        /// the mathematical library.
        /// </summary>
        Math = Io << 1,
        /// <summary>
        /// the I/O library.
        /// </summary>
        Io = Debug << 1,
        /// <summary>
        /// the operating system library.
        /// </summary>
        Os = Math << 1,
        /// <summary>
        /// the debug library.
        /// </summary>
        Debug = Coroutine << 1,
        /// <summary>
        /// all libraries.
        /// </summary>
        All = ~None,
    }
}
