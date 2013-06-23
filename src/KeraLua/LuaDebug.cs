using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public delegate void LuaHook (LuaState l, LuaDebug ar);

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
		[System.Runtime.InteropServices.MarshalAs (System.Runtime.InteropServices.UnmanagedType.LPStr)]
		public String name;
		[System.Runtime.InteropServices.MarshalAs (System.Runtime.InteropServices.UnmanagedType.LPStr)]
		public String namewhat;
		[System.Runtime.InteropServices.MarshalAs (System.Runtime.InteropServices.UnmanagedType.LPStr)]
		public String what;
		[System.Runtime.InteropServices.MarshalAs (System.Runtime.InteropServices.UnmanagedType.LPStr)]
		public String source;
		public int currentline;
		public int nups;
		public int linedefined;
		public int lastlinedefined;
		[System.Runtime.InteropServices.MarshalAs (System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 60/*LUA_IDSIZE*/)]
		public String shortsrc;
		public int i_ci;
	}
}
