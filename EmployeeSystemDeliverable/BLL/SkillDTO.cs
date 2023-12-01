using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemDeliverable.BLL
{
    public class SkillDTO
    {

       
        public int idskills { get; set; }
        public string name { get; set; }

        public string desc { get; set; }

        public DateTime creation { get; set; }
    }
}
