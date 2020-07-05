using APP_FOOD.Banco;
using Xamarin.Forms;
using System.IO;
using APP_FOOD.UWP.Banco;
using Windows.Storage;

[assembly: Dependency(typeof(Caminho))]
namespace APP_FOOD.UWP.Banco
{   
    public class Caminho: ICaminho
    {
        public string ObterCaminho(string nome_arquivo_banco_dados)
        {
                string caminhoDaPasta = ApplicationData.Current.LocalFolder.Path;
                string caminhoBanco = Path.Combine(caminhoDaPasta, nome_arquivo_banco_dados);
                return caminhoBanco;
           
        }
    }
}
