using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyApi.Services.Contracts;
using CompanyApi.Web.Models;
using CompanyApi.Services.Models;

namespace CompanyApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyViewModel>> GetById(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            var companyResource = _mapper.Map<Company, CompanyViewModel>(company);

            return Ok(companyResource);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<CompanyViewModel>>> GetAll()
        {
            var companies = await _companyService.GetAll();

            var result = _mapper.Map<List<CompanyViewModel>>(companies);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<CompanyViewModel>> Create(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyToCreate = _mapper.Map<CompanyViewModel, Company>(companyViewModel);

            var newCompanyId = await _companyService.Create(companyToCreate);

            var company = await _companyService.GetById(newCompanyId);

            var companyResource = _mapper.Map<Company, CompanyViewModel>(company);

            return Ok(companyResource);
        }

        [HttpPut("")]
        public async Task<ActionResult<CompanyViewModel>> Update(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = _mapper.Map<CompanyViewModel, Company>(companyViewModel);

            await _companyService.Update(company);

            var updatedCompany = await _companyService.GetById(company.Id);
            var updatedCompanyResource = _mapper.Map<Company, CompanyViewModel>(updatedCompany);

            return Ok(updatedCompanyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var company = await _companyService.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            await _companyService.Delete(id);

            return NoContent();
        }


        [HttpGet("{companyId}/users")]
        public async Task<ActionResult<CompanyViewModel>> GetAllCompanyUsers(int companyId)
        {
            var users = await _companyService.GetAllCompanyUsers(companyId);

            var result = _mapper.Map<CompanyViewModel>(users);

            return Ok(result);
        }
    }
}