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
    public partial class LoginEmpleados : ContentPage
    {
        public LoginEmpleados()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
       
    }
}