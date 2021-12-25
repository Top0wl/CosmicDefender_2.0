namespace CosmicDefender.FactoryMethod
{
    public class PlayerShipFactory : AbstractFactory
    {
        public PlayerShip CreateShip1()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip1(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip2()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip2(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip3()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip3(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip4()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip4(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip5()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip5(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip6()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip6(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip7()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip7(), 3f, 0.1f, "PlayerShip", 100000,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),3,2, 50),
                0.05f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip8()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip8(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
        public PlayerShip CreateShip9()
        {
            PlayerShip NewObj = new PlayerShip(Content.getInstance().GetShip9(), 2f, 0.1f, "PlayerShip", 100,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(),2,1, 50),
                0.1f);
            Log(NewObj);
            return NewObj;
        }
    }
}