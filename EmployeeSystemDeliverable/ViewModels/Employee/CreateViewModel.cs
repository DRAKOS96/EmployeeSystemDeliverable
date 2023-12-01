using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EmployeeSystemDeliverable.BLL.Services;
using EmployeeSystemDeliverable.BLL;

namespace EmployeeSystemDeliverable.ViewModels.Employee
{
    public class CreateViewModel : EmployeeSystemDeliverable.ViewModels.MasterPageViewModel
    {
        private readonly EmployeeService employeeService;

        public CreateViewModel(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public EmployeeDTO Employee { get; set; }= new EmployeeDTO();

        

        public async Task NewEmployee()
        {
            await employeeService.CreateEmployeeAsync(Employee);
           Context.RedirectToRoute("Default");
        }


    }

}

