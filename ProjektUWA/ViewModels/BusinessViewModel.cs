using Newtonsoft.Json;
using ProjektUWA.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace ProjektUWA.ViewModels
{
    public class BusinessViewModel : ViewModel
    {

        #region Properties

        private ObservableCollection<Dataobject> listOfBusinesses;
        public ObservableCollection<Dataobject> ListOfBusinesses
        {
            get
            {
                return listOfBusinesses;
            }
            set
            {
                listOfBusinesses = value;
                OnPropertyChanged("ListOfBusinesses");
            }
        }

        private Rootobject rootData;
        public Rootobject Data
        {
            get { return rootData; }
            set { rootData = value; }
        }

        #endregion

        #region Constructor

        public BusinessViewModel()
        {
            GetData("https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json");
        }

        public BusinessViewModel(string name)
        {
            GetData("https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json?conditions[q]=", name);
        }

        #endregion

        public ObservableCollection<Dataobject> GetBusinesses()
        {
            return Data.Dataobject;
        }

        #region JsonPageNavigation

        public void GetNextPage()
        {
            GetData(Data.Links.next);
        }

        public void GetPreviousPage()
        {
            GetData(Data.Links.prev);
        }

        public void GetFirstPage()
        {
            GetData(Data.Links.first);
        }

        public void GetLastPage()
        {
            GetData(Data.Links.last);
        }

        #endregion

        #region RESTApiConsumer

        private void GetData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            var status = content.Status;
            Data = JsonConvert.DeserializeObject<Rootobject>(content.Result);
            ListOfBusinesses = Data.Dataobject;
        }

        private void GetData(string url, string name)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            response = client.GetAsync(url + name).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            var status = content.Status;
            Data = JsonConvert.DeserializeObject<Rootobject>(content.Result);
            ListOfBusinesses = Data.Dataobject;
        }

        #endregion
    }
}
