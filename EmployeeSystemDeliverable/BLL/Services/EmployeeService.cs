using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using EmployeeSystemDeliverable.Data.Entities;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Numerics;
using EmployeeSystemDeliverable.Data;
using System;


namespace EmployeeSystemDeliverable.BLL.Services
{
    public class EmployeeService
    {
        private readonly CompanyDbContext _companyDbContext;

        public EmployeeService(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }



        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employeeItems = new List<EmployeeDTO>();

            employeeItems = await Task.Run(() => _companyDbContext.Employee.Select(x => new EmployeeDTO
            {
                idemployee = x.idemployee,
                name = x.name,
                surname = x.surname,
                hired = x.hired,
                skills = x.skills,
               
            }).ToList());

            return employeeItems;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            var employeeDto = await Task.Run(() => _companyDbContext.Employee.Where(e => e.idemployee == Id)?.Select(
                m=> new EmployeeDTO
                {
                    idemployee= m.idemployee,
                    name = m.name,
                    surname = m.surname,
                    hired = m.hired,
                    skills = m.skills,
                }).FirstOrDefault());

            return employeeDto;
        }



        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var MyEmployee = await _companyDbContext.Employee.Where(_ => _.idemployee == employee.idemployee).FirstOrDefaultAsync();

           

            MyEmployee.idemployee = employee.idemployee;
            MyEmployee.name = employee.name;
            MyEmployee.surname = employee.surname;
           
            MyEmployee.skills = employee.skills;

            await _companyDbContext.SaveChangesAsync();
            
            return employee;
        }



        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employee)
        {
            Employee employeeNew = new Employee()
            {
                idemployee = employee.idemployee,
                name = employee.name,
                surname = employee.surname,
                hired = DateTime.Now,
                skills = employee.skills,
                
            };
            _companyDbContext.Add(employeeNew);
            await _companyDbContext.SaveChangesAsync();

            return employee;

        }

        public async Task<HttpStatusCode> DeleteEmployeeAsync(int id)
        {
            Employee employeeDelete = new Employee()
            {
                idemployee = id
            };

            _companyDbContext.Attach(employeeDelete);
            _companyDbContext.Remove(employeeDelete);
            await _companyDbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
                
        
        }

    }
}

  
