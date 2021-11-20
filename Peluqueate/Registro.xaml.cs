using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peluqueate.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Ciudades> _provincias;
        private ObservableCollection<Peluqueate.Models.Ciudades> _ciudades;
        private ObservableCollection<Peluqueate.Models.Usuarios> _pkUsuario;


        public Registro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            provincias();
            PkrCiudades.IsEnabled = false;
            genero();
        }

        private async void provincias()
        {
            var content = await client.GetStringAsync(url+ "ciudades/provincias");
            List<Peluqueate.Models.Ciudades> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Ciudades>>(content);
            _provincias = new ObservableCollection<Peluqueate.Models.Ciudades>(posts);
             PkProvincias.ItemsSource = _provincias;
        }

        private async void genero()
        {
            PkrGenero.Items.Add("Hombre");
            PkrGenero.Items.Add("Mujer");
            PkrGenero.Items.Add("Otro");
        }


        private async void btn_registrarme_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient web = new WebClient();
                var code = PkrCiudades.SelectedItem as Peluqueate.Models.Ciudades;
                int ciudad = code.id_ciudades;
                char gn = PkrGenero.SelectedItem.ToString().FirstOrDefault();
                string date = JsonConvert.SerializeObject(txtFecha.Date);
                if (txtContrasena1.Text.Equals(txtContrasena2.Text))
                {
                    var request = new System.Collections.Specialized.NameValueCollection();
                    request.Add("id_ciudades", ciudad.ToString());
                    request.Add("user_nombre", txtNombre.Text);
                    request.Add("user_apellido", txtApellido.Text);
                    request.Add("user_fechnacimiento", date);
                    request.Add("user_email", txtEmail.Text);
                    request.Add("user_genero", gn.ToString());
                    request.Add("user_contrasena", txtContrasena1.Text);
                    web.UploadValues(url + "usuarios", "POST", request);
                    var content = await client.GetStringAsync(url + "usuarios/login/" + txtEmail.Text);
                    List<Peluqueate.Models.Usuarios> post = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
                    _pkUsuario = new ObservableCollection<Peluqueate.Models.Usuarios>(post);
                    var pk = ((Peluqueate.Models.Usuarios)_pkUsuario[0]).id_usuarios;
                   
                   await DisplayAlert("Guardado", "Guardado Correctamente"+pk.ToString(), "Ok");
                   await Navigation.PushAsync(new MainPage(pk,"usr"));
                }
                else
                {
                await DisplayAlert("Error", "Contraseña Diferente","OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message,"OK");
            }
        }
        private async void ciudades(int codtab)
        {
            var content = await client.GetStringAsync(url + "ciudades/ciud/"+codtab);
            List<Peluqueate.Models.Ciudades> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Ciudades>>(content);
            _ciudades= new ObservableCollection<Peluqueate.Models.Ciudades>(posts);
            PkrCiudades.ItemsSource = _ciudades;
            PkrCiudades.IsEnabled = true;
        }

        private void PkProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var code = PkProvincias.SelectedItem as Peluqueate.Models.Ciudades;
            int cod = code.ciu_codtab;
            ciudades(cod);

        }
    }
}