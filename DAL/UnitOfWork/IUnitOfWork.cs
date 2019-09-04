using DAL.Repositories;

namespace DAL
{
    public interface IUnitOfWork
    {
        IFarmRepository FarmRepository { get; }

        void Dispose();
        void Dispose(bool disposing);
        int Save();
    }
}