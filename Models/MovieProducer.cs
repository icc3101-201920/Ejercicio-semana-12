using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MovieProducer
    {
        Movie movie;
        Person producer;

        public MovieProducer(Movie movie, Person producer)
        {
            this.movie = movie;
            this.producer = producer;
        }

        public Movie Movie { get => movie; set => movie = value; }
        public Person Producer { get => producer; set => producer = value; }
    }
}
