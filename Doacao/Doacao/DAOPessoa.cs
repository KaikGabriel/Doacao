using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Doacao
{
    class DAOPessoa
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        //vetor
        public int[] vetorCodigoCliente;
        public string[] vetorEmail;
        public string[] vetorNome;
        public string[] vetorTelefone;
        public string[] vetorEndereco;
        public int i;



        public DAOPessoa()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=DoacaoBD;Uid=root;password=;");
            try
            {
                conexao.Open();//Tentando conectar ao BD
            }catch(Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);//Mandando mensagem de erro para o usuario
                conexao.Close();//Fechando a conexao com o bd
            }
        }//Fim DAOPessoa






        public void Inserir(string nome, string email, string telefone, string endereco)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + email + "','" + nome + "','" + telefone + "','" + endereco + "')";
                comando = "Insert into Cliente(codigoCliente, email, nome, telefone, endereco) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Cadastrado!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
        }//fim do método inserir



        public void PreencherVetor()
        {
            string query = "select * from Cliente";


            vetorCodigoCliente = new int[100];
            vetorEmail = new string[100];
            vetorNome = new string[100];
            vetorTelefone = new string[100];
            vetorEndereco = new string[100];


            for(i=0; i < 100; i++)
            {
                vetorCodigoCliente[i] = 0;
                vetorEmail[i] = "";
                vetorNome[i] = "";
                vetorTelefone[i] = "";
                vetorEndereco[i] = "";
            }//Fim for
        }






    }//Fim da classe
}//Fim do projeto
