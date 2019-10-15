using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Movie
    {
        private string name;
        private Person director;
        private DateTime premiere;
        private string description;
        private double budget;
        private Studio studio;

        public Movie(string name, Person director, DateTime premiere, string description, double budget, Studio studio)
        {
            this.name = name;
            this.director = director;
            this.premiere = premiere;
            this.description = description;
            this.budget = budget;
            this.studio = studio;
        }

        public string Name { get => name; set => name = value; }
        public Person Director { get => director; set => director = value; }
        public DateTime Premiere { get => premiere; set => premiere = value; }
        public string Description { get => description; set => description = value; }
        public double Budget { get => budget; set => budget = value; }
        public Studio Studio { get => studio; set => studio = value; }
        int maxLength()
        {
            if (Description.Length > 30)
                return 30;
            else
                return Description.Length;
        }

        public override string ToString()
        {
            return Name + ", DATA | Director: " + Director.Name + " " + Director.LastName + " | Premiere: " + Premiere.ToShortDateString() + " | Description: " + Description.Substring(0, maxLength()) + "... | Budget: " + budget + " | Studio: " + Studio.Name;
        }
    }
}
