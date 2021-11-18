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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        private void btn_registrarme_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Mensaje", "¡Registro correcto!", "Aceptar");
        }


    }
}