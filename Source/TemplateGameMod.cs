namespace FujiCodeMod;

using Celeste64;
using Celeste64.Mod;
using Foster.Framework;

// For code mods, you must have a class extending from Fuji's GameMod class. This is the entry point of your mod.
// Rename this class and file to better reflect your own mod.
public class TemplateGameMod : GameMod
{
	// This template includes some common functions:
	public override void OnModLoaded()
	{
		// Runs when the mod is loaded.
		Log.Info($"Hello from {GetType()}");
	}

	public override void OnModUnloaded()
	{
		// Runs when the mod is unloaded.
	}

	public override void OnGameLoaded(Game game)
	{
		// Runs when the game has finished loading.
	}

	public override void Update(float deltaTime)
	{
		// Runs every frame.
	}
}
