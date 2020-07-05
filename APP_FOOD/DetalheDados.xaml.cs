using APP_FOOD.Banco;
using APP_FOOD.Modelos;
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
    public partial class DetalheDados : ContentPage
    {
        Usuario usuario;
        Dados dados;
        public DetalheDados(Dados d, Usuario u)
        {
            InitializeComponent();
            BindingContext = d;
            dados = d;
            usuario = u;
            campo_data.Date = Convert.ToDateTime(dados.Data);
        }

        private void Voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void HabilitarCampos(object sender, EventArgs e)
        {
            campo_data.IsEnabled = true;
            campo_refeicoes_estimadas.IsEnabled = true;
            campo_refeicoes_servidas.IsEnabled = true;
            campo_total_desperdicado.IsEnabled = true;
            campo_total_produzido.IsEnabled = true;
            botao_voltar.IsVisible = false;
            botao_editar.IsVisible = false;
            botao_cancelar.IsVisible = true;
            botao_salvar.IsVisible = true;
        }

        private void Cancelar(object sender, EventArgs args)
        {
            campo_data.IsEnabled = false;
            campo_refeicoes_estimadas.IsEnabled = false;
            campo_refeicoes_servidas.IsEnabled = false;
            campo_total_desperdicado.IsEnabled = false;
            campo_total_produzido.IsEnabled = false;
            botao_voltar.IsVisible = true;
            botao_editar.IsVisible = true;
            botao_cancelar.IsVisible = false;
            botao_salvar.IsVisible = false;
        }
        private void Salvar(object sender, EventArgs args)
        {
            if (ValidaCampos())
            {
                dados.Data = campo_data.Date;
                dados.Total_Produzido = int.Parse(campo_total_produzido.Text);
                dados.Refeicoes_Estimadas = int.Parse(campo_refeicoes_estimadas.Text);
                dados.Refeicoes_Servidas = int.Parse(campo_refeicoes_servidas.Text);
                dados.Total_Desperdicado = int.Parse(campo_total_desperdicado.Text);

                try
                {
                    Database database = new Database();
                    database.Alterar(dados);

                    DisplayAlert("SUCESSO", "DADOS ALTERADOS COM SUCESSO", "OK");

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO", "FALHA AO ALTERAR", "OK");
                }
                Navigation.PopAsync();
            }
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