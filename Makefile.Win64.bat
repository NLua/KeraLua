cd external/lua
mkdir win64
cd win64
cmake .. -G "Visual Studio 11 Win64"
cmake --build . --config Release
copy "bin64\lua52.dll" "..\..\..\tests\lua52.dll"
cd ../../..
