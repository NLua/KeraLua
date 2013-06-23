
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
		static int print (Lua.LuaState state)
		{
			IntPtr L = state;
			int n = Lua.LuaGetTop(L);  /* number of arguments */
			int i;
			uint len;
			for (i=1; i<=n; i++) {
				int type = Lua.LuaType(L, i);
				switch (type) {
						
					case 0:
						Console.Write("nil");
						break;
					case 4:
						string s = Lua.LuaToLString (L, i, out len).ToString ((int)len);
						Console.Write(s);
						break;
					case 3:
						double number = Lua.LuaNetToNumber (L, i);
						Console.Write (number);
						break;
				}
			}
			Console.WriteLine();
			return 0;
		}

		public static Lua.LuaNativeFunction func_print = print;

		Lua.LuaState state;
		string GetTestPath(string name)
		{
			string filePath = Path.Combine (Path.Combine ("LuaTests", "core"), name + ".lua");
			return filePath;
		}

		void AssertFile (string path)
		{
			string error = string.Empty;

			int result = Lua.LuaNetLoadFile (state, path);

			if (result != 0) {
				uint len;
				error = Lua.LuaToLString (state, 1, out len).ToString ((int)len);
			}

			Assert.True (result == 0, "Fail loading file: " + path +  "ERROR:" + error);
			
			result =  Lua.LuaNetPCall (state, 0, -1, 0);

			if (result != 0) {
				uint len;
				error = Lua.LuaToLString (state, 1, out len).ToString((int)len);
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
			state = Lua.LuaLNewState ();
			Lua.LuaLOpenLibs (state);
			Lua.LuaPushStdCallCFunction (state,  core.func_print);
			Lua.LuaNetSetGlobal (state, "print");			
		}

		public void TearDown ()
		{
			Lua.LuaClose (state);
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
		[Ignore]
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
		[Ignore]
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
		[Ignore]
		public void TraceGlobals ()
		{
			Setup ();
			TestLuaFile ("trace-globals");
			TearDown ();
		}
	}
}
