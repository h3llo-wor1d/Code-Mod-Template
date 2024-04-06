using Celeste64.Mod;

namespace FujiCodeMod;

// This file allows you to provide custom mod settings that users can change to configure your mod.
// If you don't need it, you can simply delete it.
// If you do want to use it, rename the file and class to better represent your mod. The content inside is just for reference, and can be deleted.
// Every mod should only have a single settings file that defines its settings
public class TemplateModSettings : GameModSettings
{
	/* - Example Int Setting */
	//[SettingRange(0, 20)]
	//[SettingDescription("Int Setting Description")]
	//[SettingName("Int Setting Name")]
	//public int IntSetting { get; set; } = 5;

	/* - Example Enum Setting */
	//public enum Directions
	//{
	//	North,
	//	East,
	//	South,
	//	West
	//}
	//[SettingDescription("Enum Setting Description")]
	//[SettingName("Enum Setting Name")]
	//public Directions DirectionSetting { get; set; } = Directions.East;

	/* - Example Spacer. Will add an empty row before the next item. */
	//[SettingSpacer]

	/* - Example SubHeader. Will apply a subheader before the next item. */
	//[SettingSubHeader("SubHeader")]

	/* - Example Bool Setting */
	//[SettingDescription("Bool Setting Description")]
	//[SettingName("Bool Setting Name")]
	//public bool BoolSetting { get; set; } = false;

	/* - Example SubMenu. Will create a nested menu based on the class. */
	//[SettingSubMenu]
	//public class TestSubMenuClass()
	//{
	//	public int IntSettingSubMenu { get; set; } = 5;
	//}
	//[SettingDescription("SubMenu Description")]
	//[SettingName("SubMenu Name")]
	//public TestSubMenuClass TestSubMenu { get; set; } = new();
}
