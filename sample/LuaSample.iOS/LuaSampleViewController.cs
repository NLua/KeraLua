using System;
using System.Drawing;

using Foundation;
using UIKit;

using KeraLua;
using ObjCRuntime;


namespace LuaSample
{
	public partial class LuaSampleViewController : UIViewController
	{
		IntPtr state;
		public static LuaNativeFunction g_print = print;

		public void lua_setglobal(string name)
		{
			Lua.LuaNetSetGlobal (state,name);
		}

		public LuaSampleViewController () : base ("LuaSampleViewController", null)
		{
			state = Lua.LuaLNewState ();
			Lua.LuaLOpenLibs (state);
			Lua.LuaPushStdCallCFunction (state, print);
			lua_setglobal ("print");
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		[Action ("OnClickEval:")]
		void OnClickEval (NSObject sender)
		{
			int error = DoString (textView.Text);

			Console.WriteLine (" Executed: return code = " + error);
		}

		[MonoPInvokeCallback (typeof (LuaNativeFunction))]
		static int print (LuaState L)
		{
			int n = Lua.LuaGetTop(L);  /* number of arguments */
			int i;
			uint len;
			for (i=1; i<=n; i++) {
				string s = Lua.LuaToLString (L, i, out len).ToString ((int)len);
				Console.Write (s);
			}
			Console.WriteLine();
			return 0;
		}

		public int DoString(string chunk)
		{
			int result = Lua.LuaLLoadString(state, chunk);
			if(result != 0)
				return result;
			
			return Lua.LuaNetPCall(state, 0, -1, 0);
		}
	}
}

