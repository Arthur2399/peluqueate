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
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }
        private async void btn_MiPerfil_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new MiPerfil());
        }

        private async void btn_MisCitas_Clicked(object sender, EventArgs e)
        {
            await App.MasterDet.Detail.Navigation.PushAsync(new VerCitas());
        }


        private async void btn_AgendarCitas_Clicked(object sender, EventArgs e)
        {
            await App.MasterDet.Detail.Navigation.PushAsync(new AgendarCitas());
        }

        private async void btn_AcercaDe_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new AcercaDe());
        }



        private async void btn_Salir_Clicked_1(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new LoginUsuarios());
        }
    }
}