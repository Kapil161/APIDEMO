using APIDEMO.Model;
using APIDEMO.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDEMO.Repository.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly ApplicationDbContext dbContext;
        

        public EmployeeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Employee GetEmployeeById(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public Employee PostEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            if (emp!=null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }

        public Employee UpdateEmployee(Employee emp)
        {
            dbContext.Employees.Update(emp);
            dbContext.SaveChanges();
            return emp;
        }
    }
}
