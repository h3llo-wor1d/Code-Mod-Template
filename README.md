# Celeste 64 Fuji Code Mod Template
This is a Template for a code mod for the Celeste 64 Fuji Mod Loader. This template gives you a basic C# project that can be compiled into a code mod.

## Preparing for code modding
This template is built to not care about where you put it, however there's two things to note:

1. The most convenient solution is putting the template inside your Fuji installation's `Mods` folder. This allows your editor to seek out the Celeste64 binary and enables hot reloading with no extra effort on your part.
2. If you choose to develop elsewhere, then:
- Set an environment variable `FujiDir` pointing to the location of a Fuji installation
- Or, if you feel like it, paste the `Celeste64.dll` directly into your mod's `Source` folder.
- Hot reloading will not work unless you take the care to set up a symlink yourself.

## Editing the template
In `Source/FujiCodeMod.csproj`, we recommend that you set the `AssemblyName` property to the name/ID of your mod.

In `Fuji.json`, edit all of the fields to match the details of your mod.

This file (`README.md`) may be edited or deleted.

## Building and Publishing
To build the mod, build your project (In CLI: `dotnet build`). You should see the mod DLL pop up in `Libraries`, and assuming everything's set up correctly, Fuji will hot reload the mod.

To prepare your mod for release, publish your project (In CLI: `dotnet publish`). This will output a release-ready version of your mod to the `Release` directory. You may zip this folder and send it off right away! (though, make sure to delete any files you don't want first.)

> [!TIP]
> If you wish to preserve the source code of the mod when releasing it, pass the `PreserveSource` property with a value of `Yes`. e.g. `dotnet publish -property:PreserveSource=Yes`
> 
> The `bin` and `obj` folders will be removed automatically for you.

Note: This template is still a work in progress, and may change and evolve over time.