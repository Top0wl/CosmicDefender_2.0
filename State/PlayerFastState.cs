using System;
using SFML.System;
using SFML.Window;

namespace CosmicDefender.State
{
    public class PlayerFastState : PlayerBaseState
    {
        private Clock Timer = new Clock();
        private readonly float cooldown = 5f;
        public override void EnterState(PlayerShip player, PlayerStateManager stateManager)
        {
            player.MaxSpeed *= 2;
            Timer.Restart();
            Console.WriteLine("Объект вошел в состояние быстрой скорости");
        }
        public override void ExitState(PlayerShip player, PlayerStateManager stateManager)
        {
            player.MaxSpeed /= 2;
            Console.WriteLine("Объект вышел из состояния быстрой скорости");
        }
        public override void UpdateState(float time, PlayerShip player, PlayerStateManager stateManager)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                player.Force();
            }
            if (Timer.ElapsedTime.AsSeconds() >= cooldown)
            {
                stateManager.SwitchState(stateManager._simpleState);
            }
        }
    }
}