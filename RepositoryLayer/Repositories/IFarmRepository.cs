using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IFarmRepository
    {
        void Add(FarmEntity farm);
        void DeleteFarm(FarmEntity farm);
        IEnumerable<FarmEntity> GetAll();
        FarmEntity GetFarmById(int id);
    }
}