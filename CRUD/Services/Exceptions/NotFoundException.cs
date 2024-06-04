namespace CRUD.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //Construtor que passará uma mensagem de Erro a Classe Base no Caso ApplicationException
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
