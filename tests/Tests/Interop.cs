using System;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using KeraLua;

using System.Drawing;

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

        
#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaFunction))]
#endif
        static int TestReferenceData(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);

            var param1 = state.ToReferenceData<XDocument>(1);
            var param2 = state.ToReferenceData<XDocument>(2);

            Assert.IsNull(param1, "#1");
            Assert.AreEqual(param2, _gTempDocument,  "#2");

            return 0;
        }

#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaFunction))]
#endif
        static int TestValueData(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);

            var param1 = state.ToValueDataNullable<Rectangle>(1);
            var param2 = state.ToValueData<Rectangle>(2);
            var param3 = state.ToValueData<DateTime>(3);

            Assert.IsNull(param1, "#1");
            Assert.AreEqual(param2, new Rectangle(10, 10, 100, 100),  "#2");
            Assert.AreEqual(param3, new DateTime(2018, 10, 10, 0, 0 ,0),  "#3");

            return 0;
        }

        public static LuaFunction FuncTestUnicodeString = TestUnicodeString;
        public static LuaFunction FuncTestReferenceData = TestReferenceData;
        public static LuaFunction FuncTestValueData = TestValueData;

        private static XDocument _gTempDocument;

        [Test]
        public void TestUnicodeString()
        {
            var state = new Lua {
                Encoding = Encoding.UTF8
            };
            state.PushCFunction(FuncTestUnicodeString);
            state.SetGlobal("TestUnicodeString");
            state.PushString(UnicodeString);
            state.SetGlobal("unicodeString");
            AssertString("TestUnicodeString(unicodeString)", state);
        }

        [Test]
        public void TestPushReferenceData()
        {
            var document = XDocument.Parse(@"<users>
                                                    <user name=""John Doe"" age=""42"" />
                                                    <user name=""Jane Doe"" age=""39"" />
                                                  </users>");
            var state = new Lua();

            state.PushReferenceData<XDocument>(null);
            state.SetGlobal("foo");

            state.PushReferenceData(document);
            state.SetGlobal("bar");

            state.PushCFunction(FuncTestReferenceData);
            state.SetGlobal("TestReferenceData");

            _gTempDocument = document;
            AssertString("TestReferenceData(foo, bar)", state);
        }

        [Test]
        public void TestPushValueData()
        {
            var state = new Lua();

            state.PushValueData<Rectangle>(null);
            state.SetGlobal("foo");

            state.PushValueData(new Rectangle(10, 10, 100, 100));
            state.SetGlobal("bar");

            state.PushValueData(new DateTime(2018, 10, 10, 0, 0 ,0));
            state.SetGlobal("date");

            state.PushCFunction(FuncTestValueData);
            state.SetGlobal("TestValueData");

            AssertString("TestValueData(foo, bar, date)", state);
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
