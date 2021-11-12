using System;

namespace GiftExchange.WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
