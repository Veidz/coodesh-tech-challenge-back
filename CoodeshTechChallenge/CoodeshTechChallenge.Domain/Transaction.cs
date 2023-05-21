using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoodeshTechChallenge.Domain
{
    [Table("Transactions")]
    public class Transaction : Document
    {
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public int Product { get; set; }
        public decimal Price { get; set; }
        public int Seller { get; set; }
    }
}
