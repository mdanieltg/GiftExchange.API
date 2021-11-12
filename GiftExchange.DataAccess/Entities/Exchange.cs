using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftExchange.DataAccess.Entities
{
    public class Exchange
    {
        public Exchange()
        {
            Participants = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        public int OrganizerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
        public EventVisibility Visibility { get; set; }
        public float? LowerBudgetLimit { get; set; }
        public float? UpperBudgetLimit { get; set; }
        public bool HasStarted { get; set; }
        public DateTime EventDate { get; set; }


        public User Organizer { get; set; }
        public ICollection<UserProfile> Participants { get; set; }
        public InvitationLink InvitationLink { get; set; }
    }
}
