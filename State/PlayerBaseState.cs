namespace CosmicDefender.State
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerShip player, PlayerStateManager stateManager);
        public abstract void ExitState(PlayerShip player, PlayerStateManager stateManager);
        public abstract void UpdateState(float time, PlayerShip player, PlayerStateManager stateManager);
    }
}