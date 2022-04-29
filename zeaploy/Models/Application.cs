namespace zeaploy.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [Required]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
