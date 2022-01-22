using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using System.Reflection;

using PlayerEv = Exiled.Events.Handlers.Player;
using ServerEv = Exiled.Events.Handlers.Server;

namespace SCP682Exiled
{
    public class SCP682 : Plugin<Config>
    {
        public override string Name { get; } = "SCP-682";
        public override string Author { get; } = "Naku, update by pan andrzej";
        public override Version Version => new Version(1, 2, 1);
        public override Version RequiredExiledVersion => new Version(4, 2, 3);

        private EventHandler handler;

        public override void OnEnabled()
        {
            handler = new EventHandler();
            SCP682.Singleton = this;
            ServerEv.RoundEnded += handler.OnRoundEnd;
            PlayerEv.ChangingRole += handler.OnSetRole;
            PlayerEv.Died += handler.OnPlayerDie;
            PlayerEv.InteractingDoor += handler.OnDoorAccess;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEv.RoundEnded -= handler.OnRoundEnd;
            PlayerEv.ChangingRole -= handler.OnSetRole;
            PlayerEv.Died -= handler.OnPlayerDie;
            PlayerEv.InteractingDoor -= handler.OnDoorAccess;
            handler = null;

            base.OnDisabled();
        }
        public static SCP682 Singleton;
    }
}
