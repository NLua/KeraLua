cd external/lua
mkdir win32
cd win32
cmake ..
cmake --build . --config Release
copy "bin\lua52.dll" "..\..\..\tests\lua52.dll"
cd ../../..
