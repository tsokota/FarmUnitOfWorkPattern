namespace DAL
{
    using Entities.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class FarmContext : DbContext, IFarmContext
    {
        public FarmContext()
            : base("name=FarmContext")
        {
        }

        public virtual DbSet<FarmEntity> FarmEntities { get; set; }

        public new DbEntityEntry<FarmEntity> Entry(FarmEntity farm)
        {
            return base.Entry(farm);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker
                .Entries<IDeletable>()
                .Where(e => e.State == System.Data.Entity.EntityState.Deleted))
            {
                entry.Entity.IsDelete = true;
                entry.Entity.DelitingDate = DateTime.Now;
                entry.State = System.Data.Entity.EntityState.Modified;
            }

            return base.SaveChanges();
        }
    }
}