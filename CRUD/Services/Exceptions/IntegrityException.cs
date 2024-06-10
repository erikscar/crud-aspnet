namespace CRUD.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        //Exceção personalizada para servições ERROS DE INTEGRIDADE REFERENCIAL
        //Quando tentamos excluir um provider que possui registro de vendas
        public IntegrityException(string message) : base(message) { }

    }
}
