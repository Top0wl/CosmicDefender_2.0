using System;
using SFML.Graphics;
using SFML.Window;

namespace CosmicDefender
{
    public class Window
    {
        private static Window _instance;
        private static RenderWindow _window;
        
        private readonly string _name = "CosmicDefender";
        private readonly uint _windowWidth = 1280;
        private readonly uint _windowHeight = 720;

        private Window()
        {
            _window = new RenderWindow(new SFML.Window.VideoMode(_windowWidth, _windowHeight), "ComicDefender");
            _window.SetVerticalSyncEnabled(true);
            _window.SetFramerateLimit(60);
            _window.Closed += Window_Closed;
            _window.Resized += Win_Resized;
        }
        public RenderWindow getWindow()
        {
            return _window;
        }
        public static Window getInstance()
        {
            if (_instance == null)
            {
                _instance = new Window();
            }
            return _instance;
        }
        
        private static void Win_Resized(object sender, SizeEventArgs e)
        {
            //_window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }
        private static void Window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

        public void Update()
        {
            _window.DispatchEvents();   //Cобираем ивенты
            _window.Display();
            _window.Clear();
        }
    }
}