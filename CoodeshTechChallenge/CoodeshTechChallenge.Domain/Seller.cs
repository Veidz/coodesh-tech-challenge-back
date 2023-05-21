using System.ComponentModel.DataAnnotations.Schema;

namespace CoodeshTechChallenge.Domain
{
    [Table("Sellers")]
    public class Seller : Document
    {
        public string Name { get; set; } = string.Empty;
    }
}
