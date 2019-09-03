using Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public interface IFarmContext
    {
        DbSet<FarmEntity> FarmEntities { get; set; }

        int SaveChanges();
        DbEntityEntry<FarmEntity> Entry(FarmEntity farm);
        void Dispose();
    }
}