using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace APP_FOOD
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Sobre_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Sobre();
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {        
                App.Current.MainPage = new Calcular();                                       
        }

        private async void Localizar_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;

            var location = await locator.GetPositionAsync(TimeSpan.FromSeconds(100));

            Position position = new Position(location.Latitude, location.Longitude);         
            MapSpan span = new MapSpan(position, 0.01, 0.01);
            Local_Restaurante.MoveToRegion(span);
            Local_Restaurante.HasScrollEnabled = false;
        }
    }
}
