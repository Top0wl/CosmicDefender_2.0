using System;
using System.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CosmicDefender
{
    public class Trajectory : GunDecorator, IDrawable
    {
        private Vertex[] _trajectory;
        public Trajectory(Gun gun)
        {
            this._gun = gun;
        }
        public override void Update()
        {
            UpdateTrajectory();
            Draw();
            _gun.Update();
        }
        public void Draw()
        {
            Window.getInstance().getWindow().Draw(_trajectory, PrimitiveType.Lines);
        }
        private void UpdateTrajectory()
        {
            //Считываем координаты мыши
            Vector2f cursorCoors = Window.getInstance().getWindow().MapPixelToCoords(Mouse.GetPosition(Window.getInstance().getWindow()));
            var tmp = cursorCoors - this.ship.Rotation;
            
            _trajectory = new Vertex[]
            {
                new Vertex(new Vector2f(tmp.X, tmp.Y)),
                new Vertex(new Vector2f(cursorCoors.X, cursorCoors.Y)),
            };
        }
    }
}