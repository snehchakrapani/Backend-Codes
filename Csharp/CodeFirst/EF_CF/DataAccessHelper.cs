using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CF
{
    public class DataAccessHelper
    {
        readonly CodeFirstContext _dbContext = new CodeFirstContext();

        public List<Employee> FetchEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public List<Department> FetchDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public int AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee.EmployeeId;
        }

        public int AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department.DepartmentId;
        }
    }
}