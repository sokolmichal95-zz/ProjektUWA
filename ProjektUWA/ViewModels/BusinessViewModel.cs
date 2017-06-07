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
    class BusinessViewModel
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

        public BusinessViewModel(string name)
        {
            GetData("https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json?conditions[q]=", name);
        }
        
        #endregion

        #region RESTApiConsumer

        private async void GetData(string url, string name)
        {
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url+name);
            Data = JsonConvert.DeserializeObject<Rootobject>(response);
        }

        #endregion
    }
}
