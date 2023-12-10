using HarmonyLib;
using LethalThings;
using UnityEngine;

namespace MaxwellPatch;

[HarmonyPatch(typeof(Dingus))]
public class MaxwellAiPatch
{
    [HarmonyPatch(nameof(Dingus.Start))]
    [HarmonyPrefix]
    public static void DingusPatch(ref AudioSource ___musicAudio, ref AudioSource ___musicAudioFar)
    {
        ___musicAudio.clip = MaxwellPatchBase.NewSfx;
        ___musicAudio.volume = 0.5f;
        ___musicAudioFar.clip = MaxwellPatchBase.NewSfxFar;
        ___musicAudioFar.volume = 0.5f;
    }
}