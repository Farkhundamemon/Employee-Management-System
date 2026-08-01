using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        [Key]
        public int leave_id { get; set; }

        public int emp_id { get; set; }

        public string leave_type { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public string reason { get; set; }

        public string status { get; set; }
    }
}