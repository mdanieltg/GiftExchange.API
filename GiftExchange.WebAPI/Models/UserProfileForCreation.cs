using System.ComponentModel.DataAnnotations;

namespace GiftExchange.WebAPI.Models
{
    public class UserProfileForCreation
    {
        public int UserId { get; set; }
        public int ExchangeId { get; set; }
        public int? GivingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
