using APP_FOOD.Interfaces;
using APP_FOOD.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static APP_FOOD.Modelos.Google;

namespace APP_FOOD.Serviços
{
    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        static string _googleMapsKey;

        private const string ApiBaseAdress = "https://map.googlepais.com/maps/";

        private HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAdress)
            };


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static void Initialize(string googleMapsKey)
        {
            _googleMapsKey = googleMapsKey;
        }

        public async Task<Google.GooglePlaceAutoCompleteResult> SelecionarLugar(string text)
        {
            GooglePlaceAutoCompleteResult results = null;

            using (var client = CreateClient())
            {
                var response = await client.GetAsync($"api/place/autocomplete/json?input={Uri.EscapeUriString(text)}&key={_googleMapsKey}").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        results = await Task.Run(() =>
                        JsonConvert.DeserializeObject<GooglePlaceAutoCompleteResult>(json))
                            .ConfigureAwait(false);
                    }
                }
            }

            return results;
        }
        public async Task<Google.GooglePlace> DetalhesLugar(string id)
        {
            GooglePlace result = null;

            using (var client = CreateClient())
            {
                var response = await client.GetAsync($"api~/place/details/json?placeid={Uri.EscapeDataString(id)}&key={_googleMapsKey}")
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        result = new GooglePlace(JObject.Parse(json));
                    }
                }

            }
            return result;

        }

        bool _isPickupFocused = true;

        string _pickupText;
        public string PickupText
        {
            get
            {
                return _pickupText;
            }
            set
            {
                _pickupText = value;
                if (!string.IsNullOrEmpty(_pickupText))
                {
                    _isPickupFocused = true;
                    GetPlacesCommand.Execute(_pickupText);
                }
            }
        }

        GooglePlaceAutoCompletePrediction _placeSelected;
        public ICommand GetPlacesCommand { get; set; }
        public GooglePlaceAutoCompletePrediction PlaceSelected
        {
            get
            {
                return _placeSelected;
            }
            set
            {
                _placeSelected = value;
            }
        }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

        public bool ShowRecentPlaces { get; set; }
        public async Task GetPlacesByName(string text)
        {
            var places = await SelecionarLugar(text);
            var placeResult = places.AutoCompletePlaces;

            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction> (placeResult);
            }

            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);           
        }
    }

}
