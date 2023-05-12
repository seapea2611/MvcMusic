using System.ComponentModel.DataAnnotations;

namespace MvcMusic.Models
{
    public class Music
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }


        public string ReleaseDate { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string Genre { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Rating { get; set; }
    }
}
