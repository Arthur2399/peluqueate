using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Peluqueate
{
    public partial class MainPage : MasterDetailPage
    {
        
        public MainPage(int pk,string tipo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new Master(pk,tipo);
            this.Detail = new NavigationPage(new Detail(pk,tipo));      
            App.MasterDet = this;

        }
    }
}
