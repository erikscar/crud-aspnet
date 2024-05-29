namespace CRUD.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        //Construtor que passará uma mensagem de Erro a Classe Base no Caso ApplicationException
        public DbConcurrencyException(string message) : base(message) { }
    }
}
