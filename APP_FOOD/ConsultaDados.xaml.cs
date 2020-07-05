using APP_FOOD.Banco;
using APP_FOOD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace APP_FOOD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaDados : ContentPage
    {
        Usuario usuario = null;
        public ConsultaDados(Usuario u)
        {
            InitializeComponent();
            usuario = u;
            Database database = new Database();
            ListaDados.ItemsSource = database.SelecionarDados();            
        }

        public void PaginaCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroDados(usuario));
        }

        public void VerMaisAction(object sender, EventArgs args)
        {
            //O OBJETO QUE INVOCA MEU EVENTO, É MINHA UMA LABEL, LOGO É POSSÍVEL FAZER UM CAST
            Label lblDetalhe = (Label)sender;
            //A LABEL POSSUI UMA LISTA DE GESTURERECOGNIZER, UM DELES CONTÉM O PARAMETRO DINAMICO DO BINDING
            Dados vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Dados;
            Navigation.PushAsync(new DetalheDados(vaga, usuario));
        }

        public void MostrarGrafico(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Graficos(usuario));
        }
    }
}