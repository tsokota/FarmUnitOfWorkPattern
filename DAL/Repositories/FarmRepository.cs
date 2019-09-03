using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private IFarmContext db = new FarmContext();

        public FarmRepository(IFarmContext farm)
        {
            db = farm;
        }

        public void Add(FarmEntity farm)
        {
            db.FarmEntities.Add(farm);
        }

        public IEnumerable<FarmEntity> GetAll()
        {
            return db.FarmEntities.ToList();
        }

        public void DeleteFarm(FarmEntity farm)
        {
            db.FarmEntities.Remove(farm);
        }

        public FarmEntity GetFarmById(int id)
        {
            return db.FarmEntities.First(x => x.Id==id);
        }

        public void UpdateFarm(FarmEntity farm)
        {
            db.Entry(farm).State = EntityState.Modified;
        }
    }
}