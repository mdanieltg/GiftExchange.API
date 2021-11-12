using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftExchange.DataAccess.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Gifts = new HashSet<Gift>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExchangeId { get; set; }
        public int? GivingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public User User { get; set; }
        public Exchange Exchange { get; set; }
        public UserProfile Giving { get; set; }
        public ICollection<Gift> Gifts { get; set; }
    }
}
