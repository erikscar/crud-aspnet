using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string Name { get; set; }

        [Display(Name = "Image Url")]
        [DataType(DataType.ImageUrl)]
        [Url(ErrorMessage = "Please Insert a valid URL ")]
        public string ImageUrl { get; set; }
        //Associação do Departamento com o Fornecedor
        public ICollection<Provider> Providers { get; set; } = new List<Provider>();

        public Department()
        {
        }

        public Department(int id, string name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
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
