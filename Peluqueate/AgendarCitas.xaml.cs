using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendarCitas : ContentPage
    {
        private int _pk;
        private string _tipo; private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Usuarios> _Usuario;
        private ObservableCollection<Peluqueate.Models.Local> _Local;

        public AgendarCitas(int pk,string tipo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            tener_usuario(pk);
            _pk = pk;
            _tipo = tipo;

        }

        private async void tener_usuario(int pk)
        {
            try { 
            var content = await client.GetStringAsync(url + "usuarios/" + pk);
            List<Peluqueate.Models.Usuarios> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
                _Usuario = new ObservableCollection<Peluqueate.Models.Usuarios>(posts);
                int pkCiudad = ((Peluqueate.Models.Usuarios)_Usuario[0]).id_ciudades;
                llenarlocal(pkCiudad);
            }
            catch
            {

            }
        }

        private async void llenarlocal(int pkCiudad)
        {
            try
            {
                var content = await client.GetStringAsync(url + "local/ciudad/" + pkCiudad);
                List<Peluqueate.Models.Local> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Local>>(content);
                _Local = new ObservableCollection<Peluqueate.Models.Local>(posts);
                PkrSucursal.ItemsSource = _Local;
            }
            catch
            {

            }
        }

        private async void bt_atras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_pk,_tipo));
        }

        private async void bt_siguiente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaCita());
        }

        private async void bt_verMapa_Clicked(object sender, EventArgs e)
        {
            var local = PkrSucursal.SelectedItem as Peluqueate.Models.Local;
            string lon = local.loc_longitud;
            string lat = local.loc_latitud;
            string nombre = local.loc_nombre;
            if (!double.TryParse(lat, out double latitud))
                return;
            if (!double.TryParse(lon, out double longitud))
                return;
            await Map.OpenAsync(latitud, longitud, new MapLaunchOptions {
                Name = nombre,
                NavigationMode = NavigationMode.Default

            });

        }
    }
}