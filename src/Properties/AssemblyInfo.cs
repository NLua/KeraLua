using System.Reflection;

#if __MACOS__ || __TVOS__ || __WATCHOS__ || __IOS__

using Foundation;
[assembly: LinkerSafe]
#endif

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

#if NETFRAMEWORK
[assembly: AssemblyTitle ("KeraLua (.NET Framework 4.5)")]
#elif __ANDROID__
[assembly: AssemblyTitle ("KeraLua (Xamarin.Android)")]
#elif NETCOREAPP
[assembly: AssemblyTitle ("KeraLua (.NET Core)")]
#elif NETSTANDARD
[assembly: AssemblyTitle ("KeraLua (.NET Standard)")]
#elif __TVOS__
[assembly: AssemblyTitle ("KeraLua (Xamarin.tvOS)")]
#elif __WATCHOS__
[assembly: AssemblyTitle ("KeraLua (Xamarin.watchOS)")]
#elif __IOS__
[assembly: AssemblyTitle ("KeraLua (Xamarin.iOS)")]
#elif __MACOS__
[assembly: AssemblyTitle ("KeraLua (Xamarin.Mac)")]
#else
[assembly: AssemblyTitle ("KeraLua (.NET Framework)")]
#endif

[assembly: AssemblyDescription ("Binding library for native Lua")]
[assembly: AssemblyCompany ("NLua")]
[assembly: AssemblyProduct ("KeraLua")]
[assembly: AssemblyCopyright ("Copyright © Vinicius Jarina 2019")]
[assembly: AssemblyCulture ("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0+150.Branch.master.Sha.ca40319e10f4d138a12cb477e5f5f556347c2629")]
[assembly: AssemblyFileVersion("0.1.0.0")]

