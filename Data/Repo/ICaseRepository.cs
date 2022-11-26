using CaseTracker.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseTracker.Data.Repo
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetCasesAsync();

        void AddCase(Case casess);

        Task<bool> SaveAsync();
    }
}
