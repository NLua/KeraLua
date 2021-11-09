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

[![Logo](https://raw.githubusercontent.com/NLua/KeraLua/main/KeraLua.png)]()

KeraLua
=======


| NuGet |
| ------|
|[![nuget](https://badgen.net/nuget/v/KeraLua?icon=nuget)](https://www.nuget.org/packages/KeraLua)|

|  | Status | 
| :------ | :------: | 
|![linux](https://badgen.net/badge/icon/Ubuntu%20Linux%20x64?icon=travis&label&color=orange)   | [![Linux](https://travis-ci.org/NLua/KeraLua.svg?branch=main)](https://travis-ci.org/NLua/KeraLua) |
| ![win](https://badgen.net/badge/icon/Windows?icon=windows&label&color=blue) | [![Build status](https://ci.appveyor.com/api/projects/status/jkqcy9m9k35jwolx?svg=true)](https://ci.appveyor.com/project/viniciusjarina/keralua)|
| ![mac](https://badgen.net/badge/icon/macOS,iOS,tvOS,watchOS?icon=apple&label&color=purple&list=1) | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=main&jobName=Mac)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=main) |
|![linux](https://badgen.net/badge/icon/Ubuntu%20Linux%20x64?icon=terminal&label&color=orange)  | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=main&jobName=Linux)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=main) |
|![win](https://badgen.net/badge/icon/Windows,.NET%20Core?icon=windows&label&list=1) | [![Build Status](https://dev.azure.com/codefoco/NuGets/_apis/build/status/KeraLua?branchName=main&jobName=Windows)](https://dev.azure.com/codefoco/NuGets/_build/latest?definitionId=64&branchName=main) |


C# Native bindings of Lua 5.4 (compatible with iOS/Mac/Android/UWP/.NET) 

Before build fetch the submodules:

	git submodule update --init --recursive

Building
---------

KeraLua uses several solution for different targets. (I know I could use SDK style project + multi-target, but neither VS and VS4Mac work very well with that, and the intelisense always get confused).
So for Mac,iOS,tvOS use KeraLua.Mac.sln, Android KeraLua.Android.sln, .NET Core KeraLua.Core.sln and UWP KeraLua.UWP.sln

To build old classic .NET 4.5 just use the KeraLua.sln. (I usually do my develoment on .NET 4.5 using VS4Mac + Mono on Mac, and .NET + VS on Windows, since this was the configuration which cause less issues to me.)


	nuget restore KeraLua.sln
	msbuild KeraLua.sln



