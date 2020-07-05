using System;
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
        bool tutorial = false;
        public Calcular()
        {            
           InitializeComponent();            
        }
    }
}