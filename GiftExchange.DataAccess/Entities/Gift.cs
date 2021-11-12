using System.ComponentModel.DataAnnotations;

namespace GiftExchange.DataAccess.Entities
{
    public class Gift
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }


        public UserProfile UserProfile { get; set; }
    }
}
