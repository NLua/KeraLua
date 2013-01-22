#!/bin/sh
# If you have mono x86 installed on a amd64 linux.
#export CFLAGS=-m32
#export CXXFLAGS=-m32
#export LDFLAGS=-m32
make -f Makefile.Linux
#export LD_LIBRARY_PATH=$PWD/external/lua/linux/lib64
export LD_LIBRARY_PATH=$PWD/external/lua/linux/lib
xbuild KeraLua.sln /p:Configuration=Release
cd tests/
nunit-console KeraLua.Tests.dll
