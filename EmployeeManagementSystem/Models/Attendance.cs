using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
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