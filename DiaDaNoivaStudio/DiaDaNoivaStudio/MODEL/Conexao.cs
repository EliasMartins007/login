using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //  para Sql server 18/09/2020
using System.Data.OleDb;//18/09/2020

using System.Windows.Forms; // para messageBox

namespace DiaDaNoivaStudio.MODEL
{
    class Conexao
    {
       

        public static string conexao;//strConn
        protected static OleDbConnection CN;
       

        public static Boolean AbrirConexao()
        {
            try
            {
                
                conexao = "Provider=SQLOLEDB.1;Password=123;Persist Security Info=True;User ID=elias;Initial Catalog=mydb;Data Source=DESKTOP-ELIAS\\MSSQLSERVER_CASA";//192.168.1.105";  casa helio 26/06/2020;

                
                CN = new OleDbConnection(conexao);//conexao com banco de dados

                CN.Open();//gerando exceção aki26/06/2020

                CN.State.Equals(ConnectionState.Open);

                if (CN.State != System.Data.ConnectionState.Open)
                {
                    CN.Open(); //Abri a conexão
                }
                return CN.State == System.Data.ConnectionState.Open;
                /* if (conexao.State != System.Data.ConnectionState.Open)
                  {
                      conexao.Open(); //Abri a conexão //antes na faculdade 
                  }
                  return conexao.State == System.Data.ConnectionState.Open;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro na conexão", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(COMMUN.ClsError.LogError(ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean FecharConexao()
        {
            //Verifica se a conexão esta aberta
            if (CN.State == System.Data.ConnectionState.Open)
            {
                CN.Close(); //Fecha a conexão
                CN.Dispose();
                return CN.State == System.Data.ConnectionState.Closed;// CN == conexao
            }
            else
                return false;
        }


        //sql server 08/11/2018 novo praxis 
        public static OleDbConnection getConexao()//SqlConnection
        {
            return CN;//conexao
        }

        //para mysql /2016  antingo faculdade
        //public static MySqlConnection getConexao()
        //{
        //    return conexao;
        //}
    }
}
