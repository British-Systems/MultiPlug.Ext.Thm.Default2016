# Creating a new .nupkg file

* Update AssemblyInfo.cs with new version numbers
* Build Release in Visual Studio
* Update MultiPlug.Ext.RasPi.Config.nuspec with new version numbers
* Run nuget pack Nuget/MultiPlug.Ext.Thm.Default2016.nuspec
* Upload it to https://www.nuget.org/ manually