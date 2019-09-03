using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private FarmContext db = new FarmContext();

        private IFarmRepository _farmRepository;

        private bool disposed;

        public UnitOfWork(FarmContext fc, IFarmRepository r)
        {
            db = fc;
            _farmRepository = r;
            disposed = false;
        }

        public IFarmRepository FarmRepository
        {
            get
            {
                //if (_farmRepository == null)
                //{
                //    _farmRepository = new FarmRepository(_farmStorage);
                //}

                return _farmRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
