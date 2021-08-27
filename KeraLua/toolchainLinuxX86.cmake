# the name of the target operating system
set(CMAKE_SYSTEM_NAME Linux)

# which compilers to use for C and C++
set(CMAKE_C_COMPILER gcc)
set(CMAKE_C_FLAGS -m32)
set(CMAKE_CXX_COMPILER g++)
set(CMAKE_CXX_FLAGS -m32)

set(CMAKE_EXE_LINKER_FLAGS -m32)
set(CMAKE_MODULE_LINKER_FLAGS -m32)
set(CMAKE_SHARED_LINKER_FLAGS -m32)
# set(CMAKE_STATIC_LINKER_FLAGS -m32)