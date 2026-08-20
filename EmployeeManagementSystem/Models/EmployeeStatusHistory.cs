using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("employee_status_history")]
    public class EmployeeStatusHistory
    {
        [Key]
        public int history_id { get; set; }

        public int emp_id { get; set; }

        public string old_status { get; set; }

        public string new_status { get; set; }

        public string changed_by { get; set; }

        public DateTime changed_date { get; set; }
    }
}