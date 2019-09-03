using DAL;
using DAL.Entities;
using DAL.Repositories;
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
        private IFarmRepository _farmRepository;

        //public FarmController()
        //{
        //    var unitOfWork = new UnitOfWork();
        //    _farmRepository = unitOfWork.FarmRepository;
        //}

        //// GET: Farm
        //public IEnumerable<FarmEntity> Get()
        //{
        //    return _farmRepository.GetAll();
        //}

        //public void Post([FromBody] FarmEntity farm)
        //{
        //    _farmRepository.Add(farm);
        //}

        //public void Delete([FromBody] FarmEntity farm)
        //{
        //    _farmRepository.DeleteFarm(farm);
        //}

        //public FarmEntity Get(int id)
        //{
        //    return _farmRepository.GetFarmById(id);
        //}

    }
}