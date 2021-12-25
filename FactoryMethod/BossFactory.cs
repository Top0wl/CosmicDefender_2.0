namespace CosmicDefender.FactoryMethod
{
    public class BossFactory : AbstractFactory
    {
        public Boss CreateBoss1()
        {
            Boss NewObj = new Boss(Content.getInstance().GetBoss6(), 1.5f, 0.1f, "Boss", 1000,
                new Gun(new SingleShot(), Content.getInstance().GetBullet(), 2, 1, 1), 
                0.2f);
            Log(NewObj);
            return NewObj;
        }
    }
}