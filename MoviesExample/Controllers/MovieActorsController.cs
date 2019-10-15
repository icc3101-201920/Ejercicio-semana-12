using Models;
using MoviesExample.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesExample.Controllers
{
    public class MovieActorsController
    {
        List<MovieActor> moviesActors = new List<MovieActor>();
        SearchForm view;
        public List<MovieActor> MoviesActors { get => moviesActors; }

        public MovieActorsController(Form view, List<Movie> movies, List<Person> producers)
        {
            initialize(movies, producers);
            this.view = view as SearchForm;
            this.view.IndexItemSelected += OnItemIndexSelected;
        }
        public void initialize(List<Movie> movies, List<Person> actors)
        {
            moviesActors.Add(new MovieActor(movies[0], actors[0]));
            moviesActors.Add(new MovieActor(movies[1], actors[1]));
            moviesActors.Add(new MovieActor(movies[2], actors[2]));
            moviesActors.Add(new MovieActor(movies[0], actors[2]));
            moviesActors.Add(new MovieActor(movies[1], actors[0]));
            moviesActors.Add(new MovieActor(movies[2], actors[1]));
        }

        public void OnItemIndexSelected(object sender, ProfileEventArgs e)
        {
            List<MovieActor> moviesActorsResult = new List<MovieActor>();
            List<Movie> moviesResult = new List<Movie>();
            List<Person> actorsResult = new List<Person>();
            if (e.SelectedItem is Person)
            {
                Person p = e.SelectedItem as Person;
                if (p.Ocupation == "actor")
                {
                    moviesActorsResult = moviesActors.Where(t =>
                    t.Actor.Equals(p)).ToList();
                    foreach (MovieActor movieActor in moviesActorsResult)
                    {
                        moviesResult.Add(movieActor.Movie);
                    }
                    view.UpdateProfileResults<Movie>(moviesResult);
                }
                
            }
            if (e.SelectedItem is Movie)
            {
                Movie m = e.SelectedItem as Movie;
                moviesActorsResult = moviesActors.Where(t =>
                t.Movie.Equals(m)).ToList();
                foreach (MovieActor movieActor in moviesActorsResult)
                {
                    actorsResult.Add(movieActor.Actor);
                }
                view.UpdateProfileResults<Person>(actorsResult);
            }
        }
    }
}
