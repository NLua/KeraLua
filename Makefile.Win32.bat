cd external/lua
mkdir win32
cd win32
cmake ..
cmake --build . --config Release
copy "bin\lua51.dll" "..\..\..\tests\lua51.dll"
