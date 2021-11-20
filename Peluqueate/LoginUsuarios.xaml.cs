using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUsuarios : ContentPage
    {

        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Usuarios> _pkUsuario;

        public LoginUsuarios()
        {
            InitializeComponent();
            lbRegistrarFucn();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        void  lbRegistrarFucn()
        {
            lb_registrar.GestureRecognizers.Add( new TapGestureRecognizer()
            { 
                Command = new Command(() =>
                {
                     Navigation.PushAsync(new Registro());
                }
                )
            });

        }

        private async void btn_IniciarSesion_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient web = new WebClient();
                var content = await client.GetStringAsync(url + "usuarios/login/" + txtEmail.Text);
                List<Peluqueate.Models.Usuarios> post = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
                _pkUsuario = new ObservableCollection<Peluqueate.Models.Usuarios>(post);
                var pk = ((Peluqueate.Models.Usuarios)_pkUsuario[0]).id_usuarios;
                if (pk != 0)
                {
                    var request = new System.Collections.Specialized.NameValueCollection();
                    request.Add("user_email", txtEmail.Text);
                    request.Add("user_contrasena", txtContrasena.Text);
                    web.UploadValues(url + "usuarios/login", "POST", request);
                    await Navigation.PushAsync(new MainPage(pk,"usr"));
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", Convert.ToString(ex.Message), "Ok");
            }
        }
    }
}