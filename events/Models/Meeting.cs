using System;
using System.ComponentModel.DataAnnotations;

namespace events.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [Required]

        public ApplicationUser User { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public String Venue { get; set; } // مكان الحدث 

        [Required]
        public Genre Genre { get; set; } //نوع الحدث
    }


   
}