using CRUD.Data;
using CRUD.Models;

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
    }
}
