using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseTracker.Models
{
    public class SupporEngineer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
        public string Email { get; set; }

        [ForeignKey("SupporEngineer")]
        public long userID { get; set; }

        public ICollection<Case> Cases { get; set; }

    }
}
