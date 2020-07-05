using APP_FOOD.Banco;
using APP_FOOD.Modelos;
using APP_FOOD.Serviços;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FOOD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroUsuario : ContentPage, INotifyPropertyChanged
    {
        private Restaurante restaurante;
        public CadastroUsuario()
        {
            InitializeComponent();
            restaurante = new Restaurante();            
        }
        private void Cep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (campo_restaurante_cep.Text.Length == 8)
            {
                string CEP = campo_restaurante_cep.Text;

                //MostrarProgresso(true);

                Endereco endereco = ViaCepServico.BuscarEnderecoViaCEP(CEP);
                campo_restaurante_logradouro.Text = endereco.Logradouro;
                campo_restaurante_bairro.Text = endereco.Bairro;
                campo_restaurante_cidade.Text = endereco.Cidade;
                campo_restaurante_estado.Text = endereco.Estado;

                // MostrarProgresso(false);
            }
        }
        private void Salvar_Clicked(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Restaurante restaurante = new Restaurante();
            Endereco endereco = new Endereco();

            try
            {
                Database database = new Database();

                if (CadastroValido())
                {
                    usuario.Login = campo_usuario_nome.Text;
                    usuario.Senha = campo_usuario_senha.Text;
                    usuario.Email = campo_usuario_email.Text;
                    usuario.Ultimo_Login = true;
                    
                    usuario.Restaurante = new Restaurante()
                    {
                        Nome = campo_restaurante_nome.Text,
                        Endereco = new Endereco
                        {
                            Logradouro = campo_restaurante_logradouro.Text,
                            Cidade = campo_restaurante_cidade.Text,
                            Cep = campo_restaurante_cep.Text,
                            Estado = campo_restaurante_estado.Text,
                            Bairro = campo_restaurante_bairro.Text,                          
                        },
                    };                    

                    database.Cadastro(usuario);

                    DisplayAlert("", "USUARIO CADASTRADO COM SUCESSO!", "OK");

                    Navigation.PopAsync();
                    Navigation.PushAsync(new MainPage(usuario));
                } else
                {
                    DisplayAlert("ERRO", "PREENCHA OS CAMPOS EM VERMELHO", "OK");
                }                
            }
            catch (Exception ex)
            {
                DisplayAlert("ERRO", ex.Message, "OK");
            }

        }

        #region VALIDAÇÕES
        private bool CadastroValido()
        {
            bool valido = true;

            #region VALIDA NOME DO USUÁRIO

            string nome = campo_usuario_nome.Text;

            if (String.IsNullOrEmpty(nome))
            {
                campo_usuario_nome.BackgroundColor = Color.IndianRed;
                valido = false;
                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_usuario_nome.BackgroundColor = Color.Default;
            }
            #endregion

            #region VALIDA EMAIL DO USUÁRIO

            string email = campo_usuario_email.Text;

            if (string.IsNullOrEmpty(email))
            {
                campo_usuario_email.BackgroundColor = Color.IndianRed;
                valido = false;
                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_usuario_email.BackgroundColor = Color.Default;
            }

            #endregion

            #region VALIDA SENHA DO USUÁRIO

            string senha = campo_usuario_senha.Text;

            if (string.IsNullOrEmpty(senha))
            {
                campo_usuario_senha.BackgroundColor = Color.IndianRed;
                valido = false;
                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_usuario_senha.BackgroundColor = Color.Default;
            }

            #endregion

            #region VALIDA NOME DO RESTAURANTE

            string nome_restaurante = campo_restaurante_nome.Text;

            if (string.IsNullOrEmpty(nome_restaurante))
            {
                campo_restaurante_nome.BackgroundColor = Color.IndianRed;
                valido = false;
                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_restaurante_nome.BackgroundColor = Color.Default;
            }
            #endregion

            #region VALIDA CEP DO RESTAURANTE

            string cep_restaurante = campo_restaurante_cep.Text;

            if (string.IsNullOrEmpty(nome_restaurante) || cep_restaurante.Trim().Length != 8)
            {
                campo_restaurante_cep.BackgroundColor = Color.IndianRed;
                valido = false;
                //INVOCAR MODAL PADRÃO DE MENSAGENS
            }
            else
            {
                campo_restaurante_cep.BackgroundColor = Color.Default;
            }
            #endregion

            return valido;
        }
        #endregion

        //public static readonly BindableProperty FocusOriginCommandProperty =
        // BindableProperty.Create(nameof(FocusOriginCommand), typeof(ICommand), typeof(MainPage), null, BindingMode.TwoWay);

        //public ICommand FocusOriginCommand
        //{
        //    get { return (ICommand)GetValue(FocusOriginCommandProperty); }
        //    set { SetValue(FocusOriginCommandProperty, value); }
        //}

        //void OnOriginFocus()
        //{            
        //    entrada.Focus();
        //}

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();
        //    if (BindingContext != null)
        //    {
        //        FocusOriginCommand = new Command(OnOriginFocus);
        //    }
        //}

    }
}