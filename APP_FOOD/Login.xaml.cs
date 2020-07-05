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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();            
        }

        private void Entrar_Clicked(object sender, EventArgs e)
        {

            if (LoginValido())
            {
                string nome = campo_usuario.Text;
                string senha = campo_senha.Text;

                Database database = new Database();
                Usuario usuario = database.SelecionarUsuario(nome, senha);

                if (usuario != null)
                {
                    //TODO - VALIDAR SE O USUARIO TEM CONEXÃO COM A INTERNET.
                    //CONSUMIR BANCO DE DADOS EXTERNO
                    
                    Navigation.PushAsync(new MainPage(usuario));

                } else
                {
                    DisplayAlert("AVISO!", "USUÁRIO NÃO ENCONTRADO!","OK");
                }

                //TODO CONSUMIR BANCO REMOTO PARA ACESSAR O APLICATIVO
                //TODO DEPOIS QUE O LOGIN FOI FEITO ARMAZENAR OS DADOS LOCALMENTE                
            }
            //CONSULTA O BANCO DE DADOS LOCAL

            //VERIFICA SE O USUÁRIO TEM INTERNET

            //FAZ UMA CONSULTA PELO USUÁRIO NO BANCO DE DADOS

            //RETORNA
           
        }

        private void Cadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroUsuario());
        }

        private bool LoginValido()
        {
            string usuario = campo_usuario.Text;
            bool valido = true;

            if (String.IsNullOrEmpty(usuario))
            {
                campo_usuario.BackgroundColor = Color.IndianRed;
                valido = false;

                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_usuario.BackgroundColor = Color.Default;
            }

            string senha = campo_senha.Text;

            if (string.IsNullOrEmpty(senha))
            {
                campo_senha.BackgroundColor = Color.IndianRed;
                valido = false;

                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_senha.BackgroundColor = Color.Default;
            }

            return valido;
        }
    }
}