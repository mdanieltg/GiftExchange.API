using System;
using System.ComponentModel.DataAnnotations;

namespace GiftExchange.DataAccess.Entities
{
    public class InvitationLink
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Key { get; set; }

        public DateTime Expiration { get; set; }


        public Exchange Exchange { get; set; }
    }
}
