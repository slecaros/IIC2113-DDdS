using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Name
{
    // Different users of the app, each have a unique Id
    // Assuming there will be more than one user
    class User
    {
        private static uint nextUserId = 0;
        public uint UserId { get; set { } }

        public void User()
        {
            UserId = nextUserId++;
        }

    }

    // Reviews from users of the Nadeje app
    class Review
    {
        private int rating = 0;
        public string rewiew { get; private set; } = "";
        public int Rating
        {
            get { return rating; }
            private set
            {
                if ((int)value < 1)
                    rating = 1;
                else if ((int)value > 5)
                    rating = 5;
                else
                    rating = (int)value;
                modifyTime = DateTime.Now;
            }
        }
        DateTime modifyTime;
        public uint UserId { get; }
        public uint MovieId { get; }

        public void Review(uint userId, uint movieId)
        {
            this.UserId = userId;
            this.MovieId = movieId;
        }

        public void AddRating()
        {
            int newRating;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese su calificacion (entre 1 y 5 estrellas)");
                    newRating = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Tiene que ser un entero entre 1 y 5 \n");
                }
            }
            Rating = newRating;
        }

    }

    class MovieRater
    {
        static private MoviesList movies;
        static private var minMaxRates = new Dictionary<string, int[2]>
        {
            ["IMDB"] = new int[2] { 1, 10 },
            ["Metacritics"] = new int[2] { 1, 100 },
            ["rotten"] = new int[2] { 1, 100 },
            ["Nadeje"] = new int[2] { 1, 5 }
        };

        static public void MovieRater(MoviesList movies)
        {
            this.movies = movies;
        }

        static private float normalice(string page, float score)
        {
            return (score - minMaxRates[page][0]) / (minMaxRates[page][1] - minMaxRates[page][0]);
        }

        static public float NadejeRating(uint movieId)
        {
            float sumScores = 0;
            int reviews = 0;
            foreach (Review review in movies.AllMovies[movieId])
            {
                sumScores += review.Rating;
                reviews++;
            }
            return sumScores / reviews;
        }

        static public float Score(Dictionary<string, float> pagesRating, float nadejeRating)
        {
            float sumScores = 0;
            int reviews = 0;
            // foreach...
        }


    }
    class Movie
    {
        static private uint movieId = 0;
        public uint MovieId { get; }
        public string Name;
        public string Description;
        public int year;
        public Dictionary<string, float> PagesRating;
        private float nadejeRating { get { MovieRater.NadejeRating(MovieId); } }
        public float Total { get { MovieRater.Score(PagesRating, nadejeRating); } }
    }

}


// class Solution
// {
//     static void Main(String[] args)
//     {

//     }
// }
// }
