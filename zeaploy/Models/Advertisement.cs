namespace zeaploy.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Company { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        public int Wage { get; set; }
        [Required]
        [StringLength(50)]
        public string JobType { get; set; }
        public DateTime Posted { get; set; }   
        [Required]
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
