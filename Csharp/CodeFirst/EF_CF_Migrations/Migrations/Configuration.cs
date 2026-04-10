using System.Collections.Generic;

namespace EF_CF_Migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_CF_Migrations.CodeFirstContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF_CF_Migrations.CodeFirstContext context)
        {
            Department department = new Department
            {
                DepartmentName = "Technology",
                Employees = new List<Employee>
                {
                    new Employee() {EmployeeName = "Jayesh"},
                    new Employee() {EmployeeName = "Kunal"},
                    new Employee() {EmployeeName = "Sneh"}
                }
            };

            Employee employee = new Employee
            {
                EmployeeName = "Nakul Mittal",
                DepartmentId = 1
            };

            context.Departments.AddOrUpdate(department);
            context.Employees.AddOrUpdate(employee);
        }
    }
}