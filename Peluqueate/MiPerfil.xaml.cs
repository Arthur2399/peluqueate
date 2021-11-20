using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;


namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiPerfil : ContentPage
    {
        public MiPerfil()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btn_home_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_atras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btn_editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarPerfil());
        }
    }

  
}