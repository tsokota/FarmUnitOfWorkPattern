﻿using Entities.Models;
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
        private IFarmContext db;

        public FarmRepository(IFarmContext context)
        {
            db = context;
        }

        public void Add(FarmEntity farm)
        {
            db.FarmEntities.Add(farm);
        }

        public IEnumerable<FarmEntity> GetAll()
        {
            return db.FarmEntities.Where(x=>x.IsDelete!=true).ToList();
        }

        public void DeleteFarm(FarmEntity farm)
        {
            var obj = GetFarmById(farm.Id);
            db.FarmEntities.Remove(obj);
        }

        public FarmEntity GetFarmById(int id)
        {
            return db.FarmEntities.FirstOrDefault(x => x.Id==id);
        }

        public void UpdateFarm(FarmEntity farm)
        {
            var obj = GetFarmById(farm.Id);
            db.FarmEntities.Attach(obj);
        }
    }
}