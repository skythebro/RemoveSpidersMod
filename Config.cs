using RedLoader;
using SUI;

namespace RemoveSpidersMod;

public static class Config
{
    public static ConfigCategory Category { get; private set; }

    //public static ConfigEntry<bool> SomeEntry { get; private set; }

    // Auto populated after calling SettingsRegistry.CreateSettings...
#pragma warning disable CS0169 // Field is never used
    private static SettingsRegistry.SettingsEntry _settingsEntry;
#pragma warning restore CS0169 // Field is never used

    public static void Init()
    {
        Category = ConfigSystem.CreateFileCategory("RemoveSpidersMod", "RemoveSpidersMod", "RemoveSpidersMod.cfg");

        // SomeEntry = Category.CreateEntry(
        //     "some_entry",
        //     true,
        //     "Some entry",
        //     "Some entry that does some stuff.");
    }

    // Same as the callback in "CreateSettings". Called when the settings ui is closed.
    public static void OnSettingsUiClosed()
    {
    }
}