
namespace KeraLua
{
    using System;

    public struct LuaBuffer
    {
        private readonly IntPtr state;

        public LuaBuffer(IntPtr ptrState)

            : this()
        {
            state = ptrState;
        }

        public static implicit operator LuaBuffer(IntPtr ptr)
        {
            return new LuaBuffer(ptr);
        }


        public static implicit operator IntPtr(LuaBuffer luaState)
        {
            return luaState.state;
        }
    }
}
