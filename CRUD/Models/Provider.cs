using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3,  ErrorMessage = "{0} Size Should be Between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a Valid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Range(100.0, 5000.00, ErrorMessage = "{0} Must be From {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }


        public Department Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public ICollection<ProvidersRecord> Sales { get; set; } = new List<ProvidersRecord>();

        public Provider ()
        {
        }

        public Provider(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(ProvidersRecord pr)
        {
            Sales.Add(pr);
        }
        public void RemoveSales(ProvidersRecord pr)
        {
            Sales.Remove(pr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(pr => pr.Date >= initial && pr.Date <= final).Sum(pr => pr.Amount);
        }
    }
}
