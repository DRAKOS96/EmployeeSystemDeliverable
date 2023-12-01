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
    public class DetailSkillViewModel : EmployeeSystemDeliverable.ViewModels.MasterPageViewModel
    {
        private readonly SkillService _skillService;

        public DetailSkillViewModel(SkillService skillService)
        {
            this._skillService = skillService;
        }

        [FromRoute("Id")]
        public int Id { get; set; }

        public SkillDTO Skill { get; set; }

        public override async Task PreRender()
        {
            Skill = await _skillService.GetSkillById(Id);
        }

        public async Task DeleteSkill()
        {

            await _skillService.DeleteSkillAsync(Id);
            Context.RedirectToRoute("Default");

        }
    }
}

