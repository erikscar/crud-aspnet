namespace CRUD.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Associação do Departamento com o Fornecedor
        public ICollection<Provider> Providers { get; set; } = new List<Provider>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddProvider(Provider provider)
        {
            Providers.Add(provider);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Providers.Sum(provider => provider.TotalSales(initial, final));
        }
    }
}
