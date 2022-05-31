namespace zeaploy.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

#nullable enable
        [StringLength(30)]
        public string? Course { get; set; }

        [StringLength(30)]
        [Display(Name = "Job Title")]
        public string? JobTitle { get; set; }

        [StringLength(30)]
        public string? Location { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ImagePath { get; set; }

        public ICollection<Application>? Applications { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
