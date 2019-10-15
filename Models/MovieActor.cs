using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MovieActor
    {
        Movie movie;
        Person actor;

        public MovieActor(Movie movie, Person actor)
        {
            this.movie = movie;
            this.actor = actor;
        }

        public Movie Movie { get => movie; set => movie = value; }
        public Person Actor { get => actor; set => actor = value; }
    }
}
