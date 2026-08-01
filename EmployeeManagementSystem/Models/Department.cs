using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Dep_id { get; set; }

        public string Dep_name { get; set; }
    }
}