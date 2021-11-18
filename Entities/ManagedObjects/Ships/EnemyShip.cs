namespace CosmicDefender
{
    public class EnemyShip : Ship
    {
        public EnemyShip() {  }
        public EnemyShip(string name, Gun gun)
        {
            this._name = name;
            this.Guns = gun;
        }
        public override void Update()
        {
            
        }
    }
}