using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiPerfil : ContentPage
    {
        int _pk;
        string _tipo;
        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Usuarios> _Usuario;
        private ObservableCollection<Peluqueate.Models.Empleados> _Empleados;

        public MiPerfil(int pk, string tipo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _pk = pk;
            _tipo = tipo;
            llenarDatos(pk, tipo);
        }

        public async void llenarDatos(int pk,string tipo)
        {
            if(tipo.Equals("usr")) { 
            var content = await client.GetStringAsync(url+ "usuarios/"+pk);
            List<Peluqueate.Models.Usuarios> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
            _Usuario= new ObservableCollection<Peluqueate.Models.Usuarios>(posts);
            string nombre = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_nombre;
            string apellido = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_apellido;
            string ciudad = ((Peluqueate.Models.Usuarios)_Usuario[0]).ciu_detalle;
            string fechaNac = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_fechnacimiento;
            string email= ((Peluqueate.Models.Usuarios)_Usuario[0]).user_email;
                string foto = ((Peluqueate.Models.Usuarios)_Usuario[0]).user_foto;
                labelCiudad.Text = "Ciudad";
                txt_nombre.Text = nombre;
                txt_apellido.Text = apellido;
                txtCiudad.Text = ciudad;
                txtFecha.Text = fechaNac;
                txtEmail.Text = email;
                imagenPerfil.Source = url + "image/" + foto;
            }else if(tipo.Equals("emp")){
                var content = await client.GetStringAsync(url + "empleados/" + pk);
                List<Peluqueate.Models.Empleados> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Empleados>>(content);
                _Empleados= new ObservableCollection<Peluqueate.Models.Empleados>(posts);
                string nombre = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_nombre;
                string apellido = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_apellido;
                string ciudad = ((Peluqueate.Models.Empleados)_Empleados[0]).loc_nombre;
                string fechaNac = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_fechnacimiento;
                string email = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_email;
                string foto = ((Peluqueate.Models.Empleados)_Empleados[0]).empe_foto;
                labelCiudad.Text = "Local";
                txt_nombre.Text = nombre;
                txt_apellido.Text = apellido;
                txtCiudad.Text = ciudad;
                txtFecha.Text = fechaNac;
                txtEmail.Text = email;
                imagenPerfil.Source = url + "image/" + foto;
            }
        }

        private void btn_home_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_atras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_pk,_tipo));
        }

        private async void btn_editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarPerfil(_pk,_tipo));
        }
    }

  
}