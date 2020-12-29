namespace ExamplePlugin.Commands
{
    using System.Collections.Generic;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;
    using PluginFramework.Classes;

    using CensusAPI.Features;

    [ChatCommand]
    public class ExampleCommand : TextChat.IChatCommand
    {
        public List<string> RequiredPermission => new List<string>() { };

        public string Description => "Example Command";

        public string Name => "example_command";

        public bool ShowInHelpCmd => true;

        public void Invoke(PlayerController invoker, string[] args, out string response)
        {
            Player ply = Player.Get((IPlayer)invoker.stats);
            ply.MaxHealth = 10000f;
            ply.Health = 10000f;
            response = "Set your hp, enjoy!";
        }
    }
}
