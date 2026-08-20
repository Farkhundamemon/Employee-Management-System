using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("designations")]
    public class Designation
    {
        [Key]
        public int designation_id { get; set; }

        public string title { get; set; }

        public int department_id { get; set; }
    }
}