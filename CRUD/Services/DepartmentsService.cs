using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task <List<Department>> FindAllAsync()
        {
            //return _context.Department.ToList(); Podemos fazer dessa forma ou 
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); //Ou Buscar todos os departamentos ORDENADOS PELO NOME
        }
    }
}
