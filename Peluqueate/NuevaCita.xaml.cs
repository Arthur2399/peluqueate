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
    public partial class NuevaCita : ContentPage
    {
        private int _pk;
        private string _tipo; 
        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.ServiciosEmpleados> _servicio;
        private ObservableCollection<Peluqueate.Models.ServiciosEmpleados> _Encargado;
        private ObservableCollection<Peluqueate.Models.DetalleCita> _DetalleCita;
        private int _pkCabecera;
        private int _pkDetalle;

        public NuevaCita(int pkCabecera, int id_Local)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            PkrPersonal.IsEnabled = false;
            Eliminar.IsEnabled = false;
            _pkCabecera = pkCabecera;
            llenarServicio(id_Local);
        }

        private async void llenarServicio(int id_local)
        {
            try
            {
                var content = await client.GetStringAsync(url + "serviciosempleados/local/" + id_local);
                List<Peluqueate.Models.ServiciosEmpleados> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.ServiciosEmpleados>>(content);
                _servicio= new ObservableCollection<Peluqueate.Models.ServiciosEmpleados>(posts);
                PkrServicio.ItemsSource = _servicio;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Sin Conexion", "Ok");
            }
        }

        private async void llenarResponsable(int id_local,int id_servicio)
        {
            try
            {
                var content = await client.GetStringAsync(url + "serviciosempleados/servicio/"+id_servicio+"/"+ id_local);
                List<Peluqueate.Models.ServiciosEmpleados> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.ServiciosEmpleados>>(content);
                _Encargado = new ObservableCollection<Peluqueate.Models.ServiciosEmpleados>(posts);
                PkrPersonal.ItemsSource = _Encargado;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Sin Conexion", "Ok");
            }
        }

        private async void llenarTabla(int id_cabecera)
        {
            try
            {
                var content = await client.GetStringAsync(url + "detallecita/" + id_cabecera);
                List<Peluqueate.Models.DetalleCita> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.DetalleCita>>(content);
                _DetalleCita = new ObservableCollection<Peluqueate.Models.DetalleCita>(posts);
                RegistroServicio.ItemsSource = _DetalleCita;
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void PkrServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            var code = PkrServicio.SelectedItem as Peluqueate.Models.ServiciosEmpleados;
            int id_servicio = code.id_servicio;
            int id_local= code.id_local;
            PkrPersonal.IsEnabled = true;
            llenarResponsable(id_local, id_servicio);
            }
            catch
            {
                DisplayAlert("Error", "Sin conexion al servidor", "Ok");   
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var servicio = PkrPersonal.SelectedItem as Peluqueate.Models.ServiciosEmpleados;
                int pkServicio = servicio.id_ser_emp;
                var request = new System.Collections.Specialized.NameValueCollection();
                request.Add("id_serviciocabecera", _pkCabecera.ToString());
                request.Add("id_ser_emp", pkServicio.ToString());
                cliente.UploadValues(url+ "detallecita", "POST", request);
                llenarTabla(_pkCabecera);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }


        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var answer = await DisplayAlert("Eliminar", "Seguro que quiere eliminar el servicio?", "Si", "No");
                if (answer)
                {
                    if (_pkDetalle == 0)
                    {
                        await DisplayAlert("Error", "Seleccione un servicio", "Ok");
                    }
                    else
                    {
                        await client.DeleteAsync(url+ "detallecita/" + _pkDetalle);
                        await DisplayAlert("Eliminado", "Se elimino Correctamente", "Ok");
                        llenarTabla(_pkCabecera);
                    }
                }
            }
            catch
            {

            }
        
        }


        private void RegistroServicio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var sel = ((ListView)sender).SelectedItem as Peluqueate.Models.DetalleCita;
            if (sel == null)
            {
                Eliminar.IsEnabled = false;
                return;
            }
            else
            {
            _pkDetalle = sel.id_serviciodetalle;
                Eliminar.IsEnabled = true;
            }


        }

        private void bt_Terminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}