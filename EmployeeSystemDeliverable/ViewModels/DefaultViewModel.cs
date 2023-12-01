using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EmployeeSystemDeliverable.BLL;
using EmployeeSystemDeliverable.BLL.Services;
using EmployeeSystemDeliverable.Data.Entities;

namespace EmployeeSystemDeliverable.ViewModels
{

        public class DefaultViewModel : MasterPageViewModel
        {
            private readonly EmployeeService _employeeService;

            private readonly SkillService _skillService;

            public string Title { get; set; }

            public DefaultViewModel(EmployeeService employeeService, SkillService skillService)
            {

                this._employeeService = employeeService;

                this._skillService = skillService;
            }

            [Bind(Direction.ServerToClient)]
            public List<EmployeeDTO> Employees { get; set; }

        

            [Bind(Direction.ServerToClient)]
            public List<SkillDTO> Skills { get; set; }

            public override async Task PreRender()
            {
                Employees = await _employeeService.GetAllEmployeesAsync();
                Skills = await _skillService.GetAllSkillsAsync();

            await base.PreRender();
            }

           



        }
 }
