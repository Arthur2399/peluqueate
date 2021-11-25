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
    public partial class PreguntasRespuestas : ContentPage
    {

        private const string url = "http://192.168.194.128:82/api/";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Peluqueate.Models.Pregunta> _preguntas;
        private ObservableCollection<Peluqueate.Models.Usuarios> _pkUsuario;
        private int pk1;

        public PreguntasRespuestas()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            cb_preguntas.IsEnabled = false;
            txtRespuesta.IsEnabled = false;
            bt_siguiente.IsEnabled = false;
        }

        private async void bt_siguiente_Clicked(object sender, EventArgs e)
        {
            try {
            WebClient web = new WebClient();
            var Preguntas = cb_preguntas.SelectedItem as Peluqueate.Models.Pregunta;
            int pkPregunta = Preguntas.id_preguntas;
            var request = new System.Collections.Specialized.NameValueCollection();
            request.Add("id_usuarios", pk1.ToString());
            request.Add("id_preguntas", pkPregunta.ToString());
            request.Add("res_respuesta", txtRespuesta.Text);
            web.UploadValues(url + "respuestasusuarios/responder", "POST", request);
            await Navigation.PushAsync(new CambiarContrasena(pk1));
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pk1 = 0;  
                cb_preguntas.IsEnabled = false;
                txtRespuesta.IsEnabled = false;
                bt_siguiente.IsEnabled = false;
                var content = await client.GetStringAsync(url + "usuarios/login/" + txtEmail.Text);
                List<Peluqueate.Models.Usuarios> post = JsonConvert.DeserializeObject<List<Peluqueate.Models.Usuarios>>(content);
                _pkUsuario = new ObservableCollection<Peluqueate.Models.Usuarios>(post);
                var pk = ((Peluqueate.Models.Usuarios)_pkUsuario[0]).id_usuarios;
                pk1 = pk;
                if (pk1 > 0)
                {
                    var content2 = await client.GetStringAsync(url + "respuestasusuarios/" + pk);
                    List<Peluqueate.Models.Pregunta> posts2 = JsonConvert.DeserializeObject<List<Peluqueate.Models.Pregunta>>(content2);
                    _preguntas = new ObservableCollection<Peluqueate.Models.Pregunta>(posts2);
                    cb_preguntas.ItemsSource = _preguntas;
                    cb_preguntas.IsEnabled = true;
                    txtRespuesta.IsEnabled = true;
                    bt_siguiente.IsEnabled = true;

                }
                else
                {
                    cb_preguntas.IsEnabled = false;
                    txtRespuesta.IsEnabled = false;
                    bt_siguiente.IsEnabled = false;
                }
            }
            catch
            {

            }

        }
    }
}