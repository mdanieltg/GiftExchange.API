using System.ComponentModel.DataAnnotations;

namespace GiftExchange.WebAPI.Models
{
    public class UserForCreation
    {
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
