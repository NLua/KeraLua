call Makefile.Win64.bat
msbuild KeraLua.Net45.sln /p:Configuration=ReleaseWin /t:Rebuild
cd tests/
nunit-console KeraLua.Tests.dll
cd ..