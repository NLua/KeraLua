using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libLua51iOS.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "Foundation", ForceLoad = true, IsCxx = true)]
