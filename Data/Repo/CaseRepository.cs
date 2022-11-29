using CaseTracker.Interfaces;
using CaseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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


        [ResponseType(typeof(Case))]
        public async Task<Case> FindCase(int caseId)
        {
          Case casess= await dc.Cases.FirstOrDefaultAsync(x=> x.CaseNumber == caseId);

            return casess;
        }

        public async Task<IEnumerable<Case>> GetCasesAsync()
        {
            return await dc.Cases.ToListAsync();
        }

        
    }
}
