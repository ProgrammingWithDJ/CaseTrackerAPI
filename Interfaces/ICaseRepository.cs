using CaseTracker.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseTracker.Interfaces
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetCasesAsync();

        void AddCase(Case casess);

      
    }
}
