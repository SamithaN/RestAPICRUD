using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.Interface;
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Controllers
{
    
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee != null)
            {
                return Ok(_employeeData.GetEmployee(id));
            }
            return NotFound($"Employee with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + employee.Id, employee);
            
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with ID: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id,Employee employee)
        {
            var exsistingEmployee = _employeeData.GetEmployee(id);

            if (exsistingEmployee != null)
            {
                employee.Id = exsistingEmployee.Id;
                _employeeData.EditEmployee(employee);
                
            }

            return Ok(employee);
        }
    }
}
