using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmployeeSystemDeliverable.Data.Entities
{
    public class Employee
    {
        [Key]
        public int idemployee   { get; set; }

        public string name { get; set; }

        public string surname { get; set; }
        public DateTime hired { get; set; }
        public string skills { get; set; }
  

    }


}
