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
using AutoMapper;
using System.Collections.Generic;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CaseController(IUnitOfWork Uow, IMapper mapper)
        {
            
         
            uow = Uow;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetCases()
        {
            var cases = await uow.CaseRepository.GetCasesAsync();

            var casesDTO = mapper.Map<IEnumerable<CaseDtos>>(cases);

           
            return Ok(casesDTO);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCase(int id)
        {
            var cases = await uow.CaseRepository.FindCase(id);

            if (cases != null)
            {
                return Ok(cases);
            }
            else
                return NotFound();

        }


        [HttpPost]
        public async Task<IActionResult> AddCases(CaseDtos caseDto)
        {

            var casesInRepo = mapper.Map<Case>(caseDto);

            casesInRepo.Active = 1;
            casesInRepo.Survey = 0;
            casesInRepo.DateOfArrival = DateTime.Now;
            

           uow.CaseRepository.AddCase(casesInRepo);
            await uow.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}
