using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemDeliverable.Data.Entities
{
    public class Skill
    {

        [Key]
        public int idskills { get; set; }
        public string name { get; set; }

        public string desc { get; set; }

        public DateTime creation { get; set; }

    }
}
