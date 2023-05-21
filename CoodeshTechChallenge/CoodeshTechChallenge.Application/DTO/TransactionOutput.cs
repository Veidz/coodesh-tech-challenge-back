using System;

namespace CoodeshTechChallenge.Application.DTO
{
    public class TransactionOutput
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Seller { get; set; } = string.Empty;
    }
}
