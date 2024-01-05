using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBootcamp_Project_1.Context;
using NetBootcamp_Project_1.Models;

namespace NetBootcamp_Project_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly TechCareerDbContext _context;

        public CompanyController()
        {
            _context = new TechCareerDbContext();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _context.Companies.ToList();
            return Ok(companies);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null) return NotFound();
            else return Ok(company);
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (company == null) return BadRequest("Geçersiz veri.");

            company.AddDate = DateTime.Now;
            _context.Companies.Add(company);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, company);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Company company)
        {
            if (company == null) return BadRequest();

            var existingCompany = _context.Companies.Find(id);
            if (existingCompany == null)
            {
                return NotFound();
            }

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            _context.Update(existingCompany);
            _context.SaveChanges();
            return Ok(existingCompany);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(r => r.Id == id);

            if (company == null) return NotFound();
            else
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
                return Ok(company);
            }
        }
    }
}
