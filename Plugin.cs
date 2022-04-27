using BepInEx;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace TaikoInfiniteCoins
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(!scene.name.Equals("SongSelect")) return;
            PlayDataManager playDataManager = FindObjectOfType<PlayDataManager>();
            if (playDataManager == null) return;
            Logger.LogInfo("PlayDataManager found!");
            playDataManager.AddDonCoin(0, DataConst.DonCoinMax, true);
            
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
