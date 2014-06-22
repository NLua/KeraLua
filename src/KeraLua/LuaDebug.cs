using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public delegate void LuaHook (LuaState l, IntPtr ar);

	/// <summary>
	/// Structure for lua debug information
	/// </summary>
	/// <remarks>
	/// Do not change this struct because it must match the lua structure lua_debug
	/// </remarks>
	/// <author>Reinhard Ostermeier</author>
	[System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
	public struct LuaDebug
	{
		public int eventCode;
		IntPtr pname;
		IntPtr pnamewhat;
		IntPtr pwhat;
		IntPtr psource;
		public int currentline;
		public int linedefined;
		public int lastlinedefined;
		byte nups;
		byte nparams;
		char isvararg;        /* (u) */
		char istailcall;	/* (t) */
		IntPtr pshortsrc;
		IntPtr i_ci;

		public string name
		{
			get
			{
				return new CharPtr (pname).ToString ();
			}
		}

		public string namewhat
		{
			get
			{
				return new CharPtr (pname).ToString ();
			}
		}

		public string source
		{
			get
			{
				return new CharPtr (pname).ToString ();
			}
		}

		public string shortsrc
		{
			get
			{
				return new CharPtr (pname).ToString ();
			}
		}

	}
}
