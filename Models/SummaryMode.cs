using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseTracker.Models
{
    public class SummaryMode
    {
        public int TotalCases { get; set; }

        public int TotalCaseToday { get; set; }

        public int TotalSurvey { get; set; }

        public int TotalClosed { get; set; }



    }
}
