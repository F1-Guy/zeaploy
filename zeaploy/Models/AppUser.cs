namespace zeaploy.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(100)]
        public string? Course { get; set; }

        [StringLength(100)]
        public string? JobTitle { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        public string? ImagePath { get; set; }

        public ICollection<Application>? Applications { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
