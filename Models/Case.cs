using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public int CaseNumber { get; set; }

        public string Workload { get; set; }

        public int Active { get; set;}

        public string Region { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfArrival { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CloseDate { get; set; }

        public int Survey { get; set; }

        public SupporEngineer engineer { get; set; } 

    }
}
