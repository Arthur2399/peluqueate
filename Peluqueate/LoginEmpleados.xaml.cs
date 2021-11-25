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
    public partial class LoginEmpleados : ContentPage
    {
        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Empleados> _pkEmpleado;

        public LoginEmpleados()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient web = new WebClient();
                var content = await client.GetStringAsync(url + "empleados/login/" + txtEmail.Text);
                List<Peluqueate.Models.Empleados> post = JsonConvert.DeserializeObject<List<Peluqueate.Models.Empleados>>(content);
                _pkEmpleado = new ObservableCollection<Peluqueate.Models.Empleados>(post);
                var pk = ((Peluqueate.Models.Empleados)_pkEmpleado[0]).id_empleados;
                if (pk != 0)
                {
                    var request = new System.Collections.Specialized.NameValueCollection();
                    request.Add("empe_email", txtEmail.Text);
                    request.Add("empe_contrasena", txtContrasena.Text);
                    web.UploadValues(url + "empleados/login", "POST", request);
                    await Navigation.PushAsync(new MainPage(pk, "emp"));
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}