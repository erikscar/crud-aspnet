using CRUD.Data;
using CRUD.Models;
using CRUD.Services.Exceptions;
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

        public async Task<List<Provider>> FindAllAsync()
        {
            //Irá Buscar Todos os Providers
            return await _context.Provider.ToListAsync();
        }

        public async Task InsertAsync(Provider obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task <Provider> FindByIdAsync(int id)
        {
            //Utilizar o Include para Fazer um Join na Tabela Department, retornando assim o Provider e o Department
            return await _context.Provider.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Provider.FindAsync(id);
                _context.Provider.Remove(obj);
                await _context.SaveChangesAsync();
            }
            //Exceção lançada pelo Entity e iremos lançar a exceção personalizada
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
        public async Task UpdateAsync(Provider obj)
        {
            if (! await _context.Provider.AnyAsync(x => x.Id == obj.Id))
                {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                //Entity Framework pode lançar uma exceção de conflito de atualização, para evitar utilizamos o bloco TRY-CATCH
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            //Exceção de Acesso a Dados
            catch (DbUpdateConcurrencyException e)
            {
                //Transformando a Exceção em uma de Serviço para que seja separado as funções
                //Controlador lida com exceções de Acesso a Dados e Serviços Lida com as Exceções de Serviço
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
