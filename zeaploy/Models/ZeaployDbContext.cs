namespace zeaploy.Models
{
    public class ZeaployDbContext : IdentityDbContext<AppUser>
    {
        public ZeaployDbContext()
        {

        }

        public ZeaployDbContext(DbContextOptions<ZeaployDbContext> options)
            :base(options)
        {

        }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
    }
}
