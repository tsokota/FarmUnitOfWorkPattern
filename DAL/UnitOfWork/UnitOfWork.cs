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
        private IFarmContext db;

        private bool disposed;

        public UnitOfWork(IFarmContext context)
        {
            db = context;
            FarmRepository = new FarmRepository(context);
            //  _farmRepository.Init(db);
            disposed = false;
        }

        public IFarmRepository FarmRepository { get; }

        public int Save()
        {
            return db.SaveChanges();
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
