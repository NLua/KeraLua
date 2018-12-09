using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace KeraLua
{
	/// <summary>
	/// Structure for lua debug information
	/// </summary>
	/// <remarks>
	/// Do not change this struct because it must match the lua structure lua_Debug
	/// </remarks>
	/// <author>Reinhard Ostermeier</author>
	[StructLayout (LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct LuaDebug
	{
		public int eventCode;
		public string pname;
		public string pnamewhat;
		public string pwhat;
		public string psource;
		public int currentline;
		public int linedefined;
		public int lastlinedefined;
		public byte nups;
		public byte nparams;
		public char isvararg;        /* (u) */
		public char istailcall;	/* (t) */ 
		// char short_src[LUA_IDSIZE]; /* (S) */
		[MarshalAs (UnmanagedType.ByValTStr, SizeConst = 60)]
		public string short_src;
		IntPtr i_ci;
	}
}
