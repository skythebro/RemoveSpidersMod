using HarmonyLib;
using Sons.Gameplay;

namespace RemoveSpidersMod.Patches;

[HarmonyPatch(typeof(PickUp), "Start")]
public class PickUpStartPatch
{
    public static void Postfix(PickUp __instance)
    {
        __instance._spawnSpiders = false;
        __instance._spiderSpawnChance = 0f;
    }
}

[HarmonyPatch(typeof(PickUp), nameof(PickUp._spawnSpiders), MethodType.Getter)]
public class PickUpSpawnSpidersGetterPatch
{
    public static bool Prefix(ref bool __result)
    {
        __result = false;
        return false;
    }
}

[HarmonyPatch(typeof(PickUp), nameof(PickUp._spiderSpawnChance), MethodType.Getter)]
public class PickUpSpiderSpawnChanceGetterPatch
{
    public static bool Prefix(ref float __result)
    {
        __result = 0f;
        return false;
    }
}
