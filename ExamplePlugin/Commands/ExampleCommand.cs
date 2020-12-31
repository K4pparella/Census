namespace ExamplePlugin.Commands
{
    using CensusAPI.Features;
    using System.Collections.Generic;
    using PluginFramework.Classes;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;

    [ChatCommand]
    public class ExampleCommand : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { };

        public string Description => "Example Command";

        public string Name => "example_command";

        public bool ShowInHelpCmd => true;

        public List<string> Aliases => new List<string>();

        public bool Hidden => false;

        public void Invoke(PlayerController invoker, string[] args, out string response)
        {
             foreach (VirtualBrightPlayz.SCP_ET.Door d in Map.Doors)
             {
                 d.NetworkisLocked = false;
                 d.Networkopen = true;
             }
            Player pl = Player.Get(invoker);
            pl.ShowStatus("Command executed!");
            response = "Command executed!";
        }
    }
}