using CaseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Case> Cases{get;set;}
    }
}
