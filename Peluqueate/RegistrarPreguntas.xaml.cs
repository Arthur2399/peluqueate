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
    public partial class RegistrarPreguntas : ContentPage
    {
        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Pregunta> _pregunta1;
        private ObservableCollection<Peluqueate.Models.Pregunta> _pregunta2;
        private ObservableCollection<Peluqueate.Models.Pregunta> _pregunta3;
        private int _pk;
        public RegistrarPreguntas(int pk)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _pk = pk;
            txtRespuestaUno.IsEnabled = false;
            txtRespuestaDos.IsEnabled = false;
            txtRespuestaTres.IsEnabled = false;
            cb_preguntasDos.IsEnabled = false;
            cb_preguntasDos.IsEnabled = false;
            cb_preguntasTre.IsEnabled = false;
            bt_registrarme.IsEnabled = false;
            llenarPreguntas1();
        }

        private async void llenarPreguntas1()
        {
            try { 
            var content = await client.GetStringAsync(url + "preguntas");
            List<Peluqueate.Models.Pregunta> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Pregunta>>(content);
            _pregunta1 = new ObservableCollection<Peluqueate.Models.Pregunta>(posts);
            cb_preguntasUno.ItemsSource = _pregunta1;
            }
            catch
            {

            }
        }
        private async void llenarPreguntas2(int pkAnt)
        {
            try { 
            var content = await client.GetStringAsync(url + "preguntas3/0/"+pkAnt);
            List<Peluqueate.Models.Pregunta> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Pregunta>>(content);
            _pregunta2 = new ObservableCollection<Peluqueate.Models.Pregunta>(posts);
            cb_preguntasDos.ItemsSource = _pregunta2;
            }
            catch
            {

            }
        }
        private async void llenarPreguntas3(int pkAnt,int pkAnt2)
        {
            try { 
            var content = await client.GetStringAsync(url + "preguntas3/" + pkAnt+"/"+pkAnt2);
            List<Peluqueate.Models.Pregunta> posts = JsonConvert.DeserializeObject<List<Peluqueate.Models.Pregunta>>(content);
            _pregunta3 = new ObservableCollection<Peluqueate.Models.Pregunta>(posts);
            cb_preguntasTre.ItemsSource = _pregunta3;
            }
            catch
            {

            }
        }

        private async void bt_registrarme_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient web = new WebClient();
                var Preguntas1 = cb_preguntasUno.SelectedItem as Peluqueate.Models.Pregunta;
                var Preguntas2 = cb_preguntasDos.SelectedItem as Peluqueate.Models.Pregunta;
                var Preguntas3 = cb_preguntasTre.SelectedItem as Peluqueate.Models.Pregunta;
                var request1 = new System.Collections.Specialized.NameValueCollection();
                var request2 = new System.Collections.Specialized.NameValueCollection();
                var request3 = new System.Collections.Specialized.NameValueCollection();
                request1.Add("id_usuarios", _pk.ToString());
                request1.Add("id_preguntas", Preguntas1.id_preguntas.ToString());
                request1.Add("res_respuesta", txtRespuestaUno.Text);
                web.UploadValues(url + "respuestasusuarios", "POST", request1);
                request2.Add("id_usuarios", _pk.ToString());
                request2.Add("id_preguntas", Preguntas2.id_preguntas.ToString());
                request2.Add("res_respuesta", txtRespuestaUno.Text);
                web.UploadValues(url + "respuestasusuarios", "POST", request2);
                request3.Add("id_usuarios", _pk.ToString());
                request3.Add("id_preguntas", Preguntas3.id_preguntas.ToString());
                request3.Add("res_respuesta", txtRespuestaUno.Text);
                web.UploadValues(url + "respuestasusuarios", "POST", request3);
                await DisplayAlert("Guardado", "Guardado Correctamente", "Ok");
                await Navigation.PushAsync(new LoginUsuarios());
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void txtRespuestaTres_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            
            if (txtRespuestaTres.Text.Length > 0)
            {
                bt_registrarme.IsEnabled = true;
            }
            }
            catch
            {

            }
        }

        private void cb_preguntasTre_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRespuestaTres.Text = "";
            txtRespuestaTres.IsEnabled = true;
        }

        private void cb_preguntasUno_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRespuestaUno.Text = "";
            txtRespuestaUno.IsEnabled = true;
        }

        private void txtRespuestaUno_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { 
            cb_preguntasDos.IsEnabled = false;
            if (txtRespuestaUno.Text.Length > 0)
            {
                cb_preguntasDos.IsEnabled = true;
                var Preguntas = cb_preguntasUno.SelectedItem as Peluqueate.Models.Pregunta;
                    int pkp1 = Preguntas.id_preguntas;
                llenarPreguntas2(pkp1);
            }
            }
            catch
            {

            }
        }

        private void cb_preguntasDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRespuestaDos.Text = "";
            txtRespuestaDos.IsEnabled = true;
        }

        private void txtRespuestaDos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try {
            cb_preguntasTre.IsEnabled = false;
            if (txtRespuestaUno.Text.Length > 0)
            {
                cb_preguntasTre.IsEnabled = true;
                var Preguntas1 = cb_preguntasUno.SelectedItem as Peluqueate.Models.Pregunta;
                var Preguntas2 = cb_preguntasDos.SelectedItem as Peluqueate.Models.Pregunta;
                    int pkp1 = Preguntas1.id_preguntas;
                    int pkp2 = Preguntas2.id_preguntas;
                llenarPreguntas3(pkp1,pkp2);
            }
            }
            catch
            {

            }
        }
    }
}