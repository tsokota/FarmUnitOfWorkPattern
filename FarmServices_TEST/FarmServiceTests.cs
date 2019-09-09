using ALev_Farm.Controllers;
using DAL;
using DAL.Repositories;
using Entities.Models;
using Moq;
using NUnit.Framework;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class FarmServiceTests
    {
        private FarmController _farmController;
        private FarmService _farmService;
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
                    AmountOfAnimals = 15,
                    DelitingDate = null,
                    Id = 1,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName(),
                    Cost = 1500
                },
                  new FarmEntity
                {
                    AmountOfAnimals = 20,
                    DelitingDate = null,
                    Id = 2,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName(),
                    Cost = 400
                },
                    new FarmEntity
                {
                    AmountOfAnimals = 1,
                    DelitingDate = null,
                    Id = 3,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName(),
                    Cost = 100
                },
                      new FarmEntity
                {
                    AmountOfAnimals = 100,
                    DelitingDate = null,
                    Id = 4,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName(),
                    Cost = 500
                },
                       new FarmEntity
                {
                    AmountOfAnimals = 50,
                    DelitingDate = null,
                    Id = 5,
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName(),
                    Cost = 500
                }

            };

            var mockedDbContext = new Mock<FarmContext>();

            _db = mockedDbContext.Object;
            var dbset = new FakeDbSet<FarmEntity>(_farms);

            mockedDbContext.Setup(x => x.FarmEntities)
                .Returns(() => dbset);

            _unitOfWork = new UnitOfWork(_db);

            _farmRepository = new FarmRepository(_db);

            _farmService = new FarmService(_unitOfWork);

            _farmController = new FarmController(_farmService);
        }

        [Test]
        public void GetAverageFarmsCost_TEST()
        {
            var res = _farmController.AverageFarmsCost();
            Assert.AreEqual(600, res);
        }

        [Test]
        public void GetAverageCostAnimal_TEST()
        {
            var expected = new List<double>() { 100.00d, 20.00d, 100.00d, 5.00d, 10.00d };
            var res = _farmController.GetAverageCostAnimal();
            var a = expected.SequenceEqual(res);
            Assert.IsTrue(a);
        }

        [Test]
        public void GetAverageCostAnimal_ById_TEST()
        {
            var res = _farmController.GetAverageCostAnimal(1);
            Assert.AreEqual(100, res);
        }

        [Test]
        public void GetAverageCostAnimal_ByGroupIds_TEST()
        {
            var ids = new List<int>() { 1, 2, 5 };
            var expected = new List<double>() { 100.00d, 20.00d, 10.00d };
            var res = _farmController.GetAverageCostAnimal(ids);
            var a = expected.SequenceEqual(res);
            Assert.IsTrue(a);
        }
    }
}