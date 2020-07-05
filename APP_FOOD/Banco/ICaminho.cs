using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace APP_FOOD.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string nome_arquivo_banco_dados);
    }
}
