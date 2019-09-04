using DAL;
using DAL.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ALev_Farm.Controllers
{
    public class FarmController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public FarmController()
        {
            _unitOfWork = null;
        }
        public FarmController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        // GET: Farm
        public IEnumerable<FarmEntity> Get()
        {
            return _unitOfWork.FarmRepository.GetAll();
        }

        public void Post([FromBody]FarmEntity farm)
        {
            _unitOfWork.FarmRepository.Add(farm);
           int y =  _unitOfWork.Save();
        }

        public void Delete([FromBody]FarmEntity farm)
        {
            _unitOfWork.FarmRepository.DeleteFarm(farm);
            _unitOfWork.Save();
        }

        public FarmEntity Get(int id)
        {
            return _unitOfWork.FarmRepository.GetFarmById(id);
        }
     
        public void Put([FromBody]FarmEntity farm)
        {
            _unitOfWork.FarmRepository.UpdateFarm(farm);
            _unitOfWork.Save();
        }
    }
}