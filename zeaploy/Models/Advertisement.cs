namespace zeaploy.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Company Name")]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Display(Name = "Hourly Wage")]
        public int Wage { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Job Type")]
        public string JobType { get; set; }

        [Required]
        [StringLength(30)]
        public string Location { get; set; }

        public DateTime Posted { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

#nullable enable
        [Display(Name = "Company Logo")]
        public string? ImagePath { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Application>? Applications { get; set; }
    }
}
