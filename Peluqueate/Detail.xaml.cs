using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        private async void agendarUno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas());
        }

        private async void verUno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarDos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas());
        }

        private async void verDos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarTres_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas());
        }

        private async void verTres_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }

        private async void agendarCuatro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarCitas());
        }

        private async void verCuatro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerCitas());
        }
    }
}