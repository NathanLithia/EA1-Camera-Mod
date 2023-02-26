using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace EA1_Camera_Mod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(RTS_camera2))]
    [HarmonyPatch("Start")]
    public class CameraVariables
    {
        [HarmonyPostfix]
        public static void Patch()
        {
            GameObject RTSCameraGO = GameObject.Find("/CORESCRIPTS/RTScamera");
            RTSCameraGO.GetComponent<RTS_camera2>().MaxHeight = 800;
            RTSCameraGO.GetComponent<UnityEngine.Camera>().farClipPlane = 2000;
            return;
        }
    }
}
