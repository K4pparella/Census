using CensusCore.Events;
using CensusCore.Events.EventArgs.Player;

namespace CensusCore.Harmony.Events.Player
{
    using System;
    using System.Collections.Generic;
    using System.IO;using CensusAPI.Features;
    using HarmonyLib;
    using Mirror;
    using Newtonsoft.Json;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.NetworkAuth;
    using VirtualBrightPlayz.SCP_ET.ServerGroups;
    using Player = CensusAPI.Features.Player;
    
    [HarmonyPatch(typeof(BanHandler), nameof(BanHandler.Addban))]
    public class BanningPatch
    {
        private static void Prefix(BanHandler __instance, INetworkConnection conn, string reason, TimeSpan duration)
        {
            string path = Path.Combine(Application.dataPath, "../settings/bans.json");
            List<BanInfo> list = JsonConvert.DeserializeObject<List<BanInfo>>(File.ReadAllText(path));
            string ip = conn.Address.ToString().Replace("[::ffff:", string.Empty).Replace("]", string.Empty).Split(new char[]
            {
                ':'
            })[0];
            string Steamid = ((AuthenticatedUser)conn.AuthenticationData).SteamId.ToString();
            if (list.Exists((BanInfo info) => info.Steamid == Steamid || info.Ip == ip))
                return;

            Player plyban = Player.Get(Steamid);
            if (plyban == null)
                return;
            BanningEventArgs ev = new BanningEventArgs(plyban, duration, reason);
            CensusPlayerEvents.Instance.ExecuteBanning(ev);
            if (!ev.IsAllowed)
            {
                return;
            }
            if (ev.Duration != duration)
                Log.Warn("Duration was changed by a plugin");
            
            BanInfo item = new BanInfo
            {
                Duration = ev.Duration,
                Ip = ip,
                BannedOn = DateTime.Now,
                Nickname = ev.PlayerBan.Nickname,
                Reason = ev.Reason,
                Steamid = ((AuthenticatedUser)conn.AuthenticationData).SteamId.ToString()
            };
            list.Add(item);
            File.WriteAllText(path, JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}