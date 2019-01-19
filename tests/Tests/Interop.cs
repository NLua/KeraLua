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

        [SetUp]
        public void SetUp()
        {
            string path = new Uri(GetType().Assembly.CodeBase).AbsolutePath;
            path = System.IO.Path.GetDirectoryName(path);
            Environment.CurrentDirectory = path;
        }

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

        static StringBuilder hookLog;

#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaHookFunction))]
#endif
        static void HookCallback(IntPtr p, IntPtr ar)
        {
            var state = Lua.FromIntPtr(p);
            var debug = LuaDebug.FromIntPtr(ar);

            Assert.NotNull(state, "#state shouldn't be null");
            Assert.NotNull(debug, "#debug shouldn't be null");

            if (debug.Event != LuaHookEvent.Line)
                return;

            state.GetStack(0, ar);

            if(!state.GetInfo("Snlu", ar))
                return;

            debug = LuaDebug.FromIntPtr(ar);
            string source = debug.Source.Substring(1);
            source = System.IO.Path.GetFileName(source);
            hookLog.AppendLine($"{source}:{debug.CurrentLine} ({debug.What})");
        }

        static void HookCalbackStruct(IntPtr p, IntPtr ar)
        {
            var state = Lua.FromIntPtr(p);
            var debug = new LuaDebug();

            state.GetStack(0, ref debug);

            if(!state.GetInfo("Snlu", ref debug))
                return;

            string source = debug.Source.Substring(1);
            source = System.IO.Path.GetFileName(source);
            hookLog.AppendLine ($"{source}:{debug.CurrentLine} ({debug.What})");
        }

        static LuaHookFunction FuncHookCallback = HookCallback;


        [Test]
        public void TestLuaHook()
        {
            var state = new Lua();
            hookLog = new StringBuilder();
            state.SetHook(FuncHookCallback, LuaHookMask.Line, 0);
            state.DoFile("main.lua");
            string output = hookLog.ToString();
            string expected = 
@"main.lua:2 (main)
foo.lua:2 (main)
module1.lua:3 (main)
module1.lua:9 (main)
module1.lua:5 (main)
module1.lua:11 (main)
foo.lua:8 (main)
foo.lua:4 (main)
foo.lua:14 (main)
foo.lua:10 (main)
foo.lua:14 (main)
main.lua:4 (main)
main.lua:5 (main)
main.lua:7 (main)
main.lua:8 (main)
foo.lua:5 (Lua)
foo.lua:6 (Lua)
foo.lua:7 (Lua)
module1.lua:6 (Lua)
module1.lua:7 (Lua)
module1.lua:8 (Lua)
foo.lua:8 (Lua)
main.lua:11 (main)
";
            expected = expected.Replace("\r","");
            output = output.Replace("\r","");
            Assert.AreEqual(expected, output, "#1");
            Assert.IsNotNull(state.Hook);
        }

        [Test]
        public void TestLuaHookStruct()
        {
            FuncHookCallback = HookCalbackStruct;
            var state = new Lua();
            hookLog = new StringBuilder();

            state.SetHook(FuncHookCallback, LuaHookMask.Line, 0);

            Assert.AreEqual(FuncHookCallback, state.Hook, "#1");

            state.DoFile("main.lua");
            string output = hookLog.ToString();
            string expected = 
@"main.lua:2 (main)
foo.lua:2 (main)
module1.lua:3 (main)
module1.lua:9 (main)
module1.lua:5 (main)
module1.lua:11 (main)
foo.lua:8 (main)
foo.lua:4 (main)
foo.lua:14 (main)
foo.lua:10 (main)
foo.lua:14 (main)
main.lua:4 (main)
main.lua:5 (main)
main.lua:7 (main)
main.lua:8 (main)
foo.lua:5 (Lua)
foo.lua:6 (Lua)
foo.lua:7 (Lua)
module1.lua:6 (Lua)
module1.lua:7 (Lua)
module1.lua:8 (Lua)
foo.lua:8 (Lua)
main.lua:11 (main)
";
            expected = expected.Replace("\r","");
            output = output.Replace("\r","");

            Assert.AreEqual(expected, output, "#2");

            state.SetHook(FuncHookCallback, LuaHookMask.Disabled, 0);

            Assert.IsNull(state.Hook, "#3");
        }
    }
}
