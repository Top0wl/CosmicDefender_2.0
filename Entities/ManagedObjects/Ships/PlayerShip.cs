using System;
using System.Data;
using System.Threading;
using CosmicDefender.Controllers;
using CosmicDefender.State;
using CosmicDefender.Visitor;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public class PlayerShip : Ship
    {
        public PlayerStateManager _stateManager { get; }
        public PlayerShip() { }
        public PlayerShip(Sprite sprite, float maxSpeed, float acceleration, string name, float health, 
            Gun weapon, float firingRate) 
            : base(sprite, maxSpeed, acceleration, name, health, weapon, firingRate)
        {
            Dmg = 100;
            MaxSpeed = maxSpeed;
            _stateManager = new PlayerStateManager(this);
            //weapon.ship = this;
        }
        public override void Update(float time)
        {
            _stateManager.Update(time);
            Weapon.Update();
            //UpdateRotation();
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && CheckFireRating())
            {
                Weapon.Shot();
                Timer.Restart();
            }
            base.Update(time);
        }
        public override void UpdateRotation()
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
        }
        
        public override void Visit(EnemyShip enemyShip)
        {
            Console.WriteLine($"{enemyShip.GetType()} посетила объект {this.GetType()} и нанёс урон");
        }
        public override void Visit(Asteroid asteroid)
        {
            Console.WriteLine($"{asteroid.GetType()} посетила объект {this.GetType()} и нанёс урон");
            asteroid.Damage(this);
            ObjectManager.GetInstance().DeleteEntity(asteroid);
        }
        public override void Visit(Bullet bullet)
        {
            Console.WriteLine($"{bullet.GetType()} посетила объект {this.GetType()} и нанёс урон");
            bullet.DisableCollide();
            bullet.Damage(this);
            ObjectManager.GetInstance().DeleteEntity(bullet);
        }
        public override void Collide(Entity ent1, Entity ent2)
        {
            if (this == ent1)
            {
                 Console.WriteLine($"Произошла коллизия между объектом {ent1.GetType()} и {ent2.GetType()}");
                 ent2.Visit(this);
            }
        }
    }
}