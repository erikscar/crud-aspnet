namespace CRUD.Models.ViewModels
{
    public class ProviderFormViewModel
    {
        public Provider Provider { get; set; }
        //Usar os nomes dessa forma para que o sistema entenda os dados mais facilmente
        public ICollection<Department> Departments { get; set; }
    }
}
