using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Payroll
    {
        [Key]
        public int payroll_id { get; set; }

        public int emp_id { get; set; }

        public string month { get; set; }

        public decimal basic_salary { get; set; }

        public decimal deduction { get; set; }

        public decimal net_salary { get; set; }
    }
}