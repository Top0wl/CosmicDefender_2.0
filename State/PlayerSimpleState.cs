using System;
using System.Globalization;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using SFML.System;
using SFML.Window;

namespace CosmicDefender.State
{
    public class PlayerSimpleState : PlayerBaseState
    {
        private Clock Timer = new Clock();
        private readonly float cooldown = 1f;
        public override void EnterState(PlayerShip player, PlayerStateManager stateManager)
        {
            Timer.Restart();
            Console.WriteLine("Объект вошел в состояние обычной скорости");
        }
        public override void ExitState(PlayerShip player, PlayerStateManager stateManager)
        {
            Console.WriteLine("Объект вышел из состояния обычной скорости");
        }
        public override void UpdateState(float time, PlayerShip player, PlayerStateManager stateManager)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                player.Force();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.F) && Timer.ElapsedTime.AsSeconds() >= cooldown)
            {
                stateManager.SwitchState(stateManager._fastState);
            }
        }
    }
}