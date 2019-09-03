using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork
    {
        private FarmStorage _farmStorage;

        private IFarmRepository _farmRepository;

        public UnitOfWork()
        {
            _farmStorage = new FarmStorage();
        }

        public IFarmRepository FarmRepository
        {
            get
            {
                if(_farmRepository== null)
                {
                    _farmRepository = new FarmRepository(_farmStorage);
                }

                return _farmRepository;
            }
        }
    }
}
