using Celeste64;
using Celeste64.Mod;
using Foster.Framework;
using Buttplug.Core;
using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using Buttplug.Core.Messages;

namespace FujiCodeMod;

// For code mods, you must have a class extending from Fuji's GameMod class. This is the entry point of your mod.
// Rename this class and file to better reflect your own mod.
public class TemplateGameMod : GameMod
{
	// This template includes some common functions:
	public static ButtplugClient client = new ButtplugClient("Celsex64");
	public static ButtplugClientDevice device = null;
	public static string currentDevice;

	public static List<string> stringList = new List<string>();
	public static Dictionary<string, ButtplugClientDevice> DeviceList = new Dictionary<string, ButtplugClientDevice>();

	public static void HandleDeviceAdded(object aObj, DeviceAddedEventArgs aArgs)
	{
		Console.WriteLine($"Device connected: {aArgs.Device.Name}");
	}

    public static void HandleDeviceRemoved(object aObj, DeviceRemovedEventArgs aArgs)
	{
		Console.WriteLine($"Device connected: {aArgs.Device.Name}");
	}

	public static async Task ControlDevice(int index = 0, double strength = 1.0, int duration = 250)
	{
		Log.Info($"ControlDevice >> Sending command with strength {strength} to buttplug device {device.Name}");
		await device.VibrateAsync(strength);
		await Task.Delay(duration);
		await device.VibrateAsync(0);
	}

	public static async Task ScanForDevices()
	{
		Log.Info("ScanForDevices >> Scanning for devices");
		await client.StartScanningAsync();
		while (client.Devices.Length == 0) ;
		await client.StopScanningAsync();
		Log.Info("ScanForDevices >> Scan completed.");

		DeviceList = new Dictionary<string, ButtplugClientDevice>();
		stringList = new List<string>();

		foreach (var device in client.Devices)
		{
			Log.Info($"InitButtplug >> Device found: {device.Name}");
			DeviceList.Add(device.Name, device);
			stringList.Add(device.Name);
		}
		device = client.Devices[0];
		currentDevice = client.Devices[0].Name;
		
	}

	public static async Task InitButtplug()
	{
		client.DeviceAdded += HandleDeviceAdded;
		client.DeviceRemoved += HandleDeviceRemoved;

		await client.ConnectAsync(new ButtplugWebsocketConnector(new Uri("ws://127.0.0.1:12345")));
		await ScanForDevices();
	}

	public override void OnItemPickup(Player player, IPickup item)
	{
		Log.Info($"Player picked up item {item}");
		switch (item)
		{
			case Spring:
				Task.Run(async () => await ControlDevice(1, .75, 250));
				break;
		}
		base.OnItemPickup(player, item);
	}

	public override void OnModLoaded()
	{
		// Runs when the mod is loaded.
		Log.Info($"Hello from {GetType()}");
		Task.Run(async () => { await InitButtplug(); });
		
	}

	public override void OnModUnloaded()
	{
		// Runs when the mod is unloaded.
		client.Dispose();
		device = null;
	}

	public override void OnPlayerKilled(Player player)
	{
		base.OnPlayerKilled(player);
		Task.Run(async () => await ControlDevice(1,1,750));
	}
	public override void Update(float deltaTime)
	{
		// Runs every frame.
	}

	public override void OnPlayerJumped(Player player, Player.JumpType jumpType)
	{
		base.OnPlayerJumped(player, jumpType);
		if (jumpType == Player.JumpType.DashJumped)
		{
			Task.Run(async () => await ControlDevice(1, .25, 500));
		}
	}

	public override void OnPlayerLanded(Player player)
	{
		base.OnPlayerLanded(player);
	}


	public override void AddModSettings(ModOptionsMenu settingsMenu)
	{
		settingsMenu.Add(new Menu.Option((Loc.Unlocalized)RefreshText, () => {
			isRefreshing = !isRefreshing;
			if (isRefreshing) Task.Run(async () => await ScanForDevices());
		}));
		settingsMenu.Add(new Menu.OptionList((Loc.Unlocalized)"Select Device",
		() => stringList,
		() => currentDevice,
		(string newValue) => {
			currentDevice = newValue;
			device = DeviceList[newValue];
			Log.Info($"Changed current bp.io device to {newValue}");
		}));
	}
}
