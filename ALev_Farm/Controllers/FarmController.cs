using Entities.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;

namespace ALev_Farm.Controllers
{
    public class FarmController : ApiController
    {
        private IFarmService _farmService;
        public FarmController()
        {
            _farmService = null;
        }
        public FarmController(IFarmService unit)
        {
            _farmService = unit;
        }

        [SwaggerOperation(Tags = new[] { "CRUD" })]
        // GET: Farm
        public IEnumerable<FarmEntity> Get()
        {
            return _farmService.GetAll();
        }

        [SwaggerOperation(Tags = new[] { "CRUD" })]
        public void Post([FromBody]FarmEntity farm)
        {
            _farmService.AddFarm(farm);
        }

        [SwaggerOperation(Tags = new[] { "CRUD" })]
        public void Delete([FromBody]FarmEntity farm)
        {
            _farmService.DeleteFarm(farm);
        }

        [SwaggerOperation(Tags = new[] { "CRUD" })]
        public FarmEntity Get(int id)
        {
            return _farmService.GetFarmById(id);
        }

        [SwaggerOperation(Tags = new[] { "CRUD" })]
        public void Put([FromBody]FarmEntity farm)
        {
            _farmService.EditFarm(farm);
        }

        [SwaggerOperation(Tags = new[] { "Business" })]
        [Route("api/Farm/AverageCostAnimal")]
        [HttpGet]
        public IEnumerable<double> AverageCostAnimal()
        {
            return _farmService.AverageCostAnimal();
        }

        [SwaggerOperation(Tags = new[] { "Business" })]
        [Route("api/Farm/AverageCostAnimal/farmId")]
        [HttpPost]
        public double GetAverageCostAnimal(int farmId)
        {
            return _farmService.AverageCostAnimal(farmId);
        }

     
        [SwaggerOperation(Tags = new[] { "Business" })]
        [Route("api/Farm/AverageCostAnimal/farmIds")]
        [HttpPost]
        public double AverageCostAnimal(IEnumerable<int> farmIds)
        {
            return _farmService.AverageCostAnimal(farmIds);
        }

        [SwaggerOperation(Tags = new[] { "Business" })]
        [Route("api/Farm/AverageFarmsCost")]
        [HttpGet]
        public double AverageFarmsCost()
        {
            return _farmService.AverageFarmsCost();
        }
    }
}