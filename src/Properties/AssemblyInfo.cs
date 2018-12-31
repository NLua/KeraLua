using System.Reflection;

#if __MACOS__ || __TVOS__ || __WATCHOS__ || __IOS__

using Foundation;
[assembly: LinkerSafe]

#endif

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("KeraLua")]
[assembly: AssemblyDescription ("Binding library for native Lua")]
[assembly: AssemblyCompany ("NLua")]
[assembly: AssemblyProduct ("KeraLua")]
[assembly: AssemblyCopyright ("Copyright © Vinicius Jarina 2019")]
[assembly: AssemblyCulture ("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0-refactor-lua53.1+151.Branch.refactor_lua53.Sha.ae132902650673d9fb13d49123e72892db94aa55")]
[assembly: AssemblyFileVersion("0.1.0.0")]



//[assembly: AssemblyDelaySign(false)]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyKeyFile("")]

