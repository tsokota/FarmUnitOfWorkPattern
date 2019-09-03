namespace DAL
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FarmContext : DbContext
    {
        public FarmContext()
            : base("name=FarmContext")
        {
        }

        public virtual DbSet<FarmEntity> FarmEntities { get; set; }
    }
}