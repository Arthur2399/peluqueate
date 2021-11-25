using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambiarContrasena : ContentPage
    {
        private const string url = "http://192.168.194.128:82/api/";
        private int _pk;
        public CambiarContrasena(int pk)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _pk = pk;
        }

        private async void BtnRContrasena_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasena1.Text.Equals(txtContrasena2.Text))
                {
                    WebClient web = new WebClient();
                    var request = new System.Collections.Specialized.NameValueCollection();
                    request.Add("user_contrasena", txtContrasena1.Text);
                    web.UploadValues(url + "usuarios/contrasena/"+_pk, "PUT", request);
                    await DisplayAlert("Correcto", "Guardado correctamente", "Ok");
                    await Navigation.PushAsync(new LoginUsuarios());
                }
                else
                {
                    await DisplayAlert("Error", "Contraseña no son iguales", "Ok");
                }
            }
            catch(Exception ex){
                    await DisplayAlert("Error", ex.Message, "Ok");

            }


        }
    }
}