namespace zeaploy.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(100)]
        public string? Course { get; set; }
        [StringLength(100)]
        public string? JobTitle { get; set; }
        public ICollection<Application>? Applications { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
