using System.ComponentModel.DataAnnotations;

namespace Banking_System.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? UserImageUrl { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Balance { get; set; }

    }
}
