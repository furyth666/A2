using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A2.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }


        [Required]
        public float Rating { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Poster Image")]
        public string PosterPath { get; set; }

        public string Developer { get; set; }


        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // New reference to GameType
        public int GameTypeId { get; set; } // Foreign key
        public virtual GameType GameType { get; set; } // Navigation property
    }
}