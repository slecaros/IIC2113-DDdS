using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeI1
{
    class MovieRater
    {
        static private MoviesList movies;
        static private Dictionary<string, int[]> minMaxRates = new Dictionary<string, int[]>()
        {
            ["IMDB"] = new int[2] { 1, 10 },
            ["Metacritics"] = new int[2] { 1, 100 },
            ["rotten"] = new int[2] { 1, 100 },
            ["Nadeje"] = new int[2] { 1, 5 }
        };

        static private float normalice(string page, float score)
        {
            return (score - minMaxRates[page][0]) / (minMaxRates[page][1] - minMaxRates[page][0]);
        }

        static public float NadejeRating(uint movieId)
        {
            float sumScores = 0;
            int reviews = 0;
            foreach (int review in movies.Movies[movieId].UsersRatings.Values)
            {
                sumScores += review;
                reviews++;
            }
            if (sumScores != 0)
                return sumScores / reviews;
            return 0;
        }

        static public float Score(Dictionary<string, float> pagesRating, float nadejeRating)
        {
            float sumScores = 0;
            int reviews = 1;
            foreach (KeyValuePair<string, float> pageRate in pagesRating)
            {
                sumScores += MovieRater.normalice(pageRate.Key, pageRate.Value);
                reviews++;
            }
            if (nadejeRating != 0)
            {
                sumScores += nadejeRating;
                reviews++;
            }
            if (sumScores != 0)
                return sumScores / reviews;
            return 0;
        }


    }
}
