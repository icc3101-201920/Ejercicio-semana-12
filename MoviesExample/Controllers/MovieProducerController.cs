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
    public class MovieProducerController
    {
        List<MovieProducer> moviesProducers = new List<MovieProducer>();
        SearchForm view;
        public List<MovieProducer> MoviesProducers { get => moviesProducers; }

        public MovieProducerController(Form view, List<Movie> movies, List<Person> producers)
        {
            initialize(movies, producers);
            this.view = view as SearchForm;
            this.view.IndexItemSelected += OnItemIndexSelected;
        }
        public void initialize(List<Movie> movies, List<Person> producers)
        {
            MoviesProducers.Add(new MovieProducer(movies[0], producers[6]));
            MoviesProducers.Add(new MovieProducer(movies[1], producers[7]));
            MoviesProducers.Add(new MovieProducer(movies[2], producers[8]));
        }

        public void OnItemIndexSelected(object sender, ProfileEventArgs e)
        {
            List<MovieProducer> moviesProducerResult = new List<MovieProducer>();
            List<Movie> moviesResult = new List<Movie>();
            List<Person> producersResult = new List<Person>();
            if (e.SelectedItem is Person)
            {
                Person p = e.SelectedItem as Person;
                if (p.Ocupation == "producer")
                {
                    moviesProducerResult = MoviesProducers.Where(t =>
                    t.Producer.Equals(p)).ToList();
                    foreach (MovieProducer movieProducer in moviesProducerResult)
                    {
                        moviesResult.Add(movieProducer.Movie);
                    }
                    view.UpdateProfileResults<Movie>(moviesResult);
                }

            }
            if (e.SelectedItem is Movie)
            {
                Movie m = e.SelectedItem as Movie;
                moviesProducerResult = MoviesProducers.Where(t =>
                t.Movie.Equals(m)).ToList();
                foreach (MovieProducer movieProducer in moviesProducerResult)
                {
                    producersResult.Add(movieProducer.Producer);
                }
                view.UpdateProfileResults<Person>(producersResult);
            }
        }
    }
}
