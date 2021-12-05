using System;
using System.Data;
using System.Threading;
using CosmicDefender.State;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public class PlayerShip : Ship
    {
        private Clock Timer = new Clock();
        public float MaxSpeed { get; set; } //2f
        public float _firingRate { get; } //5f
        public PlayerStateManager _stateManager { get; }
        
        
        public PlayerShip() { }
        
        public PlayerShip(Sprite sprite, float velocity, float acceleration, string name, float health, 
            Gun weapon, float maxSpeed, float firingRate) 
            : base(sprite, velocity, acceleration, name, health, weapon)
        {
            MaxSpeed = maxSpeed;
            _firingRate = firingRate;
            _stateManager = new PlayerStateManager(this);
            weapon.ship = this;
        }

        public override void Update(float time)
        {
            _stateManager.Update(time);
            UpdateRotation();
            if (Mouse.IsButtonPressed(Mouse.Button.Left) &&  Timer.ElapsedTime.AsSeconds() >= _firingRate)
            {
                Weapon.Shot();
                Timer.Restart();
            }
            base.Update(time);
        }

        private void UpdateRotation()
        {
            RenderWindow window = Window.getInstance().getWindow();
            //забираем коорд курсора
            Vector2i pixelCoords = Mouse.GetPosition(window);
            //переводим их в игровые
            Vector2f cursorCoors = window.MapPixelToCoords(pixelCoords);
            //Находим вектор между мышью и кораблём
            Vector2f Rotate = cursorCoors - Coords;
            //Преобразуем
            float rotat = (float)((Math.Atan2(Rotate.Y, Rotate.X) * 180 / Math.PI) - 90);
            //Поворачиваем спрайт
            _sprite.Rotation = rotat;
            //Обновляем поворот корабля
            Rotation = Rotate;
            //
            
        }
    }
}