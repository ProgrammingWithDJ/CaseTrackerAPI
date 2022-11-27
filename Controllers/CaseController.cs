using CaseTracker.Data;
using CaseTracker.Interfaces;
using CaseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        
        
        private readonly IUnitOfWork uow;

        public CaseController(IUnitOfWork Uow)
        {
            
         
            uow = Uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetCases()
        {
            var cases = await uow.CaseRepository.GetCasesAsync();

            return Ok(cases);
        }


        //[HttpGet]
        //public async Task<IActionResult> GetCase(int casenumber)
        //{
        //    var cases = await dc.Cases.FindAsync(casenumber);

        //    if(casenumber!=null)
        //    {
        //        return Ok(cases);
        //    }  
        //    else
        //        return NotFound();
            
        //}


        [HttpPost]
        public async Task<IActionResult> AddCases(Case casesss)
        {
            Case cc=new Case();

            cc.CaseNumber = casesss.CaseNumber;
            cc.Region = casesss.Region;
            cc.Active = 1;
            cc.Survey = 0;
            cc.DateOfArrival=casesss.DateOfArrival;
            cc.Workload = casesss.Workload;
            
              uow.CaseRepository.AddCase(cc);
            await uow.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}
