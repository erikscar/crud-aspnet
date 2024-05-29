using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
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
