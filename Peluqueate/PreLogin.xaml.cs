using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreLogin : ContentPage
    {
        public PreLogin()
        {
            InitializeComponent();
        }

        private async void btn_empleados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginEmpleados());
        }

        private async void btn_clientes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUsuarios());
        }
    }
}