using CaseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseTracker.Data.Repo
{
    public class CaseRepository : ICaseRepository
    {
        private readonly DataContext dc;

        public CaseRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddCase(Case casess)
        {
            dc.Cases.AddAsync(casess);
        }

        public async Task<IEnumerable<Case>> GetCasesAsync()
        {
            return await dc.Cases.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
