
using System;
using NUnit.Framework;
using System.IO;
using KeraLua;

namespace KeraLua.Tests
{
	[TestFixture]
	public class core
	{
#if MONOTOUCH
		[MonoTouch.MonoPInvokeCallback (typeof (Lua.lua_CFunction))]
#endif
		static int print (IntPtr L)
		{
			int n = Lua.lua_gettop(L);  /* number of arguments */
			int i;
			int len;
			for (i=1; i<=n; i++) {
				IntPtr pstring = Lua.lua_tolstring (L, i, out len);
				if (pstring == IntPtr.Zero)
					continue;
				string s =  System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pstring, len);
				
				Console.WriteLine (s);
			}
			Console.WriteLine();
			return 0;
		}

		IntPtr state;
		string GetTestPath(string name)
		{
			string filePath = Path.Combine (Path.Combine ("LuaTests", "core"), name + ".lua");
			return filePath;
		}

		void AssertFile (string path)
		{
			string error = string.Empty;

			int result = Lua.luaL_loadfile (state, path);

			if (result != 0) {
				int len;
				IntPtr pstring = Lua.lua_tolstring (state, 1, out len);
				if (pstring != IntPtr.Zero)
					error =  System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pstring, len);
			}

			Assert.True (result == 0, "Fail loading file: " + path +  "ERROR:" + error);
			
			result =  Lua.lua_pcall (state, 0, -1, 0);

			if (result != 0) {
				int len;
				IntPtr pstring = Lua.lua_tolstring (state, 1, out len);
				if (pstring != IntPtr.Zero)
					error =  System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pstring, len);
			}


			Assert.True (result == 0, "Fail calling file: " + path + " ERROR: " + error);
		}

		void TestLuaFile (string name)
		{
			string path = GetTestPath (name);
			AssertFile (path);
		}


		[SetUp]
		public void Setup()
		{
			state = Lua.luaL_newstate ();
			Lua.luaL_openlibs (state);
			Lua.lua_pushcfunction (state, print);
			Lua.lua_pushstring (state, "print");
			Lua.lua_insert (state, -2);
			Lua.lua_settable (state, (int)-10002);
		}

		[TearDown]
		public void TearDown ()
		{
			Lua.lua_close (state);
			state = IntPtr.Zero;
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
		public void Env ()
		{
			TestLuaFile ("env");
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
		public void ReadOnly ()
		{
			TestLuaFile ("readonly");
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
		public void TraceGlobals ()
		{
			TestLuaFile ("trace-globals");
		}
	}
}
