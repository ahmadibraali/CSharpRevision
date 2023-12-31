﻿using System.ComponentModel.DataAnnotations;

namespace ZMoviesReview.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        #region Relationships With Cinema
        public List<Movie> Movies { get; set; }
        #endregion


    }
}
