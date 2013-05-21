
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = ../tests/ConsoleTest.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../src/bin/Debug/KeraLua.dll \
	../tests/KeraLua.Tests.dll
BUILD_DIR = ../tests/

CONSOLETEST_EXE_MDB_SOURCE=../tests/ConsoleTest.exe.mdb
CONSOLETEST_EXE_MDB=$(BUILD_DIR)/ConsoleTest.exe.mdb
CONSOLETEST_EXE_CONFIG_SOURCE=App.config
KERALUA_DLL_SOURCE=../src/bin/Debug/KeraLua.dll
KERALUA_DLL_MDB_SOURCE=../src/bin/Debug/KeraLua.dll.mdb
KERALUA_DLL_MDB=$(BUILD_DIR)/KeraLua.dll.mdb
KERALUA_TESTS_DLL_SOURCE=../tests/KeraLua.Tests.dll
KERALUA_TESTS_DLL_MDB_SOURCE=../tests/KeraLua.Tests.dll.mdb
KERALUA_TESTS_DLL_MDB=$(BUILD_DIR)/KeraLua.Tests.dll.mdb
NUNIT_FRAMEWORK_DLL_SOURCE=../lib/nunit/nunit.framework.dll

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = ../tests/ConsoleTest.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../src/bin/Release/KeraLua.dll \
	../tests/KeraLua.Tests.dll
BUILD_DIR = ../tests/

CONSOLETEST_EXE_MDB=
CONSOLETEST_EXE_CONFIG_SOURCE=App.config
KERALUA_DLL_SOURCE=../src/bin/Release/KeraLua.dll
KERALUA_DLL_MDB=
KERALUA_TESTS_DLL_SOURCE=../tests/KeraLua.Tests.dll
KERALUA_TESTS_DLL_MDB=
NUNIT_FRAMEWORK_DLL_SOURCE=../lib/nunit/nunit.framework.dll

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(CONSOLETEST_EXE_MDB) \
	$(CONSOLETEST_EXE_CONFIG) \
	$(KERALUA_DLL) \
	$(KERALUA_DLL_MDB) \
	$(KERALUA_TESTS_DLL) \
	$(KERALUA_TESTS_DLL_MDB) \
	$(NUNIT_FRAMEWORK_DLL)  

BINARIES = \
	$(CONSOLETEST)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Program.cs \
	Properties/AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	App.config \
	consoletest.in 

REFERENCES =  \
	System \
	System.Core \
	System.Data

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

CONSOLETEST_EXE_CONFIG = $(BUILD_DIR)/ConsoleTest.exe.config
KERALUA_DLL = $(BUILD_DIR)/KeraLua.dll
KERALUA_TESTS_DLL = $(BUILD_DIR)/KeraLua.Tests.dll
NUNIT_FRAMEWORK_DLL = $(BUILD_DIR)/nunit.framework.dll
CONSOLETEST = $(BUILD_DIR)/consoletest

$(eval $(call emit-deploy-target,CONSOLETEST_EXE_CONFIG))
$(eval $(call emit-deploy-target,KERALUA_DLL))
$(eval $(call emit-deploy-target,KERALUA_DLL_MDB))
$(eval $(call emit-deploy-target,NUNIT_FRAMEWORK_DLL))
$(eval $(call emit-deploy-wrapper,CONSOLETEST,consoletest,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
