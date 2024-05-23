namespace CRUD.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
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
