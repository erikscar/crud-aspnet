using CRUD.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ProvidersRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
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
