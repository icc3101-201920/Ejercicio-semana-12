using MoviesExample.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesExample
{
    public partial class SearchForm : Form
    {

        //Event
        public event EventHandler<SearchEventArgs> Searching;
        public event EventHandler<IndexEventArgs> IndexButtonClicked;
        public event EventHandler<ProfileEventArgs> IndexItemSelected;

        int resultCounter = 0;
        List<Panel> stackPanels = new List<Panel>();
        Dictionary<string, Panel> panels = new Dictionary<string, Panel>();

        public SearchForm()
        {
            InitializeComponent();
            panels.Add("MainPanel", searchFormMainPanel);
            panels.Add("IndexPanel", searchFormIndexPanel);
            panels.Add("ProfilePanel", searchFormProfilePanel);
            stackPanels.Add(panels["MainPanel"]);
            ShowLastPanel();
        }

        private void SearchFormMainPanelSearchPanelTableTextInput_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchFormMainPanelSearchPanelTableTextInput.Text;
            List<string> results = new List<string>();
            if (searchText.Length >= 3)
            {
                CleanSearch();
                NoResult();
                if (Searching != null)
                {
                    Searching(this, new SearchEventArgs() { SearchText = searchText});
                    
                }
            }
        }
        private void NoResult()
        {
            searchFormMainPanelResultPanelResultList.Items.Add("No results for search criteria");
        }
        private void CleanSearch()
        {
            resultCounter = 0;
            searchFormMainPanelResultPanelResultList.Items.Clear();
        }

        public void UpdateResults(List<string> results)
        {
            if (results.Count > 0)
            {
                foreach (string result in results)
                {
                    if (resultCounter <= 50)
                    {
                        if (searchFormMainPanelResultPanelResultList.Items.Count > 0 && searchFormMainPanelResultPanelResultList.Items[0].Equals("No results for search criteria"))
                        {
                            searchFormMainPanelResultPanelResultList.Items.Add(result);
                            searchFormMainPanelResultPanelResultList.Items.RemoveAt(0);
                        }
                        else
                            searchFormMainPanelResultPanelResultList.Items.Add(result);
                        resultCounter++;
                    }
                }
            }
        }

        private void SearchFormMainPanelButtonPanelTableButtonMovies_Click(object sender, EventArgs e)
        {
            OnIndexButtonClicked("Movies", ButtonTypeClicked.movie, "");
        }

        public void UpdateIndexResults<T>(List<T> results)
        {
            searchFormIndexPanelListPanelListResult.Items.Clear();
            searchFormIndexPanelListPanelListResult.Items.Add("There are no elements on this category");
            foreach (T result in results)
            {
                if (searchFormIndexPanelListPanelListResult.Items.Count > 0 && searchFormIndexPanelListPanelListResult.Items[0].Equals("There are no elements on this category"))
                {
                    searchFormIndexPanelListPanelListResult.Items.Add(result);
                    searchFormIndexPanelListPanelListResult.Items.RemoveAt(0);
                }
                else
                    searchFormIndexPanelListPanelListResult.Items.Add(result);
            }

        }

        private void SearchFormMainPanelButtonPanelTableButtonActors_Click(object sender, EventArgs e)
        {
            OnIndexButtonClicked("Actors", ButtonTypeClicked.person, "actor");
        }

        private void SearchFormMainPanelButtonPanelTableButtonDirectors_Click(object sender, EventArgs e)
        {
            OnIndexButtonClicked("Directors", ButtonTypeClicked.person, "director");

        }

        private void SearchFormMainPanelButtonPanelTableButtonProducers_Click(object sender, EventArgs e)
        {
            OnIndexButtonClicked("Producers", ButtonTypeClicked.person, "producer");
        }

        private void SearchFormMainPanelButtonPanelTableButtonStudios_Click(object sender, EventArgs e)
        {
            OnIndexButtonClicked("Studios", ButtonTypeClicked.studio, "");
        }
        private void SearchFormIndexPanelListPanelListResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IndexItemSelected != null)
            {
                if (!searchFormIndexPanelListPanelListResult.SelectedItem.Equals("There are no elements on this category"))
                {
                    
                    stackPanels.Add(panels["ProfilePanel"]);
                    searchFormProfilePanelListPanelList.Items.Clear();
                    searchFormProfilePanelListPanelList.Items.Add("There are no elements");
                    ShowLastPanel();
                    IndexItemSelected(this, new ProfileEventArgs() { SelectedItem = searchFormIndexPanelListPanelListResult.SelectedItem });
                }
            }
            
        }
        private void SearchFormIndexPanelButtonPanelButtonTableGoBackButton_Click(object sender, EventArgs e)
        {
            OnBackButtonClicked();   
        }
    
        private void SearchFormPersonProfilePanelButtonPanelTablePanelGoBackButton_Click(object sender, EventArgs e)
        {
            OnBackButtonClicked();
        }

        //Metodos Internos
        private void OnIndexButtonClicked(string category, ButtonTypeClicked buttonType, string filter)
        {
            if (IndexButtonClicked != null)
            {
                stackPanels.Add(panels["IndexPanel"]);
                ShowLastPanel();
                searchFormIndexPanelTitlePanelTitle.Text = category;
                IndexButtonClicked(this, new IndexEventArgs() { ButtonType = buttonType, Filter = filter });
            }
        }

        private void OnBackButtonClicked()
        {
            stackPanels.RemoveAt(stackPanels.Count - 1);
            ShowLastPanel();
        }

        private void ShowLastPanel()
        {
            foreach (Panel panel in panels.Values)
            {
                if (panel != stackPanels.Last())
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Visible = true;
                }
            }
        }

        public void UpdateProfileInformationPanel(string prop1, string prop1Value, string prop2, string prop2Value, string prop3, string prop3Value, string prop4, string prop4Value)
        {
            searchFormProfilePanelInformationPanelTablePanelTableProp1.Text = prop1;
            searchFormProfilePanelInformationPanelTablePanelTableProp2.Text = prop2;
            searchFormProfilePanelInformationPanelTablePanelTableProp3.Text = prop3;
            searchFormProfilePanelInformationPanelTablePanelTableProp4.Text = prop4;
            searchFormProfilePanelInformationPanelTablePanelTableProp1Value.Text = prop1Value;
            searchFormProfilePanelInformationPanelTablePanelTableProp2Value.Text = prop2Value;
            searchFormProfilePanelInformationPanelTablePanelTableProp3Value.Text = prop3Value;
            searchFormProfilePanelInformationPanelTablePanelTableProp4Value.Text = prop4Value;
        }

        public void UpdateProfileResults<T>(List<T> results)
        {
            foreach (T result in results)
            {
                if (searchFormProfilePanelListPanelList.Items.Count > 0 && searchFormProfilePanelListPanelList.Items[0].Equals("There are no elements"))
                {
                    searchFormProfilePanelListPanelList.Items.Add(result);
                    searchFormProfilePanelListPanelList.Items.RemoveAt(0);
                }
                else
                    searchFormProfilePanelListPanelList.Items.Add(result);
            }

        }

        public void UpdateProfilePanelListPanelTitle(string title)
        {
            searchFormProfilePanelListPanelTitlePanelTitle.Text = title;
        }

        public void UpdateProfilePanelListPanelCritics(bool visible)
        {
            panel1.Visible= visible;
        }

    }
}
