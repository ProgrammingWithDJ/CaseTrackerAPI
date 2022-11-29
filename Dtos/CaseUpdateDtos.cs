using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CaseTracker.Dtos
{
    public class CaseUpdateDtos
    {
    
           public string Workload { get; set; }

            public int Active { get; set; }

            public string Region { get; set; }

            [Column(TypeName = "Date")]
            public DateTime CloseDate { get; set; }

            public int Survey { get; set; }
        }

}
