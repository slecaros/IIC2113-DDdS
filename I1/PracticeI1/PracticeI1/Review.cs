using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeI1
{
    class Review
    {
        private int rating = 0;
        private string review_ = "";
        public string Review_ { get { return review_; } set { Console.WriteLine("No Implementado"); } }
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
            }
        }
        public uint UserId { get; }
        public uint MovieId { get; }

        public Review(uint userId, uint movieId)
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
}
