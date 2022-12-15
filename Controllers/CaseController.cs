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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
  [RequiredScope(RequiredScopesConfigurationKey ="AzureAd:Scopes")]
  [Authorize]
    [ApiController]
    public class CaseController : ControllerBase
    {

        static readonly string[] scopesByAPI = new string[] { "Case.Read" };
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CaseController(IUnitOfWork Uow, IMapper mapper)
        {
            
         
            uow = Uow;
            this.mapper = mapper;
        }

       
        [HttpGet]
      [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
       [Authorize(Roles = "Case.Read")]
        public async Task<IActionResult> GetCases()
        {
            var cases = await uow.CaseRepository.GetCasesAsync();

            var casesDTO = mapper.Map<IEnumerable<CaseDtos>>(cases);

           
            return Ok(casesDTO);
        }

        [Route("{id}")]
        [HttpGet]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(Roles = "Case.Read")]
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
       [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(Roles = "Case.Admin")]
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

        [HttpPut("reassign/{id}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(Roles = "Case.Read")]
        public async Task<IActionResult> UpdateCase(int id, CaseUpdateDtos caseToPatch)
        {
            var caseFromDb = await uow.CaseRepository.FindCase(id);
            
            mapper.Map(caseToPatch,caseFromDb);   

            await uow.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpGet("GetSummary")]
        public async Task<IActionResult> getCaseSummary()
        {
            var summaryfromcode = await uow.CaseRepository.GetSummary();


            return Ok(summaryfromcode);
        }
    }
}
