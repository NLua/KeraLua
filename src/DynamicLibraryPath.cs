using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace KeraLua
{
	public static class DynamicLibraryPath
	{
		const string LD_LIBRARY_PATH = "LD_LIBRARY_PATH";

		static string GetAssemblyPath ()
		{
			string codeBase = Assembly.GetExecutingAssembly ().CodeBase;
			UriBuilder uri = new UriBuilder (codeBase);
			string path = Uri.UnescapeDataString (uri.Path);
			return Path.GetDirectoryName (path);
		}
		static public void RegisterPathForDll (string name)
		{
			string extension = GetDllExtension ();
			if (string.IsNullOrEmpty(extension))
				return;
			string dllName = name + extension;
			string assemblyPath = GetAssemblyPath ();
			string path = Path.Combine (assemblyPath, dllName);
			// If the .dll already exists in the current assembly path
			// don't try register another path
			if (File.Exists (path))
				return;

			if (IntPtr.Size == 8)
				Register64bitPath (assemblyPath, dllName);
			else
				Register32bitPath (assemblyPath, dllName);
		}

		static void Register64bitPath (string assemblyPath, string dllName)
		{
			string x64path = Path.Combine (assemblyPath, "x64");
			if (Directory.Exists (x64path) && File.Exists (Path.Combine (x64path, dllName))) {
				RegisterLibrarySearchPath (x64path);
				return;
			}

			x64path = Path.Combine (assemblyPath, "amd64");
			if (Directory.Exists (x64path) && File.Exists (Path.Combine (x64path, dllName)))
				RegisterLibrarySearchPath (x64path);
		}

		static void Register32bitPath (string assemblyPath, string dllName)
		{
			string x86path = Path.Combine (assemblyPath, "x86");
			if (Directory.Exists (x86path) && File.Exists (Path.Combine (x86path, dllName))) {
				RegisterLibrarySearchPath (x86path);
				return;
			}

			x86path = Path.Combine (assemblyPath, "i386");
			if (Directory.Exists (x86path) && File.Exists (Path.Combine (x86path, dllName)))
				RegisterLibrarySearchPath (x86path);			
		}

		static string GetDllExtension ()
		{
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.Win32Windows:
					return ".dll";
				case PlatformID.Unix:
					return ".so";
				case PlatformID.MacOSX:
					return ".dylib";
			}
			return null;
		}

		static void RegisterLibrarySearchPath (string path)
		{
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.Win32Windows:
					SetDllDirectory (path);
					break;
				case PlatformID.Unix:
				case PlatformID.MacOSX:
					string currentLdLibraryPath = Environment.GetEnvironmentVariable (LD_LIBRARY_PATH) ?? string.Empty;
					string newLdLibraryPath = string.IsNullOrEmpty (currentLdLibraryPath) ? path : currentLdLibraryPath + Path.PathSeparator + path;
					Environment.SetEnvironmentVariable (LD_LIBRARY_PATH, newLdLibraryPath);
					break;
			}
		}

		[DllImport ("kernel32", SetLastError = true)]
		static extern bool SetDllDirectory (string lpPathName);
	}
}
