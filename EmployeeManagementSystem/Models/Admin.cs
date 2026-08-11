using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("admin")]
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }

        public string username { get; set; }

        public string password { get; set; }
    }
}