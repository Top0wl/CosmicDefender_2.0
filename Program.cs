using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicDefender.FactoryMethod;
using CosmicDefender.Menu;


namespace CosmicDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            GameManager gameManager = GameManager.GetInstance();
            Menu.Menu menuManager = Menu.Menu.GetInstance();

            #region Singleton
            Window window = Window.getInstance();
            #endregion
            
            while (Window.getInstance().getWindow().IsOpen)
            {
                if (menuManager.IsOpen)
                {
                    menuManager.Update();
                }
                else
                {
                    gameManager.Update();
                }
                Window.getInstance().Update();
            }
        }
    }
}
