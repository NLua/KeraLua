👋 Hello there! | 
------------ | 
> 🔭 Thank you for checking out this project.
>
> 🍻 We've made the project Open Source and **MIT** license so everyone can enjoy it. 
>
> 🛠 To deliver a project with quality we have to spent a lot of time working on it.
> 
> ⭐️ If you liked the project please star it.
>
> 💕 We also appreaciate any **Sponsor**  [ [Patreon](https://www.patreon.com/codefoco) | [PayPal](paypal.me/viniciusjarina) ] 

[![Logo](https://raw.githubusercontent.com/NLua/KeraLua/master/KeraLua.png)]()

KeraLua
=======


| NuGet |
| ------|
|[![nuget](https://badgen.net/nuget/v/KeraLua?icon=nuget)](https://www.nuget.org/packages/KeraLua)|

|  | Status | 
| :------ | :------: | 
|![linux](https://badgen.net/badge/icon/Ubuntu%20Linux%20x64?icon=travis&label&color=orange)   | [![Linux](https://travis-ci.org/NLua/KeraLua.svg?branch=master)](https://travis-ci.org/NLua/KeraLua) |
| ![win](https://badgen.net/badge/icon/Windows?icon=windows&label&color=blue) | [![Build status](https://ci.appveyor.com/api/projects/status/jkqcy9m9k35jwolx?svg=true)](https://ci.appveyor.com/project/viniciusjarina/keralua)|
| ![mac](https://badgen.net/badge/icon/macOS,iOS,tvOS,watchOS?icon=apple&label&color=purple&list=1) | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=master&jobName=Mac)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=master) |
|![linux](https://badgen.net/badge/icon/Ubuntu%20Linux%20x64?icon=terminal&label&color=orange)  | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=master&jobName=Linux)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=master) |
|![win](https://badgen.net/badge/icon/Windows,.NET%20Core?icon=windows&label&list=1) | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=master&jobName=Windows)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=master) |


C# Native bindings of Lua 5.4 (compatible with Xamarin.iOS/Mac/Android/.NET/.NET Core/UWP) 

Before build fetch the submodules:

	git submodule update --init --recursive


Building
---------

	nuget restore KeraLua.sln
	msbuild KeraLua.sln



