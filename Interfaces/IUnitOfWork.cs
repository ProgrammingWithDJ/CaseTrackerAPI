using System.Threading.Tasks;

namespace CaseTracker.Interfaces
{
    public interface IUnitOfWork
    {
        ICaseRepository CaseRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
