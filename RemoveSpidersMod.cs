using Il2CppTheForest.Utils;
using MelonLoader;
using UnityEngine;
using Il2CppSons.Gameplay;
using System.Linq;

namespace RemoveSpidersMod
{
    public class RemoveSpiders : MelonMod
    {
        private bool isDone = false;
        private int removeCounter = 0;
        private int disableSpawnCounter = 0;
        private int CurrentSpawnCounter;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Mod loaded");
        }

        public override void OnUpdate()
        {
            if (LocalPlayer.IsInWorld)
            {
                if (isDone) return;
                LoggerInstance.Msg("Removing Webs!");
                foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    if (obj.name.EndsWith("Spiderweb_"))
                    {
                        Object.Destroy(obj);
                        LoggerInstance.Msg("Destroyed Web: " + obj.name);
                        removeCounter++;
                    }
                }
                LoggerInstance.Msg("Removed a total of " + removeCounter + " webs");
                CurrentSpawnCounter = disableSpawnCounter;
                GameObject[] pickups = Resources.FindObjectsOfTypeAll<GameObject>().Where(go => go.GetComponent<PickUp>() != null && go.GetComponent<PickUp>()._spawnSpiders == true).ToArray();

                if (pickups.Length != 0 && pickups != null)
                {
                    LoggerInstance.Msg("Removing spider spawns!");
                    foreach (GameObject pickup in pickups)
                    {
                        var sonsPickup = pickup.GetComponent<PickUp>();
                        if (sonsPickup != null)
                        {
                            sonsPickup._spawnSpiders = false;
                            sonsPickup._spiderSpawnChance = 0f;
                            disableSpawnCounter++;
                        }
                    }
                    if (disableSpawnCounter > CurrentSpawnCounter)
                    {
                        LoggerInstance.Msg("Disabled spider spawning on rock pickups for: " + disableSpawnCounter + " rocks.");
                        LoggerInstance.Msg("If my code worked correctly all rocks now wont spawn spiders for you. Enjoy the game!");

                    }

                }
                isDone = true;
               
            }
            else
            {
                if (isDone == true) {
                    disableSpawnCounter = 0;
                    CurrentSpawnCounter = 0;
                    removeCounter = 0;
                    isDone = false;
                }
                
            }
        }
    }
}
