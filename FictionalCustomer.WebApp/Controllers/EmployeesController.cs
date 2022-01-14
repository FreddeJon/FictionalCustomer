using AutoMapper;
using FictionalCustomer.Core.Entitites;
using FictionalCustomer.WebApp.Data;
using FictionalCustomer.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace FictionalCustomer.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        [Route("/admin/api/employees")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var emplyeesUnMapped = await _context!.Employees!.ToListAsync();
            return emplyeesUnMapped;
        }

        [HttpGet]
        [Route("user")]
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

    }
}

