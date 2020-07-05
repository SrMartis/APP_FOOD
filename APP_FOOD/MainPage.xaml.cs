using APP_FOOD.Banco;
using APP_FOOD.Modelos;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        Usuario usuario = null;
        public bool Tutorial { get; set; }
        public MainPage(Usuario u)
        {
            InitializeComponent();            
            usuario = u;
        }        
        
        private void Sobre_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new Sobre());
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {        
            Navigation.PushAsync(new Calcular());                                       
        }

        private void Inserir_Clicked(object sender, EventArgs e)
        {
            //CASO O USUÁRIO TENHA VISTO O TUTORIAL
            if (usuario.Visualizou_Tutorial)
            {
                //MOSTRA A PÁGINA PARA PREENCHER OS DADOS
                Navigation.PushAsync(new CadastroDados(usuario));
            }
            else //SE NÃO
            {
                //CRIA UMA PÁGINA DE NAVEGAÇÃO E INSERE NA PILHA
                Navigation.PushAsync(new Inserir_Tutorial());

                //O MAIN ASSINA A PÁGINA DE TUTORIAL
                MessagingCenter.Subscribe<Inserir_Tutorial>(this, "Usuário fez o tutorial", (trigger) =>
                {
                    Database database = new Database();
                    //AVISA AO MAIN QUE O TUTORIAL ESTÁ FEITO
                    usuario.Visualizou_Tutorial = true;
                    database.Alterar(usuario);
                    Navigation.PopAsync();
                });                
            }
        }

        private void Consulta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaDados(usuario));
        }

        private void Sair_Clicked(object sender, EventArgs e)
        {
            Database database = new Database();                 
            usuario.Ultimo_Login = false;

            database.Alterar(usuario);
                        
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
