namespace zeaploy.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Content { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        [Required]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
