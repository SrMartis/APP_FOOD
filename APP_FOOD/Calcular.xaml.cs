﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FOOD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calcular : ContentPage
    {        
        public Calcular()
        {            
           InitializeComponent();            
        }

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}