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
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
