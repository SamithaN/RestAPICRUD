using RestApiCRUD.Interface;
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Services
{
    public class EmployeeService : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Kamal"
            },new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Namal"
            },
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var exsistingEmployee = GetEmployee(employee.Id);
            exsistingEmployee.Name = employee.Name;
            return exsistingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
