using AutoMapper;
using FictionalCustomer.WebApp.Data;
using FictionalCustomer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DataController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Is null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Is null");
        }

        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult<DataTablesResponse>> GetEmployees()
        {
            try
            {
                var emplyeesUnMapped = await _context!.Employees!.ToListAsync();

                var employeesMapped = _mapper.Map<List<EmployeeModel>>(emplyeesUnMapped);

                var response = new DataTablesResponse
                {
                    RecordsTotal = employeesMapped.Count,
                    RecordsFiltered = 10,
                    Data = employeesMapped.ToArray()
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong with the server");
            }
        }

        [HttpGet]
        [Route("projects")]
        public async Task<ActionResult<DataTablesResponse>> GetProjects()
        {
            try
            {
                var projectsUnMapped = await _context!.Projects!.ToListAsync();

                var projectsMapped = _mapper.Map<List<ProjectModel>>(projectsUnMapped);

                var response = new DataTablesResponse
                {
                    RecordsTotal = projectsMapped.Count,
                    RecordsFiltered = 10,
                    Data = projectsMapped.ToArray()
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong with the server");
            }
        }
    }
}

