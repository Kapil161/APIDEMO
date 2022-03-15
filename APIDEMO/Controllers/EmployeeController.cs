using APIDEMO.Model;
using APIDEMO.Repository.Contract;
using APIDEMO.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee employeeService;
        public EmployeeController(IEmployee employee)
        {
            employeeService = employee;
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult Get()
        {
            var results = employeeService.GetAllEmployees();
            if (results.Count > 0)
                return Ok(results);
            else
            {
                return NotFound("Employee Not Found here....!");
            }


        }
        [HttpGet]
        [Route("GetAllEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var results = employeeService.GetEmployeeById(id);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return NotFound("Employee Not Found..!");
            }
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var result = employeeService.PostEmployee(employee);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var emp = employeeService.DeleteEmployee(id);
                if (result!= null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            [HttpPut]
            [Route("UpdateEmployees")]

            public IActionResult Update(Employee emp)
            {
                if (emp == null)
                {
                    return BadRequest();
                }
                else
                {
                    var result = employeeService.UpdateEmployee(emp);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }

            }

            public IActionResult Update(Employee emp)
            {
                var eee = dbContext.Employee.SingleOrDefault(e => e.Id == emp.Id);
                if(eee!=null)
                {
                    eee.FirstName = emp.FirstName;
                    eee.LastName = emp.LastName;
                    eee.Email = emp.Email;
                    eee.Address = emp.Address;
                    dbContext.Employees.Update(eee);
                    dbContext.SaveChanges();
                    return emp;

                }
                return null;
            }
        } 
    }
}
