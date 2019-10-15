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
    public class PersonController
    {

        List<Person> people = new List<Person>();
        SearchForm view;

        public List<Person> People { get => people; }
        public PersonController(Form view)
        {
            initialize();
            this.view = view as SearchForm;
            this.view.Searching += OnSearchTextChanged;
            this.view.IndexButtonClicked += OnPersonButtonClicked;
            this.view.IndexItemSelected += OnItemIndexSelected;
        }
        public void initialize()
        {
            people.Add(new Person("Brad", "Pitt", new DateTime(1968, 2, 5), "Actor americano, rubio y simpatico", "actor"));
            people.Add(new Person("Andres", "Perez", new DateTime(1964, 2, 5), "Actor español, ciervo y  no simpatico", "actor"));
            people.Add(new Person("Billy", "Cea", new DateTime(1992, 2, 5), "Actor chileno, estudiante y filantropo", "actor"));
            people.Add(new Person("Andres", "Howard", new DateTime(1970, 2, 5), "Director, estudiante, filantropo, padre de familia...", "director"));
            people.Add(new Person("James", "Howardo", new DateTime(1972, 2, 5), "Erase una vez un director...", "director"));
            people.Add(new Person("Billy", "Pitts", new DateTime(1980, 2, 5), "Director con frase tipica: Una vez vi un joven juvenil", "director"));
            people.Add(new Person("John", "Cena", new DateTime(1965, 2, 5), "Productor..Se me acaban las ideas de descripcion...", "producer"));
            people.Add(new Person("Carlos", "Gonzalez", new DateTime(1970, 2, 5), "Poductor ingles, mundialmente conocido", "producer"));
            people.Add(new Person("Kim", "Perez", new DateTime(1978, 2, 5), "Poductor chileno de origen chileno", "producer"));
        }

        public void OnSearchTextChanged(object sender, SearchEventArgs e)
        {
            List<Person> resultPeople = new List<Person>();
            List<String> resultString = new List<string>();
            resultPeople = people.Where(t =>
               t.Name.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.LastName.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.Bio.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.Ocupation.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.BirthDate.ToShortDateString().Contains(e.SearchText.ToUpper()))
           .ToList();
            if (resultPeople.Count > 0)
            {
                resultString.Add("-----People Found-----");
                foreach (Person p in resultPeople)
                    resultString.Add(p.ToString());
            }
            view.UpdateResults(resultString);
        }

        public void OnPersonButtonClicked(object sender, IndexEventArgs e)
        {
            if (e.ButtonType == ButtonTypeClicked.person)
            {
                List<Person> resultPeople = new List<Person>();
                resultPeople = people.Where(t =>
                    t.Ocupation.ToUpper().Equals(e.Filter.ToUpper())).ToList();

                view.UpdateIndexResults<Person>(resultPeople);
            }
            

        }

        public void OnItemIndexSelected(object sender, ProfileEventArgs e)
        {
            if (e.SelectedItem is Person)
            {
                Person p = e.SelectedItem as Person;
                view.UpdateProfileInformationPanel("Name", $"{p.Name} {p.LastName}", "Birthdate", p.BirthDate.ToShortDateString(), "Ocupation", p.Ocupation, "Bio", p.Bio);
                view.UpdateProfilePanelListPanelTitle("Movies where he/she participated");
                view.UpdateProfilePanelListPanelCritics(false);
            }
        }
    }
}
