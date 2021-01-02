namespace CensusCore.Harmony.Events
{
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using HarmonyLib;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World.Interacts;
    using static HarmonyLib.AccessTools;


    /*  System.NullReferenceException: Object reference not set to an instance of an object
        at System.Collections.Generic.ObjectEqualityComparer`1[T].GetHashCode (T obj)[0x0000a] in <fb001e01371b4adca20013e0ac763896>:0
        at System.Collections.Generic.Dictionary`2[TKey, TValue].FindEntry (TKey key)[0x0001b] in <fb001e01371b4adca20013e0ac763896>:0
        at System.Collections.Generic.Dictionary`2[TKey, TValue].ContainsKey (TKey key)[0x00000] in <fb001e01371b4adca20013e0ac763896>:0
        at CensusAPI.Features.Player.Get (PluginFramework.Classes.IPlayer ply)[0x00014] in <4bdaae191f944c7a81ad5004cb728a32>:0
        at CensusAPI.Features.Player.Get (VirtualBrightPlayz.SCP_ET.Player.PlayerController ply)[0x0000b] in <4bdaae191f944c7a81ad5004cb728a32>:0
    */

    //  [HarmonyPatch(typeof(DoorButton2), nameof(DoorButton2.StartUseOnce))]
    public class InteractingDoorButtonPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var newInst = new List<CodeInstruction>(instructions);

            int index = newInst.FindIndex(i => i.opcode == OpCodes.Stloc_1) - 2;

            newInst.InsertRange(0, new[]
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Call, Method(typeof(Player),nameof(Player.Get),new System.Type[]{ typeof(PlayerController)})),
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Call, Method(typeof(CensusWorldEvents), nameof(CensusWorldEvents.InvokeInteractingDoorButton)))
            });

            return newInst;
        }
    }
}