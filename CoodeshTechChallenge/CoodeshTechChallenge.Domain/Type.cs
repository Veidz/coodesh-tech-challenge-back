using System.ComponentModel.DataAnnotations.Schema;

namespace CoodeshTechChallenge.Domain
{
    [Table("Types")]
    public class Type : Document
    {
        public string Description { get; set; } = string.Empty;
    }
}
