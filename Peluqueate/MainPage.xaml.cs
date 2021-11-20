using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Peluqueate
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnCambiarContrasena_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vistaCambiarContrasena());
        }

        private async void btnAgendarCita_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vistaAgendarCita());
        }

        private async void btnAgendarCita2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vista2AgendarCita());
        }

        private async void btnMisCitas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisCitasSemanales());
        }

        private async void btnDetalleCita_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetalleCita());
        }

        private async void btnVerCostos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new verCostos());
        }
    }
}
