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
    public partial class PreguntasRespuestas : ContentPage
    {
        public PreguntasRespuestas()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void bt_siguiente_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new CambiarContrasena());
        }
    }
}