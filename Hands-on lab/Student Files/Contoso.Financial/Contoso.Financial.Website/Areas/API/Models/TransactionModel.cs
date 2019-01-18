namespace Contoso.Financial.Website.Areas.API.Models
{
    public class TransactionModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}