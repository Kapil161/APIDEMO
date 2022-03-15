using APIDEMO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDEMO.Repository.Contract
{
     public interface IEmployee
    {
        List<Employee> GetAllEmployees();
        Employee PostEmployee(Employee employee);
        Employee GetEmployeeById(int Id);
        Employee DeleteEmployee(int Id);
        Employee UpdateEmployee(Employee emp);

    }
}
