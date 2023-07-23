using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.Employee_Specs;

namespace Talabat.APIs.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IGenericRepositpry<Employee> _employeeRepo;

        public EmployeesController(IGenericRepositpry<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployees()
        {
            var spec = new EmployeeWitDepartmentSpecifications();

            var employees = await _employeeRepo.GetAllWithSpecAsync(spec);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployee(int id)
        {
            var spec = new EmployeeWitDepartmentSpecifications(id);

            var employee = await _employeeRepo.GetEntityWithSpecAsync(spec);

            return Ok(employee);
        }
    }
}
