using System;
using System.ComponentModel.DataAnnotations;

namespace GiftExchange.DataAccess.Entities
{
    public class LoginLink
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Key { get; set; }

        public DateTime Expiration { get; set; }


        public User User { get; set; }
    }
}
