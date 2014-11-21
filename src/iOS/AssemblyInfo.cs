using System;
using ObjCRuntime;
using System.Reflection;

[assembly: CLSCompliantAttribute (true)]
[assembly: LinkWith("libLua52iOS.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s, Frameworks = "Foundation", ForceLoad = true, IsCxx = true, LinkerFlags = "-lstdc++")]
[assembly: AssemblyTitle ("KeraLua")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("")]
[assembly: AssemblyProduct ("KeraLua")]
[assembly: AssemblyCopyright ("Copyright ©  2014 Vinicius Jarina")]
[assembly: AssemblyVersion ("1.3.1.0")]
[assembly: AssemblyFileVersion ("1.3.1.0")]