using first_app.Models;
using first_app.Services.impl;
using Microsoft.AspNetCore.Mvc;

namespace first_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //Get All Emp
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var emp = _employeeService.GetAllEmployees();
            return Ok(emp);
        }

        //Get Emp By ID
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _employeeService.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        //Post Method (Add Emp)
        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var add = _employeeService.AddEmployee(employee);
            return Ok(add); ;
        }

        //Delete By Id
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var employees = _employeeService.DeleteEmployee(id);
                return Ok(employees);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        //PUT Method (Update Employee)
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var employees = _employeeService.UpdateEmloyee(id, employee);
                return Ok(employees);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }
    }
}
