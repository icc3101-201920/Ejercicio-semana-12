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
    public class MovieController
    {
        List<Movie> movies = new List<Movie>();
        SearchForm view;

        public List<Movie> Movies { get => movies; }

        public MovieController(Form view, List<Person> people, List<Studio> studios)
        {
            initialize(people, studios);
            this.view = view as SearchForm;
            this.view.Searching += OnSearchTextChanged;
            this.view.IndexButtonClicked += OnMoviesButtonClicked;
            this.view.IndexItemSelected += OnItemIndexSelected;
        }
        public void initialize(List<Person> people, List<Studio> studios)
        {
            movies.Add(new Movie("Volando con Brad", people[3], new DateTime(2018, 2, 5), "Una tarde volando con James", 1000000, studios[0]));
            movies.Add(new Movie("Estudiando con Andres", people[4], new DateTime(2017, 2, 5), "Una tarde des estudio con Kim", 1000000, studios[1]));
            movies.Add(new Movie("Howard, Perez o Cea", people[5], new DateTime(2018, 3, 5), "Carlos nos entrega una critica de Howardo", 1000000, studios[2]));
        }
        public void OnSearchTextChanged(object sender, SearchEventArgs e)
        {
            List<Movie> resultMovies = new List<Movie>();
            List<String> resultString = new List<string>();
            resultMovies = movies.Where(t =>
            t.Name.ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Director.Name.ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Director.LastName.ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Premiere.ToShortDateString().ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Description.ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Budget.ToString().ToUpper().Contains(e.SearchText.ToUpper()) ||
            t.Studio.Name.ToUpper().Contains(e.SearchText.ToUpper()))
            .ToList();

            if (resultMovies.Count > 0)
            {
                resultString.Add("-----Movies Found-----");
                foreach (Movie movie in resultMovies)
                    resultString.Add(movie.ToString());
            }

            
            view.UpdateResults(resultString);
        }

        public void OnMoviesButtonClicked(object sender, IndexEventArgs e)
        {
            if (e.ButtonType == ButtonTypeClicked.movie)
            {
                view.UpdateIndexResults<Movie>(movies);
            }
        }

        public void OnItemIndexSelected(object sender, ProfileEventArgs e)
        {
            List<Movie> moviesResult = new List<Movie>();
            if (e.SelectedItem is Person)
            {
                Person p = e.SelectedItem as Person;
                if (p.Ocupation == "director")
                {
                    moviesResult = Movies.Where(t =>
                    t.Director.Equals(p)).ToList();
                    view.UpdateProfileResults<Movie>(moviesResult);
                }

            }
            if (e.SelectedItem is Movie)
            {
                view.UpdateProfilePanelListPanelTitle("People that participated in the movie");
                view.UpdateProfilePanelListPanelCritics(true);
            }
        }
    }
}
