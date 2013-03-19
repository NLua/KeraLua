
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
		[System.Runtime.InteropServices.AllowReversePInvokeCalls]
		static int print (Lua.lua_State state)
		{
			IntPtr L = state;
			int n = Lua.lua_gettop(L);  /* number of arguments */
			int i;
			uint len;
			for (i=1; i<=n; i++) {
				int type = Lua.lua_type(L, i);
				switch (type) {
						
					case 0:
						Console.Write("nil");
						break;
					case 4:
						string s = Lua.lua_tolstring (L, i, out len).ToString ((int)len);
						Console.Write(s);
						break;
					case 3:
						double number = Lua.lua_tonumber (L, i);
						Console.Write (number);
						break;
				}
			}
			Console.WriteLine();
			return 0;
		}

		public static Lua.lua_CFunction func_print = print;

		Lua.lua_State state;
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
				uint len;
				error = Lua.lua_tolstring (state, 1, out len).ToString ((int)len);
			}

			Assert.True (result == 0, "Fail loading file: " + path +  "ERROR:" + error);
			
			result =  Lua.lua_pcall (state, 0, -1, 0);

			if (result != 0) {
				uint len;
				error = Lua.lua_tolstring (state, 1, out len).ToString((int)len);
			}


			Assert.True (result == 0, "Fail calling file: " + path + " ERROR: " + error);
		}

		void TestLuaFile (string name)
		{
			string path = GetTestPath (name);
			AssertFile (path);
		}


		public void Setup()
		{
			state = Lua.luaL_newstate ();
			Lua.luaL_openlibs (state);
			Lua.lua_pushcfunction (state,  core.func_print);
			Lua.lua_pushstring(state, "print");
			Lua.lua_insert(state, -2);
			Lua.lua_settable(state, (int)-10002);
			
		}

		public void TearDown ()
		{
			Lua.lua_close (state);
			state = IntPtr.Zero;
		}

		[Test]
		public void Bisect ()
		{
			Setup();
			TestLuaFile ("bisect");
			TearDown ();
		}

		[Test]
		public void CF ()
		{
			Setup ();
			TestLuaFile ("cf");
			TearDown ();
		}

		[Test]
		public void Env ()
		{
			Setup ();
			TestLuaFile ("env");
			TearDown ();
		}

		[Test]
		public void Factorial ()
		{
			Setup ();
			TestLuaFile ("factorial");
			TearDown ();
		}

		[Test]
		public void FibFor ()
		{
			Setup ();
			TestLuaFile ("fibfor");
			TearDown ();
		}

		[Test]
		public void Life ()
		{
			Setup ();
			TestLuaFile ("life");
			TearDown ();
		}

		[Test]
		public void Printf ()
		{
			Setup ();
			TestLuaFile ("printf");
			TearDown ();
		}

		[Test]
		public void ReadOnly ()
		{
			Setup ();
			TestLuaFile ("readonly");
			TearDown ();

		}

		[Test]
		public void Sieve ()
		{
			Setup ();
			TestLuaFile ("sieve");
			TearDown ();
		}

		[Test]
		public void Sort ()
		{
			Setup ();
			TestLuaFile ("sort");
			TearDown ();
		}

		[Test]
		public void TraceGlobals ()
		{
			Setup ();
			TestLuaFile ("trace-globals");
			TearDown ();
		}
	}
}
