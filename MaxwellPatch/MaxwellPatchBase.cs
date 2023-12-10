using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCSoundTool;
using UnityEngine;

namespace MaxwellPatch;

[BepInPlugin(ModGuid, "Maxwell Theme", "1.0.0")]
[BepInDependency("LCSoundTool")]
[BepInDependency("evaisa.lethalthings")]
public class MaxwellPatchBase : BaseUnityPlugin
{
    private const string ModGuid = "AriDev.MaxwellPatch";
    
    private readonly Harmony _harmony = new(ModGuid);

    private static MaxwellPatchBase _instance;
    
    internal static AudioClip NewSfx;
    internal static AudioClip NewSfxFar;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        Logger.Log(LogLevel.Info, "Starting Maxwell Patch");

        NewSfx = SoundTool.GetAudioClip(Path.GetDirectoryName(_instance.Info.Location), "maxwell.wav");
        NewSfxFar = SoundTool.GetAudioClip(Path.GetDirectoryName(_instance.Info.Location), "maxwell2.wav");

        _harmony.PatchAll(typeof(MaxwellAiPatch));
        _harmony.PatchAll(typeof(MaxwellPatchBase));
        
        Logger.Log(LogLevel.Info, "Maxwell Patch is loaded");
    }
}
