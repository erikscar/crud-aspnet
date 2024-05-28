using CRUD.Data;
using CRUD.Models;

namespace CRUD.Services
{
    public class DepartmentsService
    {
        private readonly CRUDContext _context;

        //Injeção de Dependência do Banco de Dados
        public DepartmentsService(CRUDContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            //return _context.Department.ToList(); Podemos fazer dessa forma ou 
            return _context.Department.OrderBy(x => x.Name).ToList(); //Ou Buscar todos os departamentos ORDENADOS PELO NOME
        }
    }
}
