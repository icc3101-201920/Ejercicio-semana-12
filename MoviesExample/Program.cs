using MoviesExample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesExample
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WelcomeForm welcomeForm = new WelcomeForm();
            Application.Run(welcomeForm);
            SearchForm searchForm = new SearchForm();
            PersonController personController = new PersonController(searchForm);
            StudioController studioController = new StudioController(searchForm);
            MovieController movieController = new MovieController(searchForm, personController.People, studioController.Studios);
            MovieActorsController moviesActorsController = new MovieActorsController(searchForm, movieController.Movies, personController.People);
            MovieProducerController movieProducerController = new MovieProducerController(searchForm, movieController.Movies, personController.People);
            Application.Run(searchForm);
        }
    }
}
