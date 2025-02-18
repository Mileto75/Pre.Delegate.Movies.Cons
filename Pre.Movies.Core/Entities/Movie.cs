using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Movies.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Genre { get; set; }
        public double Rating { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int Runtime { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
    }


}
