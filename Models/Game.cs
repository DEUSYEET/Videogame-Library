using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Game_Library.Models
{
    public class Game
    {
        [Key]
        public int Index { get; set; }


        [Required(ErrorMessage ="Required", AllowEmptyStrings = false)]
        public string Title { get; set; } = "Default";



        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        public string Platform { get; set; } = "Default";


        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        public string Genre { get; set; } = "Default";

        [RegularExpression(@"^(RP)|(eC)|(E)|(E10)|(T)|(M)|(Ao)|(Not Rated)$", ErrorMessage = "Rating Must Be Either RP|eC|E|E10|T|M|Ao|Not Rated")]
        public string Rating { get; set; } = "Default";


        [Required(ErrorMessage ="Required", AllowEmptyStrings = false)]
        public int ReleaseYear { get; set; } = 0;


        [Required(ErrorMessage ="Required", AllowEmptyStrings = false), Url]
        public string Image { get; set; } = null;
        public string LoanedTo { get; set; } 
        public DateTime LoanDate { get; set; }
    }
}
