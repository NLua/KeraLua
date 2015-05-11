using System;
using ObjCRuntime;
using System.Reflection;

[assembly: CLSCompliantAttribute (true)]
[assembly: LinkWith("libLua52iOS.a", LinkTarget.Thumb |LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s, Frameworks = "Foundation", ForceLoad = true, IsCxx = true, LinkerFlags = "-lstdc++")]
[assembly: AssemblyTitle ("KeraLua")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("")]
[assembly: AssemblyProduct ("KeraLua")]
[assembly: AssemblyCopyright ("Copyright ©  2015 Vinicius Jarina")]
[assembly: AssemblyVersion ("1.3.2.1")]
[assembly: AssemblyFileVersion ("1.3.2.1")]