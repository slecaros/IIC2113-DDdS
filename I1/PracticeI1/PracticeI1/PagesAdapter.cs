using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PracticeI1
{
    abstract class PagesAdapter
    {
        protected Dictionary<string, string> standardKey;
        public Dictionary<string, Movie> PageMovies { get; protected set; }
        protected string filePath;

        // read the movie data and standarize the keys
        public Dictionary<string, Movie> ReadData()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                Console.WriteLine(array);
            }
            return PageMovies;
        }
    }

    class IMDB : PagesAdapter
    {
        public IMDB ()
        {
            filePath = @"./../../JSON/imdb.json";
            PageMovies = new Dictionary<string, Movie>();
            standardKey = new Dictionary<string, string>()
            {
                ["title"] = "name",
                ["score"] = "rating",
                ["description"] = "summary",
                ["year"] = "year"
            };
        }
    }
}
