using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FarmStorage
    {
        private static List<FarmEntity> _farmStorage;
        private static int _id = 1;
        static FarmStorage()
        {
            _farmStorage = new List<FarmEntity>();
        }

        public FarmStorage() { }

        public IEnumerable<FarmEntity> GetAllAnimals()
        {
            return _farmStorage.ToList();
        }

        public FarmEntity GetFarmById(int id)
        {
            return _farmStorage.FirstOrDefault(x => x.Id == id);
        }

        public void AddFarm(FarmEntity farm)
        {
            if (farm == null)
                throw new ArgumentNullException(nameof(FarmEntity));

            farm.Id = ++_id;

            _farmStorage.Add(farm);
        }

        public void DeleteFarm(int id)
        {


            var farm = GetFarmById(id);

            if (farm == null)
                return;

            _farmStorage.Remove(farm);
        }


    }

   

}
