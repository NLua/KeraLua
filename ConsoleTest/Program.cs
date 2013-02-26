using System;
using System.Collections.Generic;
using System.Text;
using KeraLua;
using System.IO;
using KeraLua.Tests;

namespace ConsoleTest
{
	class Program
	{

		static void Main (string [] args)
		{
			var task = System.Threading.Tasks.Task.Factory.StartNew (TestAll);
			task.Wait ();
		}

		static void TestAll ()
		{
			var tests = new core ();
			tests.Bisect ();
			tests.CF ();
			tests.Env ();
			tests.Life ();
			tests.Factorial ();
			tests.FibFor ();
			tests.Printf ();
			tests.Sieve ();
			tests.Sort ();
			tests.TraceGlobals ();
		}
	}
}
