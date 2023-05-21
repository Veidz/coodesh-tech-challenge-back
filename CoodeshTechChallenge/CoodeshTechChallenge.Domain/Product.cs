using System.ComponentModel.DataAnnotations.Schema;

namespace CoodeshTechChallenge.Domain
{
    [Table("Products")]
    public class Product : Document
    {
        public string Name { get; set; } = string.Empty;
    }
}
