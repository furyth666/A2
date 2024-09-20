using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A2.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public int Rating { get; set; }

        // Foreign Key
        public int GameId { get; set; }

        // Navigation property
        public virtual Game Game { get; set; }


    }
}