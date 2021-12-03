using System.Data;
using CosmicDefender.FactoryMethod;

namespace CosmicDefender.State
{
    public class PlayerStateManager
    {
        //Ссылка на parrent'a
        private PlayerShip _player;
        private PlayerBaseState _currentState;
        //Сборщик мусора конечно может почистить память если в currentState
        //мы будем запихивать 'new State', но так как сделано ниже
        //всё же оптимальнее... Возможно, я не прав...
        //Так мы имеем состояния, их не надо при каждой смене инициализировать
        //а задаём их просто в качестве полей, можно кстати инициализировать и в конструкторе...
        public PlayerFastState _fastState = new PlayerFastState();
        public PlayerSimpleState _simpleState = new PlayerSimpleState();
        public PlayerStateManager(PlayerShip player)
        {
            _player = player;
            _currentState = _simpleState;
            _currentState.EnterState(_player,this);
        }
        public void Update(float time)
        {
            _currentState.UpdateState(time, _player, this);
        }
        public void SwitchState(PlayerBaseState state)
        {
            _currentState.ExitState(_player, this);
            _currentState = state;
            _currentState.EnterState(_player,this);
        }
    }
}