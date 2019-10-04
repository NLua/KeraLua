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

            var param1 = state.ToObject<XDocument>(1);
            var param2 = state.ToObject<XDocument>(2);

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

            var param1 = state.ToObject<Rectangle?>(1);
            var param2 = state.ToObject<Rectangle>(2);
            var param3 = state.ToObject<DateTime>(3);

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

            state.PushObject<XDocument>(null);
            state.SetGlobal("foo");

            state.PushObject(document);
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

            state.PushObject<Rectangle?>(null);
            state.SetGlobal("foo");

            state.PushObject(new Rectangle(10, 10, 100, 100));
            state.SetGlobal("bar");

            state.PushObject(new DateTime(2018, 10, 10, 0, 0 ,0));
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
            string shortSource = debug.ShortSource;

            source = System.IO.Path.GetFileName(source);
            hookLog.AppendLine($"{shortSource}-{source}:{debug.CurrentLine} ({debug.What})");
        }

        static void HookCalbackStruct(IntPtr p, IntPtr ar)
        {
            var state = Lua.FromIntPtr(p);
            var debug = new LuaDebug();

            state.GetStack(0, ref debug);

            if(!state.GetInfo("Snlu", ref debug))
                return;
            string shortSource = debug.ShortSource;
            string source = debug.Source.Substring(1);
            source = System.IO.Path.GetFileName(source);
            hookLog.AppendLine ($"{shortSource}-{source}:{debug.CurrentLine} ({debug.What})");
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
@"main.lua-main.lua:2 (main)
./foo.lua-foo.lua:2 (main)
./module1.lua-module1.lua:3 (main)
./module1.lua-module1.lua:9 (main)
./module1.lua-module1.lua:5 (main)
./module1.lua-module1.lua:11 (main)
./foo.lua-foo.lua:8 (main)
./foo.lua-foo.lua:4 (main)
./foo.lua-foo.lua:14 (main)
./foo.lua-foo.lua:10 (main)
./foo.lua-foo.lua:14 (main)
main.lua-main.lua:4 (main)
main.lua-main.lua:5 (main)
main.lua-main.lua:7 (main)
main.lua-main.lua:8 (main)
./foo.lua-foo.lua:5 (Lua)
./foo.lua-foo.lua:6 (Lua)
./foo.lua-foo.lua:7 (Lua)
./module1.lua-module1.lua:6 (Lua)
./module1.lua-module1.lua:7 (Lua)
./module1.lua-module1.lua:8 (Lua)
./foo.lua-foo.lua:8 (Lua)
main.lua-main.lua:11 (main)
";
            expected = expected.Replace("\r","");
            expected = expected.Replace('/', System.IO.Path.DirectorySeparatorChar);
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
@"main.lua-main.lua:2 (main)
./foo.lua-foo.lua:2 (main)
./module1.lua-module1.lua:3 (main)
./module1.lua-module1.lua:9 (main)
./module1.lua-module1.lua:5 (main)
./module1.lua-module1.lua:11 (main)
./foo.lua-foo.lua:8 (main)
./foo.lua-foo.lua:4 (main)
./foo.lua-foo.lua:14 (main)
./foo.lua-foo.lua:10 (main)
./foo.lua-foo.lua:14 (main)
main.lua-main.lua:4 (main)
main.lua-main.lua:5 (main)
main.lua-main.lua:7 (main)
main.lua-main.lua:8 (main)
./foo.lua-foo.lua:5 (Lua)
./foo.lua-foo.lua:6 (Lua)
./foo.lua-foo.lua:7 (Lua)
./module1.lua-module1.lua:6 (Lua)
./module1.lua-module1.lua:7 (Lua)
./module1.lua-module1.lua:8 (Lua)
./foo.lua-foo.lua:8 (Lua)
main.lua-main.lua:11 (main)
";
            expected = expected.Replace('/', System.IO.Path.DirectorySeparatorChar);
            expected = expected.Replace("\r","");
            output = output.Replace("\r","");

            Assert.AreEqual(expected, output, "#2");

            state.SetHook(FuncHookCallback, LuaHookMask.Disabled, 0);

            Assert.IsNull(state.Hook, "#3");
        }

        [Test]
        public void TypeNameReturn()
        {
            using (var lua = new Lua())
            {
                lua.PushInteger(28);
                string name = lua.TypeName(-1);

                Assert.AreEqual("number", name, "#1");
            }
        }

        [Test]
        public void SettingUpValueDoesntCrash()
        {
            using (var lua = new Lua())
            {
                lua.LoadString("hello = 1");
                lua.NewTable();
                string result = lua.SetUpValue(-2, 1);

                Assert.AreEqual("_ENV", result, "#1");
            }
        }

        [Test]
        public void TestUnref()
        {
            var state = new Lua();
            state.DoString("function f() end");
            LuaType type =  state.GetGlobal("f");
            Assert.AreEqual(LuaType.Function, type, "#1");

            state.PushCopy(-1);
            state.Ref(LuaRegistry.Index);
            state.Close();
        }

#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaFunction))]
#endif
        public static int Func(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            long param1 = state.CheckInteger(1);
            long param2 = state.CheckInteger(2);

            state.PushInteger(param1 + param2);
            return 1;
        }

        [Test]
        public void TestThreadFromToPtr()
        {
            using (var lua = new Lua())
            {
                lua.Register("func1", Func);

                var thread = lua.NewThread();

                thread.DoString("func1(10,10)");
                thread.DoString("func1(10,10)");
            }
        }

        [Test]
        public void TestCoroutineCallback()
        {
            using (var lua = new Lua())
            {
                lua.Register("func1", Func);

                string script = @"function yielder() 
                                a=1; 
                                coroutine.yield();
                                a = func1(3,2);
                                a = func1(4,2);
                                coroutine.yield();
                                a=2;
                                coroutine.yield();
                             end
                             co_routine = coroutine.create(yielder);
                             while coroutine.resume(co_routine) do end;";
                lua.DoString(script);
                lua.DoString(script);

                lua.GetGlobal("a");
                long a = lua.ToInteger(-1);
                Assert.AreEqual(a, 2d);
            }
        }

        [Test]
        public void TestToStringStack()
        {
            using (var lua = new Lua())
            {
                lua.PushNumber(3);
                lua.PushInteger(4);

                int currentTop = lua.GetTop();

                string four = lua.ToString(-1);

                int newTop = lua.GetTop();

                Assert.AreEqual("4", four, "#1.1");
                Assert.AreEqual(currentTop, newTop, "#1.2");
            }
        }

        [Test]
        public void GettingUpValueDoesntCrash()
        {
            using (var lua = new Lua())
            {
                lua.LoadString("hello = 1");
                string result = lua.GetUpValue(-1, 1);

                Assert.AreEqual("_ENV", result, "#1");
            }
        }

        [Test]
        public void ResumeAcceptsNull()
        {
            using (var lua = new Lua())
            {
                lua.LoadString("hello = 1");
                LuaStatus result = lua.Resume(null, 0);

                Assert.AreEqual(LuaStatus.OK, result);
            }
        }

#if MONOTOUCH
        [MonoPInvokeCallback(typeof(LuaWarnFunction))]
#endif
        public static void MyWarning(IntPtr ud, IntPtr msg, int tocont)
        {
            var lua = Lua.FromIntPtr(ud);
            StringBuilder sb = lua.ToObject<StringBuilder>(-1);
            string message = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(msg);
            sb.Append(message);
        }

        [Test]
        public void TestWarning()
        {
            using (var lua = new Lua())
            {
                LuaWarnFunction warnFunction = MyWarning;
                var sb = new StringBuilder();

                lua.PushObject(sb);
                lua.SetWarningFunction(warnFunction, lua.Handle);

                lua.Warning("Ola um dois tres", false);


                Assert.AreEqual("Ola um dois tres", sb.ToString(), "#1");
            }
        }


    }
}
