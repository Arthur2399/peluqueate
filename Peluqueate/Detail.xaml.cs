using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        private int _pk;
        private string _tipo;
        
        public Detail(int pk,string tipo)
        {
            InitializeComponent();
            _pk = pk;
            _tipo = tipo;
        }

        private async void agendarUno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas(_pk,_tipo));
        }

        private async void verUno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarDos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas(_pk, _tipo));
        }

        private async void verDos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarTres_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas(_pk, _tipo));
        }

        private async void verTres_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarCuatro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas(_pk, _tipo));
        }

        private async void verCuatro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }
    }
}