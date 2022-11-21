using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Banking_System.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int AmountOfMoney { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey("FromId")]
        public virtual Customer? customerFrom { get; set; }

        [ForeignKey("ToId")]
        public virtual Customer? customerTo { get; set; }

    }
}
