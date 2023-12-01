using EmployeeSystemDeliverable.Data;
using EmployeeSystemDeliverable.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeSystemDeliverable.BLL.Services
{
    public class SkillService
    {
        private readonly CompanyDbContext _companyDbContext;

        public SkillService(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }

        public async Task<SkillDTO> GetSkillById(int Id)
        {
            var skillDto = await Task.Run(() => _companyDbContext.Skills.Where(z => z.idskills == Id)?.Select(
               z => new SkillDTO
               {
                   idskills = z.idskills,
                   name = z.name,
                   desc = z.desc,
                   creation = z.creation,
               }).FirstOrDefault());

            return skillDto;
        }

        public async Task<List<SkillDTO>> GetAllSkillsAsync()
        {
            var skillItems = new List<SkillDTO>();

            skillItems = await Task.Run(() => _companyDbContext.Skills.Select(n => new SkillDTO
            {
                idskills = n.idskills,
                name = n.name,
                desc = n.desc,
                creation = n.creation,

            }).ToList());

            return skillItems;
        }

        public async Task<Skill> CreateSkillAsync(SkillDTO skill)
        {
            Skill skillNew = new Skill()
            {
                idskills = skill.idskills,
                name = skill.name,
                desc = skill.desc,
                creation = skill.creation,  
            };
            _companyDbContext.Add(skillNew);
            await _companyDbContext.SaveChangesAsync();

            return skillNew;

        }

        public async Task<HttpStatusCode> DeleteSkillAsync(int id)
        {
            Skill skillDelete = new Skill()
            {
                idskills = id
            };

            _companyDbContext.Attach(skillDelete);
            _companyDbContext.Remove(skillDelete);
            await _companyDbContext.SaveChangesAsync();
            return HttpStatusCode.OK;


        }

        public async Task<SkillDTO> UpdateSkillAsync(SkillDTO skill)
        {
            var Myskill = await _companyDbContext.Skills.Where(_ => _.idskills == skill.idskills).FirstOrDefaultAsync();



            Myskill.idskills = skill.idskills;
            Myskill.name = skill.name;
            Myskill.desc = skill.desc;

            Myskill.creation = skill.creation;

            await _companyDbContext.SaveChangesAsync();

            return skill;
        }
    }
}
