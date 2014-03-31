call Makefile.Win32.bat
msbuild KeraLua.Net40.sln /p:Configuration=Release /p:DefineConstants=WSTRING /t:Rebuild
cd tests/
nunit-console KeraLua.Tests.dll
cd ..