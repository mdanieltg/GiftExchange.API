namespace GiftExchange.WebAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExchangeId { get; set; }
        public int? GivingId { get; set; }
        public string Name { get; set; }
    }
}
