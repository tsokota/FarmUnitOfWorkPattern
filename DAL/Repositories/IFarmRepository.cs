using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IFarmRepository
    {
        void Add(FarmEntity farm);
        void DeleteFarm(FarmEntity farm);
        IEnumerable<FarmEntity> GetAll();
        FarmEntity GetFarmById(int id);

        void UpdateFarm(FarmEntity farm);
    }
}