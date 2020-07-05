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
    public partial class Inserir_Tutorial : CarouselPage
    {
        public Inserir_Tutorial()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {            
            //QUANDO O USUÁRIO FINALIZA O TUTORIAL UMA MENSAGEM É ENVIADA AO MAIN.
            MessagingCenter.Send(this, "Usuário fez o tutorial");            
        }
    }
}