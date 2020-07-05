using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using APP_FOOD.Modelos;
using Xamarin.Forms;
using SQLiteNetExtensions.Extensions;

namespace APP_FOOD.Banco
{
    public class Database
    {
        private SQLiteConnection conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();

            string caminho = dep.ObterCaminho("database.sqlite");
                                
            conexao = new SQLiteConnection(caminho);
            
            conexao.CreateTable<Dados>();
            conexao.CreateTable<Usuario>();
            conexao.CreateTable<Restaurante>();
            conexao.CreateTable<Endereco>();
        }

        public void Cadastro<T>(T dados)
        {
            conexao.InsertWithChildren(dados, recursive: true);
        }
        public List<Dados> SelecionarDados()
        {
            return conexao.Table<Dados>().ToList();
        }
        public Usuario SelecionarUsuario(string nome, string senha)
        {
            return conexao.Table<Usuario>().Where(u => u.Login == nome && u.Senha == senha).FirstOrDefault();
        }

        public Usuario SelecionarUltimoUsuario()
        {
            return conexao.Table<Usuario>().Where(u => u.Ultimo_Login == true).FirstOrDefault();
        }

        public void Alterar<T>(T dados)
        {
            conexao.Update(dados);
        }
    }
}
