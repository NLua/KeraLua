using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using KeraLua;


namespace LuaSample
{
	public partial class LuaSampleViewController : UIViewController
	{
		IntPtr state;

		public LuaSampleViewController () : base ("LuaSampleViewController", null)
		{
			state = Lua.luaL_newstate ();
			Lua.luaL_openlibs (state);
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
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		[Action ("OnClickEval:")]
		void OnClickEval (MonoTouch.Foundation.NSObject sender)
		{
			int error = Lua.luaL_dostring (state, textView.Text);

			Console.WriteLine (" Executed: return code = " + error);
		}
	}
}

