using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZMoviesReview.Data.Enums;

namespace ZMoviesReview.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }

        public MovieCategory movieCategory { get; set; }


        #region Relationships With Movie

        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Cinema
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; } 
        #endregion
    }
}
