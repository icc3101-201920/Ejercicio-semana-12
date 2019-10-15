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
    public class StudioController
    {
        List<Studio> studios = new List<Studio>();
        SearchForm view;

        public List<Studio> Studios { get => studios; }
        public StudioController(Form view)
        {
            initialize();
            this.view = view as SearchForm;
            this.view.Searching += OnSearchTextChanged;
            this.view.IndexButtonClicked += OnStudiosButtonClicked;
        }
        public void initialize()
        {
            studios.Add(new Studio("Kim Estudios", "Avenida Gonzalez 11229", new DateTime(1981, 2, 5)));
            studios.Add(new Studio("Pitts Howard", "Avenida Cea Howardo 123", new DateTime(1975, 2, 5)));
            studios.Add(new Studio("John Cena", "Brad Pitt 458 depto 301", new DateTime(1982, 2, 5)));
        }

        public void OnSearchTextChanged(object sender, SearchEventArgs e)
        {
            List<Studio> resultStudios = new List<Studio>();
            List<String> resultString = new List<string>();
            resultStudios = studios.Where(t =>
               t.Name.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.Address.ToUpper().Contains(e.SearchText.ToUpper()) ||
               t.OpeningDate.ToShortDateString().Contains(e.SearchText.ToUpper()))
           .ToList();
            if (resultStudios.Count > 0)
            {
                resultString.Add("-----Studios Found-----");
                foreach (Studio s in resultStudios)
                    resultString.Add(s.ToString());
            }
            view.UpdateResults(resultString);
        }

        public void OnStudiosButtonClicked(object sender, IndexEventArgs e)
        {
            if (e.ButtonType == ButtonTypeClicked.studio)
            {
                view.UpdateIndexResults<Studio>(studios);
            }
        }
    }
}
