using CaseTracker.Data.Repo;
using CaseTracker.Interfaces;
using System.Threading.Tasks;

namespace CaseTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICaseRepository CaseRepository => new CaseRepository(dc);

        public async Task<bool> SaveChangesAsync()
        {
           return await dc.SaveChangesAsync() > 0;
        }
    }
}
