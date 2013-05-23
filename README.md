KeraLua
=======

[![Build Status](https://travis-ci.org/NLua/KeraLua.png?branch=master)](https://travis-ci.org/NLua/KeraLua)

C# KopiLua compatible API for native bindings of Lua/LuaJIT (compatible with iOS/Mac/Android/.NET)

Before build fetch the submodules:

	git submodule update --init --recursive

  *  Contributing
--------------
 * KeraLua is using the Mono Code-Style http://www.mono-project.com/Coding_Guidelines .
 * Please, do not change the line-end or re-indent the code.
 * Run the tests before push.
 * Avoid to push unneeded style changes (unless is really needed) renaming, move code.


iOS Build
---------
On the Mac/Terminal:


	make -f Makefile.iOS

Windows Build
--------------

You will need the [CMake](http://cmake.org) to build the Lua library.

On Command Prompt:

	Makefile.Win32.bat
	msbuild KeraLua.sln /p:Configuration=Release

