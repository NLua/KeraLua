
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:TRACE;DEBUG" "-keyfile:key.snk"
ASSEMBLY = bin/Debug/net40/KeraLua.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/net40/

KERALUA_DLL_MDB_SOURCE=bin/Debug/net40/KeraLua.dll.mdb
KERALUA_DLL_MDB=$(BUILD_DIR)/KeraLua.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-keyfile:key.snk"
ASSEMBLY = bin/Release/net40/KeraLua.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/net40/

KERALUA_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(KERALUA_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(KERALUA_NET40_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	KeraLua/CharPtr.cs \
	KeraLua/DynamicLibraryPath.cs \
	KeraLua/Lua.cs \
	KeraLua/LuaDebug.cs \
	KeraLua/LuaState.cs \
	KeraLua/LuaTag.cs \
	KeraLua/NativeMethods.cs \
	KeraLua/Properties/AssemblyInfo.cs \
	KeraLua/Platform/CLSCompliantAttribute.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	key.snk \
	keralua.net40.pc.in 

REFERENCES =  \
	System \
	System.Core

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

KERALUA_NET40_PC = $(BUILD_DIR)/keralua.net40.pc

$(eval $(call emit-deploy-wrapper,KERALUA_NET40_PC,keralua.net40.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
