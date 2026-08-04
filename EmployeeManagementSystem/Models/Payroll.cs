using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("payroll")]
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