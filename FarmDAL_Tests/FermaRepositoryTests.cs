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

        [SetUp]
        public void Setup()
        {
            _farms = new List<FarmEntity>
            {
                new FarmEntity
                {
                    AmountOfAnimals = Faker.NumberFaker.Number(0, 100),
                    DelitingDate = null,
                    Id = Faker.NumberFaker.Number(0, 100),
                    IsDelete = false,
                    Name = Faker.CompanyFaker.Name(),
                    OwnerName = Faker.NameFaker.MaleName()
                }
            };

            var mockedDbContext = new Mock<FarmContext>();

            mockedDbContext.Setup(x => x.FarmEntities)
                .Returns(() => new FakeDbSet<FarmEntity>(_farms));

            _unitOfWork = new UnitOfWork(mockedDbContext.Object);


            _farmRepository = new FarmRepository(mockedDbContext.Object);
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
    }
}