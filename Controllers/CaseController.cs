using CaseTracker.Data;
using CaseTracker.Interfaces;
using CaseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CaseTracker.Dtos;
using System;

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

            var casesDTO = from c in cases
                           select new CaseDtos()
                           {
                               CaseNumber = c.CaseNumber,
                               Active= c.Active,
                               Survey  =    c.Survey,
                               DateOfArrival= c.DateOfArrival,
                               CloseDate  = c.CloseDate,
                               Region= c.Region,
                               Workload= c.Workload
                               
                           };

            return Ok(casesDTO);
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
        public async Task<IActionResult> AddCases(CaseDtos caseDto)
        {
            var casesINrepo = new Case
            {
                CaseNumber = caseDto.CaseNumber,
                Workload = caseDto.Workload,
                Region = caseDto.Region,
                Active = 1,
                Survey = 0,
                DateOfArrival = DateTime.Now


            };

              uow.CaseRepository.AddCase(casesINrepo);
            await uow.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}
