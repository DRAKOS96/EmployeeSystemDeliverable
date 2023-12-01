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
    public class DetailViewModel : MasterPageViewModel
    {
        private readonly EmployeeService employeeService;

        public DetailViewModel(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [FromRoute("Id")]
        public int Id { get; set; }

        public EmployeeDTO Employee { get; set; }

        public override async Task PreRender()
        {
            Employee = await employeeService.GetEmployeeById(Id);
        }


        public async Task DeleteEmployee()
        {

            await employeeService.DeleteEmployeeAsync(Id);
            Context.RedirectToRoute("Default");

        }


    }
}

