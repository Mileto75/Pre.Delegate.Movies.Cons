// See https://aka.ms/new-console-template for more information
using Pre.Movies.Core;
using Pre.Movies.Core.Entities;
using System.Diagnostics.Contracts;
using System.Globalization;

Console.WriteLine("Get the movies");
MovieRepository movieRepository = new MovieRepository();
Console.WriteLine("Fetching movies");
var movies = await movieRepository.GetMovies();
foreach (var movie in movies)
{
    Console.WriteLine($"{movie.Title} : {movie.BoxOffice}: {movie.Year}");
}
PrintLines();
//use a callback with delegate
var filterMovies = new FilterMovies();
PrintLines();
Console.WriteLine("Highest rated");
var highestRated = filterMovies.FilterToMovie(movies, (List<Movie> movies) => 
{
    //define a movie with highestRating = movies[0]
    var movieWithHighestRating = movies[0];
    //loop over movies and get the movie with the highest rating
    foreach (var movie in movies)
    {
        if (movie.Rating > movieWithHighestRating.Rating)
        {
            movieWithHighestRating = movie;
        }
    }
    return movieWithHighestRating;
});

Console.WriteLine($"{highestRated.Title}:{highestRated.Rating}");
PrintLines();

//var thrillers = GetMoviesByGenre("Thriller",movies);
var thrillers = filterMovies.FilterToMovies("Thriller",movies,(string filter,List<Movie> movies)=>
    {
        var filteredByGenre = new List<Movie>();
        //loop over the movies
        foreach (var movie in movies)
        {
            if (movie.Genre.Contains(filter))
            {
                filteredByGenre.Add(movie);
            }
        }
        return filteredByGenre;
    }
    );
//get the films from the USA using callback delegate
var usaFilms = filterMovies.FilterToMovies("USA",movies,
    (string filter,List<Movie> movies) =>
    {
        var usaMovies = new List<Movie>();
        foreach(var movie in movies)
        {
            if (movie.Country.Equals("USA")) ;
            {
                usaMovies.Add(movie);
            }
        }
        return usaMovies;
    }
    );
PrintLines();
foreach(var movie in usaFilms)
{
    Console.WriteLine($"{movie.Title} : {movie.Country}");
}
PrintLines();
//filter on year using generic callback method
var moviesByYear = filterMovies.FilterToMovies(2003, movies, (int year, List<Movie> movies) =>
{
    var moviesByYear = new List<Movie>();
    foreach (var movie in movies)
    {
        if (movie.Year.Equals(year))
        {
            moviesByYear.Add(movie);
        }
    }
    return moviesByYear;
});
foreach (var movie in moviesByYear)
{
    Console.WriteLine($"{movie.Title} : {movie.Year}");
}
PrintLines();
Console.WriteLine("Thrillers");
foreach (var movie in thrillers)
{
    Console.WriteLine(movie.Title);
}
//filter functions
List<Movie> GetMoviesByGenre(string genre,List<Movie> movies)
{
    var filteredByGenre = new List<Movie>();
    //loop over the movies
    foreach(var movie in movies)
    {
        //loop over genres
        //foreach(var movieGenre in movie.Genre)
        //{
        //    if (movieGenre.Equals(movieGenre))
        //    {
        //        filteredByGenre.Add(movie);
        //    }
        //}
        if (movie.Genre.Contains(genre))
        {
            filteredByGenre.Add(movie);
        }
    }
    //get the movies of a genre

    return filteredByGenre;
}

List<Movie> GetMoviesByCountry(string country, List<Movie> movies)
{
    return new List<Movie>();
}

List<Movie> GetMoviesByYear(int Year, List<Movie> movies)
{
    return new List<Movie>();
}

List<Movie> GetMoviesByRating(double rating,List<Movie> movies)
{
    return new List<Movie>();
}

decimal ParseBoxOffice(string boxOffice)
{
    //replace . with ,

    //loop over characters and get the digits,',' and $ chars

    //parse to decimal with NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")

    //check if boxoffice contains billion => * 1000

    return 0;
}
Movie GetHighestGrossing(List<Movie> movies)
{
    //use ParseBoxOffice to get the BoxOffice as decimal
    return new Movie();
}
void PrintLines()
{
    Console.WriteLine("----------------------------------");
    Console.WriteLine("----------------------------------");
}

