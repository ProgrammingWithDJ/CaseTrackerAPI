using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseTracker.Dtos
{
    public class CaseDtos
    {

            [Required (ErrorMessage ="Case number is Required")]
             
            public int CaseNumber { get; set; }

            [Required]
            public string Workload { get; set; }
            
            public int Active { get; set; }

            [Required]
            public string Region { get; set; }

            [Column(TypeName = "Date")]
            public DateTime DateOfArrival { get; set; }

            [Column(TypeName = "Date")]
            public DateTime CloseDate { get; set; }
            public int Survey { get; set; }
        }

}
