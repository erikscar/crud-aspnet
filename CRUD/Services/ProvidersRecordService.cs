using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public class ProvidersRecordService
    {
        private readonly CRUDContext _context;

        //Injeção de Depêndencia
        public ProvidersRecordService(CRUDContext context)
        {
            _context = context;
        }

        public async Task<List<ProvidersRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //Obtendo um resultado do Providers Record e transformando em IQuerable
            var result = from obj in _context.ProvidersRecord select obj;

            if(minDate.HasValue)
            {
                //Compondo o que foi buscado em uma expressão maior
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if(maxDate.HasValue) 
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Provider) //Fazendo um JOIN com a tabela Provider
                .Include(x => x.Provider.Department) //Fazendo um JOIN com a tabela Department
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, ProvidersRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            //Obtendo um resultado do Providers Record e transformando em IQuerable
            var result = from obj in _context.ProvidersRecord select obj;

            if (minDate.HasValue)
            {
                //Compondo o que foi buscado em uma expressão maior
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Provider) //Fazendo um JOIN com a tabela Provider
                .Include(x => x.Provider.Department) //Fazendo um JOIN com a tabela Department
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Provider.Department)
                .ToListAsync();
        }
    }
}
