using ProjektUWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUWA.ViewModels
{
    class ListOfBusinessesViewModel : ViewModel
    {
        private List<Rootobject> data;
        public List<Rootobject> Data
        {
            get { return data; }
            set { data = value; }
        }

        public ListOfBusinessesViewModel()
        {

        }
    }
}
