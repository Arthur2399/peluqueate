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
            lbLoginEmpleadosFucn();
            lbLoginUsuariosFucn();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void lbLoginEmpleadosFucn()
        {
            lb_empleados.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new LoginEmpleados());
                   ;
                }
                )
            });

        }

        void lbLoginUsuariosFucn()
        {
            lb_clientes.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new LoginUsuarios());
                   
                }
                )
            });
        }
    }
}