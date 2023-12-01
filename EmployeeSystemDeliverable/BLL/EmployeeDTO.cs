using EmployeeSystemDeliverable.Data.Entities;
using System;
using System.Numerics;

namespace EmployeeSystemDeliverable.BLL
{
    public class EmployeeDTO
    {

        public int idemployee { get; set; }
      
        public string name {  get; set; }
        public string surname { get; set; }
        public DateTime hired { get; set; }

        public string skills { get; set; }
       

    }
}
