using System.Collections.Generic;

using System.Linq;
using DAL;
using DAL.Repositories;
using Entities.Models;
using Faker;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace Tests
{
    [Author("Roman Shuvalov", "romans@uteam.co.il")]
    [Category("Repo-tests")]
    public class FermaRepositoryTests
    {
        private static List<FarmEntity> _farms;

        private UnitOfWork _unitOfWork;

        private FarmRepository _farmRepository;
        private FarmContext _db;


     [SetUp]
        public void Setup()
        {
            _farms = new List<FarmEntity>
            {
                new FarmEntity
                {
                    AmountOfAnimals = Faker.NumberFaker.Number(0, 100),
                    DelitingDate = null,
                    Id = 44,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName()
                }
            };

            var mockedDbContext = new Mock<FarmContext>();

            _db = mockedDbContext.Object;
            var dbset = new FakeDbSet<FarmEntity>(_farms);

            mockedDbContext.Setup(x => x.FarmEntities)
                .Returns(() => dbset);
            
            _unitOfWork = new UnitOfWork(_db);

            _farmRepository = new FarmRepository(_db);
        }

        [Test]
        public void Uof_ReturnsRepo_Test()
        {
            var farmRepo = _unitOfWork.FarmRepository;

            Assert.IsNotNull(farmRepo);
        }

        [Test]
        public void Repo_GetList_Test()
        {
            var allFermas = _farmRepository.GetAll();

            Assert.IsNotNull(allFermas);
            Assert.AreEqual(_farms.Count, allFermas.Count());
        }

        [Test]
        public void Repo_GetFarmById_Test()
        {
            var farm= _farmRepository.GetFarmById(44);

            Assert.IsNotNull(farm);
            Assert.AreEqual(44, farm.Id);
        }

        [Test]
        public void Repo_GetFarmByIdNull_Test()
        {
            var farm = _farmRepository.GetFarmById(66);

            Assert.IsNull(farm);
        }

        [Test]
        public void Repo_AddFarm_Test()
        {
            var farmsCountBefore = _farms.Count;

            _farmRepository.Add(
                new FarmEntity
                {
                    AmountOfAnimals = Faker.NumberFaker.Number(0, 100),
                    DelitingDate = null,
                    Id = 11,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName()
                }
            );

            _db.SaveChanges();

            int g = _farmRepository.GetAll().Count();

            int y = ++farmsCountBefore;

            Assert.AreEqual(y,g);
        }


        [Test]
        public void Repo_EditFarm_Test()
        {
            var farm = _farmRepository.GetFarmById(44);

            farm.AmountOfAnimals = 666;

            _farmRepository.UpdateFarm(farm);
            _db.SaveChanges();
            farm = _farmRepository.GetFarmById(44);

            Assert.AreEqual(666, farm.AmountOfAnimals);
        }

        [Test]
        public void Repo_DeleteFarm_Test()
        {
            _farmRepository.DeleteFarm(_farms[0]);
            _db.SaveChanges();
            var allFermas = _farmRepository.GetAll();
            Assert.IsEmpty(allFermas);
        }
    }
}