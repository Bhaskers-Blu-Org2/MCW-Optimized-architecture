using System;

namespace Contoso.Financial.Api.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}