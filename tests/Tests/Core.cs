
using System;
using System.Diagnostics;
using System.IO;

using NUnit.Framework;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
    using ObjCRuntime;
#endif

namespace KeraLua.Tests
{
    [TestFixture]
    public class Core
    {
        internal static LuaFunction func_print = Print;

#if __IOS__ || __TVOS__ || __WATCHOS__ || __MACCATALYST__
        [MonoPInvokeCallback (typeof (LuaFunction))]
#endif
        private static int Print(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            int n = state.GetTop();  /* number of arguments */
            int i;
            for (i = 1; i <= n; i++)
            {
                LuaType type = state.Type(i);
                switch (type)
                {

                    case LuaType.Nil:
                        Trace.Write("nil");
                        break;
                    case LuaType.String:
                        string s = state.ToString(i, false);
                        Trace.Write(s);
                        break;
                    case LuaType.Number:
                        double number = state.ToNumber(i);
                        Trace.Write(number);
                        break;
                    case LuaType.None:
                        break;
                    case LuaType.Boolean:
                        break;
                    case LuaType.LightUserData:
                        break;
                    case LuaType.Table:
                        break;
                    case LuaType.Function:
                        break;
                    case LuaType.UserData:
                        break;
                    case LuaType.Thread:
                        break;
                    default:
                        break;
                }
            }
            Trace.WriteLine("\n");
            return 0;
        }

        private Lua state;

        private string GetTestPath(string name)
        {
            string path = new Uri(GetType().Assembly.Location).AbsolutePath;
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "LuaTests", "core");
            path = Path.Combine(path, name + ".lua");
            return path;
        }

        private void AssertFile(string path)
        {
            string error = string.Empty;

            LuaStatus result = state.LoadFile(path);

            if (result != LuaStatus.OK)
                error = state.ToString(1);

            Assert.True(result == LuaStatus.OK, "Fail loading file: " + path + "ERROR:" + error);

            result = state.PCall(0, -1, 0);

            if (result != LuaStatus.OK)
                error = state.ToString(1);

            Assert.True(result == LuaStatus.OK, "Fail calling file: " + path + " ERROR: " + error);
        }

        private void TestLuaFile(string name)
        {
            string path = GetTestPath(name);
            AssertFile(path);
        }

        [SetUp]
        public void Setup()
        {
            state = new Lua();
            state.Register("print", func_print);
        }

        [TearDown]
        public void TearDown()
        {
            state.Close();
            state = null;
        }

        [Test]
        public void Bisect()
        {
            TestLuaFile("bisect");
        }

        [Test]
        public void CF()
        {
            TestLuaFile("cf");
        }


        [Test]
        public void Factorial()
        {
            TestLuaFile("factorial");
        }

        [Test]
        public void FibFor()
        {
            TestLuaFile("fibfor");
        }

        [Test]
        public void Fib()
        {
            TestLuaFile("fib");
        }

        [Test]
        public void Life()
        {
            TestLuaFile("life");
        }

        [Test]
        public void Printf()
        {
            TestLuaFile("printf");
        }


        [Test]
        public void Sieve()
        {
            TestLuaFile("sieve");
        }

        [Test]
        public void Sort()
        {
            TestLuaFile("sort");
        }
    }
}
