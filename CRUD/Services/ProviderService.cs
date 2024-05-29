using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public class ProviderService
    {
        private readonly CRUDContext _context;

        public ProviderService(CRUDContext context)
        {
            _context = context;
        }

        public List<Provider> FindAll()
        {
            //Irá Buscar Todos os Providers
            return _context.Provider.ToList();
        }

        public void Insert(Provider obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Provider FindById(int id)
        {
            //Utilizar o Include para Fazer um Join na Tabela Department, retornando assim o Provider e o Department
            return _context.Provider.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

        }
        public void Remove (int id )
        {
            var obj = _context.Provider.Find(id);
            _context.Provider.Remove(obj);
            _context.SaveChanges();
        }
    }
}
