using System.Configuration;

namespace CosmicDefender.Builders.Interfaces
{
    public interface IShipBuilder : IEntityBuilder
    {
        public IShipBuilder SetGun(Gun gun);
    }
}