using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("attendance")]
    public class Attendance
    {
        [Key]
        public int attentence_id { get; set; }

        public int emp_id { get; set; }

        public DateTime date { get; set; }

        public TimeSpan checkIn { get; set; }

        public TimeSpan checkOut { get; set; }

        public string status { get; set; }
    }
}