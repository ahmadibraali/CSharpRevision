using System.ComponentModel.DataAnnotations;

namespace ZMoviesReview.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Profile Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        #region Relationships With Producer
        public List<Movie> Movies { get; set; }

        #endregion
    }
}
