using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EmployeeSystemDeliverable.BLL.Services;
using EmployeeSystemDeliverable.BLL;

namespace EmployeeSystemDeliverable.ViewModels.Skill
{
    public class EditskillViewModel : EmployeeSystemDeliverable.ViewModels.MasterPageViewModel
    {
        private readonly SkillService skillService;

        public EditskillViewModel(SkillService skillService)
        {
            this.skillService = skillService;
        }

        public SkillDTO Skill { get; set; }

        [FromRoute("Id")]
        public int Id { get; set; }

        public override async Task PreRender()
        {
            Skill = await skillService.GetSkillById(Id);
        }
        public async Task UpdateSkill(int id)
        {
            await skillService.UpdateSkillAsync(Skill);
            Context.RedirectToRoute("Default");
        }

    }
}

