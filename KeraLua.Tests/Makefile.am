
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = ../tests/KeraLua.Tests.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../src/bin/Debug/net40/KeraLua.dll
BUILD_DIR = ../tests/

KERALUA_TESTS_DLL_MDB_SOURCE=../tests/KeraLua.Tests.dll.mdb
KERALUA_TESTS_DLL_MDB=$(BUILD_DIR)/KeraLua.Tests.dll.mdb
NUNIT_FRAMEWORK_DLL_SOURCE=../lib/nunit/nunit.framework.dll
KERALUA_DLL_SOURCE=../src/bin/Debug/net40/KeraLua.dll
KERALUA_DLL_MDB_SOURCE=../src/bin/Debug/net40/KeraLua.dll.mdb
KERALUA_DLL_MDB=$(BUILD_DIR)/KeraLua.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = ../tests/KeraLua.Tests.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../src/bin/Release/net40/KeraLua.dll
BUILD_DIR = ../tests/

KERALUA_TESTS_DLL_MDB=
NUNIT_FRAMEWORK_DLL_SOURCE=../lib/nunit/nunit.framework.dll
KERALUA_DLL_SOURCE=../src/bin/Release/net40/KeraLua.dll
KERALUA_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(KERALUA_TESTS_DLL_MDB) \
	$(NUNIT_FRAMEWORK_DLL) \
	$(KERALUA_DLL) \
	$(KERALUA_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(KERALUA_TESTS_40_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	../tests/core.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	../tests/LuaTests/core/bisect.lua \
	../tests/LuaTests/core/cf.lua \
	../tests/LuaTests/core/env.lua \
	../tests/LuaTests/core/factorial.lua \
	../tests/LuaTests/core/fib.lua \
	../tests/LuaTests/core/fibfor.lua \
	../tests/LuaTests/core/life.lua \
	../tests/LuaTests/core/printf.lua \
	../tests/LuaTests/core/readonly.lua \
	../tests/LuaTests/core/sieve.lua \
	../tests/LuaTests/core/sort.lua \
	../tests/LuaTests/core/trace-globals.lua \
	packages.config \
	Properties \
	keralua.tests.40.pc.in 

REFERENCES =  \
	System \
	System.Core

DLL_REFERENCES =  \
	../lib/nunit/nunit.framework.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

NUNIT_FRAMEWORK_DLL = $(BUILD_DIR)/nunit.framework.dll
KERALUA_DLL = $(BUILD_DIR)/KeraLua.dll
KERALUA_TESTS_40_PC = $(BUILD_DIR)/keralua.tests.40.pc

$(eval $(call emit-deploy-target,NUNIT_FRAMEWORK_DLL))
$(eval $(call emit-deploy-target,KERALUA_DLL))
$(eval $(call emit-deploy-target,KERALUA_DLL_MDB))
$(eval $(call emit-deploy-wrapper,KERALUA_TESTS_40_PC,keralua.tests.40.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
