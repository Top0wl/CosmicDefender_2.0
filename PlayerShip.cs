﻿using System;
using System.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public class PlayerShip : Ship
    {
        public PlayerShip(Sprite ShipSprite, Vector2f Coords, int Velocity, IGunShot TypeOfGun)
        {
            _sprite = new Sprite(ShipSprite);
            _coords = Coords;
            _speed = new Vector2f(Velocity, Velocity);
            //_guns = new Gun(TypeOfGun);
            _coords = new Vector2f(100, 100);
            _sprite.Position = _coords;
            _name = "PlayerShip";

        }
        public override void Update()
        {
            UpdateRotation();
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                //_guns.Shot();
            }
        }

        // public override void Shot()
        // {
        //     Console.WriteLine("Корабль не может стрелять без пушки");
        // }

        private void UpdateRotation()
        {
            RenderWindow window = Window.getInstance().getWindow();
            //забираем коорд курсора
            Vector2i pixelCoords = Mouse.GetPosition(window);
            //переводим их в игровые
            Vector2f cursorCoors = window.MapPixelToCoords(pixelCoords);
            //Находим вектор между мышью и кораблём
            Vector2f Rotate = cursorCoors - _coords;
            //Преобразуем
            float rotat = (float)((Math.Atan2(Rotate.Y, Rotate.X) * 190 / Math.PI) - 90);
            //Поворачиваем
            _sprite.Rotation = rotat;
        }
    }
}