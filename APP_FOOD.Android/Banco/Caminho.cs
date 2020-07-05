using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using APP_FOOD.Modelos;
using APP_FOOD.Banco;
using Android.Graphics;
using System.IO;
using APP_FOOD.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace APP_FOOD.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nome_arquivo_banco_dados)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBanco = System.IO.Path.Combine(caminhoDaPasta, nome_arquivo_banco_dados);
            return caminhoBanco;
        }
    }
}