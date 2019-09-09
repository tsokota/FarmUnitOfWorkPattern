using System.Collections.Generic;
using Entities.Models;

namespace Services.Services
{
    public interface IFarmService
    {
        void AddFarm(FarmEntity farm);
        IEnumerable<double> AverageCostAnimal();
        IEnumerable<double> AverageCostAnimal(IEnumerable<int> farmIds);
        double AverageCostAnimal(int farmId);
        double AverageFarmsCost();
        void DeleteFarm(FarmEntity farm);
        void EditFarm(FarmEntity farm);
        IEnumerable<FarmEntity> GetAll();
        FarmEntity GetFarmById(int id);
    }
}