using Pre.Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Movies.Core
{
    public class FilterMovies
    {
        //define the delegates
        public delegate Movie FilterMovieDelegate(List<Movie> movies);
        public delegate List<Movie> FilterMoviesDelegate<T>(T filter, List<Movie> movies);
        
        //write a callback method
        public Movie FilterToMovie(List<Movie> movies, FilterMovieDelegate filterMovieDelegate)
        {
            return filterMovieDelegate.Invoke(movies);
        }
        //Generic delegates niet kennen voor het examen.
        public List<Movie> FilterToMovies<T>(T filter,List<Movie> movies,FilterMoviesDelegate<T> filterMoviesDelegate)
        {
            return filterMoviesDelegate.Invoke(filter, movies);
        }
    }
}
