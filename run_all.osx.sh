#!/bin/sh
make -f Makefile.OSX
xbuild KeraLua.Net40.sln /p:Configuration=Release
cd tests/
nunit-console KeraLua.Tests.dll
