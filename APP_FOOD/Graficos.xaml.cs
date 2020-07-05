using APP_FOOD.Banco;
using APP_FOOD.Modelos;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using Microcharts.Forms;
using Entry = Microcharts.Entry;
using System.Linq;

namespace APP_FOOD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graficos : ContentPage
    {
        List<Entry> EntradasProducao = new List<Entry>();
        List<Entry> EntradasDesperdicio = new List<Entry>();
        List<Entry> PorcentagemDesperdicio = new List<Entry>();
        public Graficos(Usuario u)
        {
            Database database = new Database();

            List<Dados> Dados = database.SelecionarDados()
                .Where(d => d.Restaurante.Id_Restaurante == u.Id_Restaurante)
                .OrderBy(d => d.Data).ToList();

            if (Dados.Count == 0)
            {
                DisplayAlert("AVISO", "NÃO HÁ REGISTROS A SEREM EXIBIDOS", "OK");
                Navigation.PopAsync();
            }
            
            foreach(Dados d in Dados)
            {
                EntradasProducao.Add(new Entry(float.Parse(d.Total_Produzido.ToString()))
                {
                    Label = d.Data.ToString("dd/MM/yyyy"),
                    Color = SKColor.Parse("#00FF00"),
                    ValueLabel = d.Total_Produzido.ToString()
                });

                EntradasDesperdicio.Add(new Entry(float.Parse(d.Total_Desperdicado.ToString()))
                {
                    Label = d.Data.ToString("dd/MM/yyyy"),
                    Color = SKColor.Parse("#FF0000"),
                    ValueLabel = d.Total_Desperdicado.ToString()
                });

                PorcentagemDesperdicio.Add(new Entry(float.Parse(d.Porcentagem_Desperdicio.ToString()))
                {
                    Label = d.Data.ToString("dd/MM/yyyy"),
                    Color = SKColor.Parse("#FA0000"),
                    ValueLabel = d.Porcentagem_Desperdicio.ToString()
                });
            }

            InitializeComponent();
            Grafico1.Chart = new LineChart() { 
                Entries = EntradasProducao,
                LineMode = LineMode.Straight,                              
            };

            Grafico2.Chart = new LineChart()
            {
                Entries = EntradasDesperdicio,
                LineMode = LineMode.Straight
            };

            Grafico3.Chart = new LineChart()
            {
                Entries = PorcentagemDesperdicio,
                LineMode = LineMode.Straight
            };
        }
    }
}