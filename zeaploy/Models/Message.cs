namespace zeaploy.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
