using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace APP_FOOD.Modelos
{
    [Table("Dados")]
    public class Dados
    {        
        [PrimaryKey, AutoIncrement]
        public int Id_Dados { get; set; }
        public DateTime Data { get; set; }
        public double Total_Produzido { get; set; }
        public int Refeicoes_Estimadas { get; set; }
        public int Refeicoes_Servidas { get; set; }        
        public double Total_Desperdicado { get; set; }
        
        [ForeignKey(typeof(Restaurante))]
        public int Id_Restaurante {get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Restaurante Restaurante { get; set; }

        public string Porcentagem_Desperdicio { 
            get
            {
                double porcentagem = (Total_Desperdicado/Total_Produzido) * 100;
                return porcentagem.ToString();
            }           
        }

    }
    
    [Table("Restaurante")]
    public class Restaurante
    {
        [PrimaryKey, AutoIncrement]
        public int? Id_Restaurante { get; set; }
        public string Nome { get; set; }
        
        [ForeignKey(typeof(Endereco))]
        public int Id_Endereco { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeInsert)]     
        public Endereco Endereco {get;set;}      

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Dados> Dados { get; set; }
    }

    [Table("Endereco")]
    public class Endereco {

        [PrimaryKey, AutoIncrement]
        public int Id_Endereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int? Id_Usuario { get; set; }
        public string Login { get; set; }
        public string Email {get; set;}        
        public string Senha { get; set; }            
        public bool Ultimo_Login { get; set; }
        
        [ForeignKey(typeof(Restaurante))]
        public int Id_Restaurante { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]     
        public Restaurante Restaurante { get; set; }
        public bool Visualizou_Tutorial { get; set; }
    }
}