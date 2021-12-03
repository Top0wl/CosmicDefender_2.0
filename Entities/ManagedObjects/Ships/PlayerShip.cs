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
        public Vector2f Direction
        {
            get => Normalization(Rotation);
        }
        public float Acceleration = 0.07f;               //Ускорение в пискелях в тик
        public Vector2f Speed = new Vector2f(0,0);
        public float MaxSpeed = 2f;                   //Максимальная скорость в пикселях в тик
        
        private Clock Timer = new Clock();
        private PlayerStateManager _stateManager;
        
        private float _firingRate = 1f;
        public PlayerShip()
        {
            _stateManager = new PlayerStateManager(this);
        }
        public PlayerShip(Sprite ShipSprite, Vector2f Coords, int Velocity, IGunShot TypeOfGun)
        {
            _sprite = new Sprite(ShipSprite);
            ((Entity) this).Coords = Coords;
            //Speed = new Vector2f(Velocity, Velocity);
            Guns = new Gun(TypeOfGun);
            Guns = new Trajectory(Guns);
            ((Entity) this).Coords = new Vector2f(200, 200);
            _sprite.Position = ((Entity) this).Coords;
            _name = "PlayerShip";
            _stateManager = new PlayerStateManager(this);
        }
        public PlayerShip(Sprite ShipSprite, Vector2f Coords, int Velocity, Gun gun)
        {
            this._sprite = new Sprite(ShipSprite);
            this.Coords = Coords;
            
            //this.Speed = new Vector2f(Velocity, Velocity);
            this.Guns = gun;
            this._sprite.Position = this.Coords;
            _name = "PlayerShip";
            _stateManager = new PlayerStateManager(this);
        }
        public override void Update(float time)
        {
            _stateManager.Update(time);
            Move(time);
            UpdateRotation();
            Guns.Update();
            if (Mouse.IsButtonPressed(Mouse.Button.Left) &&  Timer.ElapsedTime.AsSeconds() >= _firingRate)
            {
                //Vector2f CoordsStartShot = new Vector2f(_coords.X + _sprite.Texture.Size.X * _rotation.X,_coords.Y + _sprite.Texture.Size.Y * _rotation.Y) ;
                //Откуда, в какую сторону
                Guns.Shot(_coords, _rotation);
                Timer.Restart();
            }
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
            _rotation = Rotate;
            //Обновляем поворот пушек
            Guns.Rotation = Rotate;
        }
        /* TODO: Пока не знаю куда логичнее запихать, оставить тут в Player'e,
           TODO: или же запихать этот метод в состояние где и происходит движение
         */
        public void Force()
        {
            //Наращиваем скорость
            Speed += Acceleration * Direction;
            float constanta = (float)Math.Sqrt( (MaxSpeed * MaxSpeed) / ( Speed.X * Speed.X + Speed.Y * Speed.Y));
            //Максимальная скорость
            var Speed2 = Speed * constanta;
            float Dvelocity = LengthVector(Speed);
            float Dvelocity2 = LengthVector(Speed2);
            //Если Скорость выше максимальной, то присвоить
            //скорости маскимальную скорость
            if (Dvelocity > Dvelocity2)
            {
                Speed = Speed2;
            }
        }
        public void Move(float time)
        {
            Force();
            this.Coords += Speed * time;
            if (Coords.X > 1280)
            {
                Coords = new Vector2f(0, Coords.Y);
            }
            if (Coords.X < 0)
            {
                Coords = new Vector2f(1280, Coords.Y);
            }
            if (Coords.Y > 720)
            {
                Coords = new Vector2f(Coords.X, 0);
            }
            if (Coords.Y < 0)
            {
                Coords = new Vector2f(Coords.X, 720);
            }
        }
        private Vector2f Normalization(Vector2f vec)
        {
            float length = (float)Math.Sqrt((vec.X) * (vec.X) + (vec.Y) * (vec.Y));
            if (length != 0)
            {
                return new Vector2f(vec.X / length, vec.Y / length);
            }
            else
            {
                return vec;
            }
        }
        public float LengthVector(Vector2f vec)
        {
            float length = (float)Math.Sqrt((vec.X) * (vec.X) + (vec.Y) * (vec.Y));
            return length;
        }
    }
}