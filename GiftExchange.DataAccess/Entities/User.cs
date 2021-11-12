using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GiftExchange.DataAccess.Entities
{
    [Index("Email", IsUnique = true)]
    public class User
    {
        public User()
        {
            OwnedExchanges = new HashSet<Exchange>();
            Profiles = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsVerified { get; set; }
        public DateTime RegistrationDate { get; set; }


        public ICollection<Exchange> OwnedExchanges { get; set; }
        public ICollection<UserProfile> Profiles { get; set; }
        public LoginLink LoginLink { get; set; }
    }
}
