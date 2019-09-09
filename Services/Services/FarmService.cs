using DAL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FarmService : IFarmService
    {
        private IUnitOfWork _unitOfWork;

        public FarmService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        // GET: Farm
        public IEnumerable<FarmEntity> GetAll()
        {
            return _unitOfWork.FarmRepository.GetAll();
        }

        public void AddFarm(FarmEntity farm)
        {
            _unitOfWork.FarmRepository.Add(farm);
            int y = _unitOfWork.Save();
        }

        public void DeleteFarm(FarmEntity farm)
        {
            _unitOfWork.FarmRepository.DeleteFarm(farm);
            _unitOfWork.Save();
        }

        public FarmEntity GetFarmById(int id)
        {
            return _unitOfWork.FarmRepository.GetFarmById(id);
        }

        public void EditFarm(FarmEntity farm)
        {
            _unitOfWork.FarmRepository.UpdateFarm(farm);
            _unitOfWork.Save();
        }

        public IEnumerable<double> AverageCostAnimal()
        {
            var result = new List<double>();
            var farms = _unitOfWork.FarmRepository.GetAll().ToList();

            farms.ForEach(x =>
            {
                if (x.Cost == null)
                    return;
                result.Add((double)x.Cost / x.AmountOfAnimals);
            });

            return result;
        }

        public double AverageCostAnimal(int farmId)
        {
            var farm = _unitOfWork.FarmRepository.GetFarmById(farmId);

            if (farm.Cost == null)
                return 0;

            double res = (double)farm.Cost / farm.AmountOfAnimals;

            return res;
        }

        public IEnumerable<double> AverageCostAnimal(IEnumerable<int> farmIds)
        {
            var result = new List<double>();

            farmIds.ToList().ForEach(x =>
            {
                result.Add(AverageCostAnimal(x));
            });

            return result;
        }

        public double AverageFarmsCost()
        {
            var farms = _unitOfWork.FarmRepository.GetAll().ToList();

            double res = (double)farms.Sum(x => x.Cost) / farms.Count();

            return res;
        }
    }
}
