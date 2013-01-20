#!/bin/sh
make -f Makefile.OSX
xbuild KeraLua.sln /p:Configuration=Release
cd tests/
nunit-console KeraLua.Tests.dll
