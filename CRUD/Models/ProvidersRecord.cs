using CRUD.Models.Enums;

namespace CRUD.Models
{
    public class ProvidersRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Provider Provider { get; set; }

        public ProvidersRecord()
        {
        }

        public ProvidersRecord(int id, DateTime date, double amount, SaleStatus status, Provider provider)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Provider = provider;
        }
    }
}
