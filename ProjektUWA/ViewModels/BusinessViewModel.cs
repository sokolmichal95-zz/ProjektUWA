using Newtonsoft.Json;
using ProjektUWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUWA.ViewModels
{
    public class BusinessViewModel : ViewModel
    {

        #region Properties

        private Rootobject data;
        public Rootobject Data
        {
            get { return data; }
            set { data = value; }
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

        public List<Dataobject> GetBusinesses()
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

        private async void GetData(string url)
        {
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);
            Data = JsonConvert.DeserializeObject<Rootobject>(response);
        }

        private async void GetData(string url, string name)
        {
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url + name);
            Data = JsonConvert.DeserializeObject<Rootobject>(response);
        }

        #endregion
    }
}
