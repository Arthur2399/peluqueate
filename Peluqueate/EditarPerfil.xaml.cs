using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPerfil : ContentPage
    {
        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Ciudades> _provincias;
        private ObservableCollection<Peluqueate.Models.Ciudades> _ciudades;
        private ObservableCollection<Peluqueate.Models.Usuarios> _Usuario;
        private ObservableCollection<Peluqueate.Models.Empleados> _Empleados;
        public EditarPerfil(int pk,string tipo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            provincias();
            llenarDatos(pk,tipo);

        }

        private async void llenarDatos(int pk, string tipo)
        {
            if (tipo.Equals("usr"))
            {
                var content = await client.GetStringAsync(url + "usuarios/" + pk);
                List<Peluqueate.Models.Usuarios> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
                _Usuario = new ObservableCollection<Peluqueate.Models.Usuarios>(posts);
                string nombre = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_nombre;
                string apellido = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_apellido;
                int provincia = 1 - ((Peluqueate.Models.Usuarios)_Usuario[0]).ciu_codtab;
                string ciudad = ((Peluqueate.Models.Usuarios)_Usuario[0]).ciu_detalle;
                int ciudCodigo = 1 - ((Peluqueate.Models.Usuarios)_Usuario[0]).ciud_codigo ;
                string email = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_email;
                string foto = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_foto;
                PkProvincias.SelectedIndex = provincia;
                txt_nombre.Text = nombre;
                txt_apellido.Text = apellido;
                imagenPerfil.Source = url + "image/" + foto;
                PkrCiudades.SelectedIndex= ciudCodigo;
            }
            else if (tipo.Equals("emp"))
            {
                var content = await client.GetStringAsync(url + "empleados/" + pk);
                List<Peluqueate.Models.Empleados> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Empleados>>(content);
                _Empleados = new ObservableCollection<Peluqueate.Models.Empleados>(posts);
                string nombre = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_nombre;
                string apellido = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_apellido;
                string foto = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_foto;
                txt_nombre.Text = nombre;
                txt_apellido.Text = apellido;
                PkProvincias.IsVisible = false;
                PkrCiudades.IsVisible = false;
                Provincia.IsVisible = false;
                Ciudad.IsVisible = false;
                imagenPerfil.Source = url + "image/" + foto;
            }
        }

        private async void provincias()
        {
            var content = await client.GetStringAsync(url + "ciudades/provincias");
            List<Peluqueate.Models.Ciudades> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Ciudades>>(content);
            _provincias = new ObservableCollection<Peluqueate.Models.Ciudades>(posts);
            PkProvincias.ItemsSource = _provincias;
        }
        private async void ciudades(int codtab)
        {
            var content = await client.GetStringAsync(url + "ciudades/ciud/" + codtab);
            List<Peluqueate.Models.Ciudades> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Ciudades>>(content);
            _ciudades = new ObservableCollection<Peluqueate.Models.Ciudades>(posts);
            PkrCiudades.ItemsSource = _ciudades;
            PkrCiudades.IsEnabled = true;
        }

        private async void btn_tomarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "file",
            });

            if (file == null)
            {
                return;
            }

            //imagenPerfil.Source = file.Result.Path;

        }

        private async void btn_subirFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
            });

            if (file == null)
            {
                return;
            }

            imagenPerfil.Source = file.Path;
            Console.WriteLine(file.Path);
        }

        private void PkProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var code = PkProvincias.SelectedItem as Peluqueate.Models.Ciudades;
            int cod = code.ciu_codtab;
            ciudades(cod);
        }
    }
}