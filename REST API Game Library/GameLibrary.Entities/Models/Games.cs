using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Entities
{
    public class Games
    {
        [Key]
        public int GameLibraryID { get; set; }

        [Required]
        [Display(Name = "Game Name")]
        [MinLength(2, ErrorMessage = "Name must be at lest 2 Characters")]
        [MaxLength(64, ErrorMessage = "Name can't be logner than 64 Characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Game System")]
        public string GameSystem { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 seconds")]
        public int Rating { get; set; }
    }
}
