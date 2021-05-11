using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace KeraLua
{
#if NETFX_CORE
	public delegate void LuaHook (LuaState l, long ar);
#else
	public delegate void LuaHook (LuaState l, IntPtr ar);
#endif

	/// <summary>
	/// Structure for lua debug information
	/// </summary>
	/// <remarks>
	/// Do not change this struct because it must match the lua structure lua_debug
	/// </remarks>
	/// <author>Reinhard Ostermeier</author>
	[StructLayout (LayoutKind.Sequential, CharSet = CharSet.Ansi)]
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
		// char short_src[LUA_IDSIZE]; /* (S) */
		[MarshalAs (UnmanagedType.ByValTStr, SizeConst = 60)]
		public string short_src;
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
