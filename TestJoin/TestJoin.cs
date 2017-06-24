using System;
using MiNET;
using MiNET.Net;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;

namespace TestJoin
{
    [Plugin(PluginName = "TestJoin", Description = "First MiNET plugin", Author = "AppleDevelops", PluginVersion = "1.0")]
    public class TestJoin : Plugin
    {
        protected override void OnEnable()
        {
            Console.WriteLine("Enabled!");
            Context.Server.PlayerFactory.PlayerCreated += (sender, args) =>
            {
                args.Player.PlayerJoin += (o, eventArgs) => eventArgs.Player.Level.BroadcastMessage($"[+] {eventArgs.Player.Username}");
            };
        }

        [Command(Name = "curse")]
        public void curse(Player player)
        {
            McpeLevelEvent levelEvent = McpeLevelEvent.CreateObject();
            levelEvent.eventId = 2006;
            levelEvent.data = 1;
            player.Level.RelayBroadcast(levelEvent);
        }
    }
}
