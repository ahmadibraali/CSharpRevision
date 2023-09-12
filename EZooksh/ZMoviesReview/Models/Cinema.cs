using System.ComponentModel.DataAnnotations;

namespace ZMoviesReview.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsProducer { get; set; }
    }
}
