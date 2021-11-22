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
    public partial class RegistrarPreguntas : ContentPage
    {
        public RegistrarPreguntas()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void bt_registrarme_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUsuarios());
        }
    }
}