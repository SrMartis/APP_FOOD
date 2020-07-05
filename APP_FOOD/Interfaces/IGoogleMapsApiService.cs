using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static APP_FOOD.Modelos.Google;

namespace APP_FOOD.Interfaces
{
    public interface IGoogleMapsApiService
    {
        Task<GooglePlaceAutoCompleteResult> SelecionarLugar(string text);
        Task<GooglePlace> DetalhesLugar(string id);
    }
}
