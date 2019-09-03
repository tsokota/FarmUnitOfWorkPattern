using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private FarmStorage _farmStorage;

        public FarmRepository(FarmStorage farm)
        {
            _farmStorage = farm;
        }

        public void Add(FarmEntity farm)
        {
            _farmStorage.AddFarm(farm);
        }

        public IEnumerable<FarmEntity> GetAll()
        {
            return _farmStorage.GetAllAnimals();
        }


        public void DeleteFarm(FarmEntity farm)
        {
            int id = farm.Id;
            _farmStorage.DeleteFarm(id);
        }

        public FarmEntity GetFarmById(int id)
        {
            return _farmStorage.GetFarmById(id);
        }

    }
}
