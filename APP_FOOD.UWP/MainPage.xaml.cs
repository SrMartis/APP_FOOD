using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace APP_FOOD.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            //TOKEN É GERADO PELO SITE DO BING PARA USO DE MAPAS
            //DEPOIS QUE OS MAPAS FORAM INCIALIZADO EM CADA UM DOS PROJETOS, A API PODE SER MANIPULADA NO PROJETO COMPARTILHADO.
            Xamarin.FormsMaps.Init("0V8SMIbeC1N6BX1VXKvY~6cJcf9TYHyOfXmomxjg-Lw~AmshPyFNzBhwuBvlaW1W6SY_uBv25H-QcyLWrM3ot8XkYIzwozuOL1mCFSiWBdhj");
            Windows.Services.Maps.MapService.ServiceToken = "0V8SMIbeC1N6BX1VXKvY~6cJcf9TYHyOfXmomxjg-Lw~AmshPyFNzBhwuBvlaW1W6SY_uBv25H-QcyLWrM3ot8XkYIzwozuOL1mCFSiWBdhj";
            LoadApplication(new APP_FOOD.App());
        }
    }
}
