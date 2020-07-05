using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using APP_FOOD.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APP_FOOD.Serviços
{
    public class ViaCepServico
    {
        private static string base_URL = "http://viacep.com.br/ws/{0}/json/";

        #region ENDERECO VIA CEP
        private class ViaCepEndereco
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string unidade { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
        }

        #endregion
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string enderecoURL = string.Format(base_URL, cep);
            WebClient wc = new WebClient();

            try
            {
                string retorno = wc.DownloadString(enderecoURL);
                ViaCepEndereco e = JsonConvert.DeserializeObject<ViaCepEndereco>(retorno);

                Endereco endereco = new Endereco
                {
                    Cep = e.cep,
                    Logradouro = e.logradouro,
                    Bairro = e.bairro,
                    Cidade = e.localidade,
                    Estado = e.uf
                };

                return endereco;
            }
            catch (Exception e)
            {
                throw new Exception("Verifique sua conexão com internet e tente novamente mais tarde");
            }
        }
    }
}
