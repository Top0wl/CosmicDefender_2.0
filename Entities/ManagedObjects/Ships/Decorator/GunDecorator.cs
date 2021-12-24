namespace CosmicDefender
{
    public abstract class GunDecorator : Gun
    {
        protected Gun _gun;
        public override void Shot()
        {
            _gun.Shot();
        }
    }
}