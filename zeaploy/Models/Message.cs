namespace zeaploy.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
