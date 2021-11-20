﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peluqueate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUsuarios : ContentPage
    {
        public LoginUsuarios()
        {
            InitializeComponent();
            lbRegistrarFucn();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        void  lbRegistrarFucn()
        {
            lb_registrar.GestureRecognizers.Add( new TapGestureRecognizer()
            { 
                Command = new Command(() =>
                {
                     Navigation.PushAsync(new Registro());
                    
                }
                )
            });

        }

        private async void btn_IniciarSesion_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new MainPage());
        }
    }
}