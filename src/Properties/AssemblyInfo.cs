using System.Reflection;

#if __MACOS__ || __TVOS__ || __WATCHOS__ || __IOS__

using Foundation;

#if NET
[assembly: AssemblyMetadata ("IsTrimmable", "True")]
#else
[assembly: LinkerSafe]
#endif

#endif

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

#if NETFRAMEWORK
[assembly: AssemblyTitle ("KeraLua (.NET Framework 4.6)")]
#elif WINDOWS_UWP
[assembly: AssemblyTitle ("KeraLua (Windows Universal)")]
#elif __ANDROID__
[assembly: AssemblyTitle ("KeraLua (Android)")]
#elif NETCOREAPP
[assembly: AssemblyTitle ("KeraLua (.NET Core)")]
#elif NETSTANDARD
[assembly: AssemblyTitle ("KeraLua (.NET Standard)")]
#elif __TVOS__
[assembly: AssemblyTitle ("KeraLua (tvOS)")]
#elif __WATCHOS__
[assembly: AssemblyTitle ("KeraLua (watchOS)")]
#elif __IOS__
[assembly: AssemblyTitle ("KeraLua (iOS)")]
#elif __MACOS__
[assembly: AssemblyTitle ("KeraLua (Mac)")]
#else
#error "Unknow platform build"
#endif

[assembly: AssemblyDescription ("Binding library for native Lua")]
[assembly: AssemblyCompany ("NLua")]
[assembly: AssemblyProduct ("KeraLua")]
[assembly: AssemblyCopyright ("Copyright © Vinicius Jarina 2021")]
[assembly: AssemblyCulture ("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.16.0")]
[assembly: AssemblyInformationalVersion("1.0.16+Branch.main.Sha.36a5ab85f9b3be028d4885b0f0d45cc3b2cc854f")]
[assembly: AssemblyFileVersion("1.0.16.0")]

