
using System;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;
using System.Text;

#if MONOTOUCH
    using ObjCRuntime;
#endif

namespace KeraLua.Tests
{
    [TestFixture]
    public class Core
    {
        public static readonly char UnicodeChar = '\uE007';
        public static string UnicodeString => Convert.ToString (UnicodeChar);

#if MONOTOUCH
        [MonoPInvokeCallback (typeof (LuaFunction))]
#endif
        static int print (IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            int n = state.GetTop();  /* number of arguments */
            int i;
            for (i=1; i<=n; i++) {
                LuaType type = state.Type(i);
                switch (type) {
                        
                    case LuaType.Nil:
                        Trace.Write("nil");
                        break;
                    case LuaType.String:
                        string s = state.ToString(i, false);
                        Trace.Write(s);
                        break;
                    case LuaType.Number:
                        double number = state.ToNumber(i);
                        Trace.Write (number);
                        break;
                }
            }
            Trace.WriteLine("\n");
            return 0;
        }

        static int TestUnicodeString (IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            string param = state.ToString (1, false);

            Assert.AreEqual (UnicodeString, param, "#1 ToString()");

            return 0;
        }

        public static LuaFunction func_print = print;
        public static LuaFunction FuncTestUnicodeString = TestUnicodeString;

        Lua state;
        string GetTestPath(string name)
        {
            string path = new Uri(GetType().Assembly.CodeBase).AbsolutePath;
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "LuaTests", "core");
            path = Path.Combine (path, name + ".lua");
            return path;
        }

        void AssertString (string chunk)
        {
            string error = string.Empty;

            LuaStatus result = state.LoadString (chunk);

            if (result != LuaStatus.OK)
                error = state.ToString(1);

            Assert.True (result == LuaStatus.OK, "Fail loading string: " + chunk + "ERROR:" + error);

            result = state.PCall (0, -1, 0);

            if (result != 0)
                error = state.ToString(1);

            Assert.True (result == 0, "Fail calling chunk: " + chunk + " ERROR: " + error);
        }

        void AssertFile (string path)
        {
            string error = string.Empty;

            LuaStatus result = state.LoadFile (path);

            if (result != LuaStatus.OK)
                error = state.ToString(1);

            Assert.True (result == LuaStatus.OK, "Fail loading file: " + path +  "ERROR:" + error);
            
            result =  state.PCall (0, -1, 0);

            if (result != LuaStatus.OK)
                error = state.ToString(1);

            Assert.True (result == LuaStatus.OK, "Fail calling file: " + path + " ERROR: " + error);
        }

        void TestLuaFile (string name)
        {
            string path = GetTestPath (name);
            AssertFile (path);
        }

        [SetUp]
        public void Setup()
        {
            state = new Lua();
            state.PushCFunction (func_print);
            state.SetGlobal ("print");
        }

        [TearDown]
        public void TearDown ()
        {
            state.Close();
            state = null;
        }

        [Test]
        public void Bisect ()
        {
            TestLuaFile ("bisect");
        }

        [Test]
        public void CF ()
        {
            TestLuaFile ("cf");
        }


        [Test]
        public void Factorial ()
        {
            TestLuaFile ("factorial");
        }

        [Test]
        public void FibFor ()
        {
            TestLuaFile ("fibfor");
        }

        [Test]
        public void Fib ()
        {
            TestLuaFile ("fib");
        }

        [Test]
        public void Life ()
        {
            TestLuaFile ("life");
        }

        [Test]
        public void Printf ()
        {
            TestLuaFile ("printf");
        }


        [Test]
        public void Sieve ()
        {
            TestLuaFile ("sieve");
        }

        [Test]
        public void Sort ()
        {
            TestLuaFile ("sort");
        }


        [Test]
        public void TestUnicodeString ()
        {
            state.Encoding = Encoding.UTF8;
            state.PushCFunction (FuncTestUnicodeString);
            state.SetGlobal ("TestUnicodeString");
            state.PushString (UnicodeString);
            state.SetGlobal ("unicodeString");
            AssertString ("TestUnicodeString(unicodeString)");
        }
    }
}
