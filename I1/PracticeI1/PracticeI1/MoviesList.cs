using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeI1
{
    class Movie
    {
        static private uint movieId = 0;
        public uint MovieId { get; }
        public string Name = "";
        public string Description = "";
        public int Year = 0;
        public Dictionary<string, float> PagesRating;
        public Dictionary<uint, int> UsersRatings;
        private float nadejeRating => MovieRater.NadejeRating(MovieId);
        public float Total => MovieRater.Score(PagesRating, nadejeRating);

        public Movie(string name, string description, int year, Dictionary<string, float> pagesRating)
        {
            MovieId = movieId++;
            UsersRatings = new Dictionary<uint, int>();
            Name = name;
            Year = year;
            PagesRating = pagesRating;
        }
    }

    class MoviesList
    {
        private Dictionary<string, Movie> movies;
        public Dictionary<uint, Movie> Movies { get; private set; }

        public MoviesList (Dictionary<string, PagesAdapter> serchPages)
        {
            Dictionary<string, Movie> pageMovies = new Dictionary<string, Movie>();
            foreach (KeyValuePair<string, PagesAdapter> page in serchPages)
            {
                pageMovies = page.Value.ReadData();

                foreach (KeyValuePair <string, Movie> movie in pageMovies)
                {
                    if (!movies.ContainsKey(movie.Key))
                    {
                        movies[movie.Key] = movie.Value;
                    }
                }

            }
        }
    }
}
