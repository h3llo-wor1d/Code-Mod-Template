# Celeste 64 Fuji Code Mod Template
This is a Template that can be used to create a code mod for the Celeste 64 Fuji Mod Loader. This template gives you a basic C# project that can be compiled into a code mod which can be loaded by Fuji.

## Clone the template
To get started, you may either `git clone` the template, or click the green "Use this template" button on the repository home page [(direct link)](https://github.com/new?template_name=Code-Mod-Template&template_owner=FujiAPI) to add it as a repository on your GitHub account.

If you do not wish to use git, you can also just [download this template project as a zip](https://github.com/FujiAPI/Code-Mod-Template/archive/refs/heads/main.zip), and put the unzipped version into your mod folder.

## Preparing for code modding
This template is built to not care about where you put it, however there's two things to note:

1. The most convenient solution is putting the template inside your Fuji installation's `Mods` folder. This allows your editor to seek out the Celeste64 binary and enables hot reloading with no extra effort on your part.
2. If you choose to develop elsewhere, then:
- Set an environment variable `FujiDir` pointing to the location of a Fuji installation
- Or, if you feel like it, paste the `Celeste64.dll` directly into your mod's `Source` folder.
- Hot reloading will not work unless you take the care to set up a symlink yourself.

## Editing the template

Make sure the root folder for your mod is renamed to have a unique name that represents your mod.

Rename the `Source/FujiCodeMod.csproj` file to match the name of your mod.

Inside the csproj file, we recommend that you set the `AssemblyName` property to the name/ID of your mod.

Rename the `Source/TemplateGameMod.cs` file to a name that better represents your mod (i.e. MyModGameMod.cs). Rename the class inside the file to match it as well.

Delete or Rename the `Source/TemplateModSettings.cs` file depending on if your mod will have settings to let thee player configure things.

In `Fuji.json`, edit all of the fields to match the details of your mod.

This file (`README.md`) may be edited or deleted. By default, it will be excluded from the published version of your mod.

## Building and Publishing
To build the mod, build your project (In CLI: `dotnet build` from the Source folder). You should see the mod DLL pop up in `Libraries`, and assuming everything's set up correctly, Fuji will hot reload the mod.

To prepare your mod for release, publish your project (In CLI: `dotnet publish` from the Source folder). This will output a zipped version of your mod that is ready to release. Feel free to rename the zip, and consider looking through the files in the zip to delete any extra files you don't want included.

> [!TIP]
> If you wish to preserve the source code of the mod when releasing it, pass the `PreserveSource` property with a value of `Yes`. e.g. `dotnet publish -property:PreserveSource=Yes`
>
> If you do preserve the source code, the `bin`, `obj`, and `.vs` folders will be removed automatically for you.

By default, the .git folder, the .gitignore file, and the README.md file will also be excluded from your zipped mod after publishing it.

Note: This template is still a work in progress, and may change and evolve over time.
