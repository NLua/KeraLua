#!/bin/sh
make -f Makefile.OSX
xbuild KeraLua.Net40.sln /p:Configuration=Release
cd tests/
export MONO_PATH="/Library/Frameworks/Mono.framework/Libraries/mono/4.0/"
nunit-console KeraLua.Tests.dll
