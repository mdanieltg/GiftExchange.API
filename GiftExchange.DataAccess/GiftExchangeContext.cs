using GiftExchange.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GiftExchange.DataAccess
{
    public class GiftExchangeContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=gifted;Uid=ef;Pwd=123456;SslMode=Preferred;";

        public GiftExchangeContext()
        {
        }

        public GiftExchangeContext(DbContextOptions<GiftExchangeContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<LoginLink> LoginLinks { get; set; }
        public DbSet<InvitationLink> InvitationLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }
    }
}
