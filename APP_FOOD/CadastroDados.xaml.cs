using APP_FOOD.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APP_FOOD.Banco;
using Newtonsoft.Json;

namespace APP_FOOD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroDados : ContentPage
	{
        Usuario usuario = null;
        
		public CadastroDados(Usuario u)
		{
            //Database.InitDB();
            //CultureInfo BR = new CultureInfo("pt-BR");
            //CultureInfo.DefaultThreadCurrentCulture = BR;
            InitializeComponent ();            
            campo_data.Date = DateTime.Now;
            usuario = u;
		}

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                Dados dados = new Dados
                {
                    Data = campo_data.Date,
                    Total_Produzido = int.Parse(campo_total_produzido.Text),
                    Refeicoes_Estimadas = int.Parse(campo_refeicoes_estimadas.Text),
                    Refeicoes_Servidas = int.Parse(campo_refeicoes_servidas.Text),
                    Total_Desperdicado = int.Parse(campo_total_desperdicado.Text),
                    Id_Restaurante = usuario.Id_Restaurante
                };

                try
                {
                    Database database = new Database();
                    database.Cadastro(dados);

                    DisplayAlert("SUCESSO", "DADOS CADASTRADOS", "OK");

                }
                catch (Exception ex)
                {

                }

                Navigation.PopAsync();
            }
        }

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private bool ValidaCampos()
        {
            bool valido = true;

            try
            {
                int.Parse(campo_total_produzido.Text);
                int.Parse(campo_refeicoes_estimadas.Text);
                int.Parse(campo_refeicoes_servidas.Text);
                int.Parse(campo_total_desperdicado.Text);
            }
            catch
            {
                DisplayAlert("AVISO", "PRENCHER OS CAMPOS COM NUMEROS", "OK");
                valido = false;
            }

            return valido;
        }
    }
}