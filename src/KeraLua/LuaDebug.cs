using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
	public partial class Lua
	{
		public delegate void lua_Hook (lua_State L, lua_Debug ar);
		/// <summary>
		/// Structure for lua debug information
		/// </summary>
		/// <remarks>
		/// Do not change this struct because it must match the lua structure lua_debug
		/// </remarks>
		/// <author>Reinhard Ostermeier</author>
		[System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
		public struct lua_Debug
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
}
