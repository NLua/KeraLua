using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
    /// <summary>
    /// Lua library names
    /// </summary>
    public static class LuaLibraryName
    {
        public const string Base = "_G";
        public const string Package = "package";
        public const string Coroutine = "coroutine";
        public const string Table = "table";
        public const string IO = "io";
        public const string OS = "os";
        public const string String = "string";
        public const string Math = "math";
        public const string UTF8 = "utf8";
        public const string Debug = "debug";
    }
}
