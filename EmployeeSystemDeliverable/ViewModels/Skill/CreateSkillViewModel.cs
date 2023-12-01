using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EmployeeSystemDeliverable.BLL.Services;
using EmployeeSystemDeliverable.BLL;
using EmployeeSystemDeliverable.Data;



namespace EmployeeSystemDeliverable.ViewModels.Skill
{
    public class CreateSkillViewModel : EmployeeSystemDeliverable.ViewModels.MasterPageViewModel
    {
        private readonly SkillService skillService;

        public CreateSkillViewModel(SkillService skillService)
        {
            this.skillService = skillService;
        }
        public SkillDTO Skill { get; set; } = new SkillDTO();

        public async Task NewSkill()
        {
            await skillService.CreateSkillAsync(Skill);
            Context.RedirectToRoute("Default");
        }
    }
}

