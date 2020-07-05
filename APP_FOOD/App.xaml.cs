using APP_FOOD.Banco;
using APP_FOOD.Modelos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FOOD
{
    public partial class App : Application
    {
        public App()
        {            
            InitializeComponent();

            Database database = new Database();

            Usuario UltimoUsuario = database.SelecionarUltimoUsuario();

            if (UltimoUsuario != null)
            {
                App.Current.MainPage = new NavigationPage(new MainPage(UltimoUsuario));
            }
            else
            {
                MainPage = new Intro();
            }
                       
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
