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
    public class EditViewModel : EmployeeSystemDeliverable.ViewModels.MasterPageViewModel
    {
        private readonly EmployeeService _employeeService;

        public EditViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public EmployeeDTO Employee { get; set; }


        [FromRoute("Id")]
        public int Id {  get; set; }

        public override async Task PreRender()
        {
           Employee = await _employeeService.GetEmployeeById(Id);
        } 
        public async Task UpdateEmployee(int id)
        {
            await _employeeService.UpdateEmployeeAsync(Employee);
            Context.RedirectToRoute("Default");
        }

    }
}

