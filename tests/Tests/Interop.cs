using System;
using System.Text;

using NUnit.Framework;
using KeraLua;

#if MONOTOUCH
    using ObjCRuntime;
#endif

namespace KeraLuaTest.Tests
{
    [TestFixture]
    public class Interop
    {
        public static readonly char UnicodeChar = '\uE007';
        public static string UnicodeString => Convert.ToString(UnicodeChar);

#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaFunction))]
#endif
        static int TestUnicodeString(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            string param = state.ToString(1, false);

            Assert.AreEqual(UnicodeString, param, "#1 ToString()");

            return 0;
        }

        public static LuaFunction FuncTestUnicodeString = TestUnicodeString;

        [Test]
        public void TestUnicodeString()
        {
            Lua state = new Lua();
            state.Encoding = Encoding.UTF8;
            state.PushCFunction(FuncTestUnicodeString);
            state.SetGlobal("TestUnicodeString");
            state.PushString(UnicodeString);
            state.SetGlobal("unicodeString");
            AssertString("TestUnicodeString(unicodeString)", state);
        }

        void AssertString(string chunk, Lua state)
        {
            string error = string.Empty;

            LuaStatus result = state.LoadString(chunk);

            if(result != LuaStatus.OK)
                error = state.ToString(1, false);

            Assert.True(result == LuaStatus.OK, "Fail loading string: " + chunk + "ERROR:" + error);

            result = state.PCall(0, -1, 0);

            if(result != 0)
                error = state.ToString(1, false);

            Assert.True(result == 0, "Fail calling chunk: " + chunk + " ERROR: " + error);
        }
    }
}
