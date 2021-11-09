namespace CosmicDefender
{
    public class Bomber : EnemyShip, IDamage
    {
        private readonly ActiveObjects _dmgAdapter;

        public Bomber(ActiveObjects dmgAdapter)
        {
            _dmgAdapter = dmgAdapter;
        }

        public void Damage(Entity Object, int _damage)
        {
            //_dmgAdapter.Damage(Object, _damage);
        }
        public override void Update()
        {
            
        }
        
    }
}