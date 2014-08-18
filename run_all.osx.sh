#!/bin/sh
make -f Makefile.OSX
xbuild KeraLua.Net45.sln /p:Configuration=Release
cd tests/
export MONO_PATH="/Library/Frameworks/Mono.framework/Libraries/mono/4.5/"
nunit-console KeraLua.Tests.dll
