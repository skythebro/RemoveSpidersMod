using HarmonyLib;
using Object = UnityEngine.Object;

namespace RemoveSpidersMod.Patches;

[HarmonyPatch(typeof(SpiderWeb), "Start")]
public class SpiderWebStartPatch
{
    public static void Postfix(SpiderWeb __instance)
    {
        __instance._spawnChance = 0f;
        __instance._spiderSpawnChance = 0f;

        if (__instance.gameObject != null)
        {
            Object.Destroy(__instance.gameObject);
        }
    }
}

[HarmonyPatch(typeof(SpiderWeb), nameof(SpiderWeb._spawnChance), MethodType.Getter)]
public class SpiderWebSpawnChanceGetterPatch
{
    public static bool Prefix(ref float __result)
    {
        __result = 0f;
        return false;
    }
}

[HarmonyPatch(typeof(SpiderWeb), nameof(SpiderWeb._spiderSpawnChance), MethodType.Getter)]
public class SpiderWebSpiderSpawnChanceGetterPatch
{
    public static bool Prefix(ref float __result)
    {
        __result = 0f;
        return false;
    }
}
