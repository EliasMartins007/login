using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;//teste 18/09/2020 elias casa
namespace DiaDaNoivaStudio.MODEL
{
    class Usuario
    {
        public int cod_Usuario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string perfil { get; set; }
        public int idProfissional { get; set; }
        public string nomeProfissional { get; set; }



        




    public static Usuario EncontrarUsuario(string login, string senha)
    {
        try
        {
            bool conexao = Conexao.AbrirConexao();
            if (conexao)
            {
                //var sql = @"select * from tblusuario where login = @name and senha = md5(@password)";
                var sql = @"select * from tblusuario where login = ? and senha = ?";
                //               



                var cmd = Conexao.getConexao().CreateCommand();
                //                  cmd.CommandText = sql;

                var cmd2 = Conexao.getConexao().CreateCommand();
                cmd2.CommandText = sql;

                //  cmd2.CommandText = "select * from tblusuario where login = @name and senha = md5(@password)";





                //cmd2.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar,));



                // cmd2.Parameters.AddRange(new OleDbParameter[] 
                //  {
                //      new OleDbParameter("name", login),
                //      new OleDbParameter("password", senha),


                //  });


                cmd2.Parameters.AddWithValue("@name", login);//teste 08/11/2018
                cmd2.Parameters.AddWithValue("@password", senha);//teste 08/11/2018

                //original              //    cmd.Parameters.AddWithValue("?name", login);//passou @name
                //    cmd.Parameters.AddWithValue("?password", senha);//passou @password

                //                  var reader = cmd2.ExecuteNonQuery();//add 08/11/2018


                var reader = cmd2.ExecuteReader();
                //   var reader = cmd.ExecuteReader();//erro da nessa linha

                if (!reader.HasRows)
                {
                    cmd2.Dispose();
                    Conexao.FecharConexao();
                    return null;
                }

                reader.Read();
                //    Usuario teste = new Usuario();
                //não tenho comando repetição aki pois busco usuario expecifico 09/11/2018 

                var usuarioEncontrado = new Usuario();
                //SQLSERVER
                //  usuarioEncontrado.login =Convert.ToInt32("login").ToString();//login
                usuarioEncontrado.login = Convert.ToString("login");//teste 09/11/2018 
                usuarioEncontrado.senha = Convert.ToString("senha");//teste 09/11/2018


                //teste.login =Convert.ToString("login");

                //teste.idProfissional = Convert.ToInt32("id_profissional");

                //MYSQL
                //  usuarioEncontrado.login = reader.GetString(Convert.ToInt32("login");//08/11/2018 //da erro cadeia de caracteres nao estava em  formato correto
                //usuarioEncontrado.senha = reader.GetString(Convert.ToInt32("senha"));
                //usuarioEncontrado.senha = reader.GetString("senha");
                //                   usuarioEncontrado.perfil = reader.GetString(Convert.ToInt32("perfil"));
                //usuarioEncontrado.perfil = reader.GetString("perfil");
                //                    usuarioEncontrado.idProfissional = reader.GetInt32(reader.GetOrdinal("id_profissional"));
                //usuarioEncontrado.idProfissional = reader.GetInt32("id_profissional");

                reader.Close();
                cmd2.Dispose();
                Conexao.FecharConexao();

                return usuarioEncontrado;
            }
            return null;
        } catch (Exception ex)
         {
          MessageBox.Show("erro em buscar Usuário", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
         }
    }










        //Aqui começa o método de verificar o usuário para login 18/09/2020 elias

        public static Usuario findByNameAndPassword(String usuario, String senha)
        {
            bool conexao = Conexao.AbrirConexao();
            if (conexao)
            {
                var sql = @"select * from tblusuario where login = ? and senha = ?";//mysql @name and senha = md5(@password)
                var cmd = Conexao.getConexao().CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@name", usuario);
                cmd.Parameters.AddWithValue("@password", senha);

                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    cmd.Dispose();
                    Conexao.FecharConexao();
                    return null;
                }

                reader.Read();

                var usuarioEncontrado = new Usuario();
                /*       usuarioEncontrado.login = reader.GetString("login");
                       usuarioEncontrado.senha = reader.GetString("senha");
                       usuarioEncontrado.perfil = reader.GetString("perfil");
                       usuarioEncontrado.cod_Usuario = reader.GetInt32("cod_usuario");
                       */
                reader.Close();
                cmd.Dispose();
                Conexao.FecharConexao();

                return usuarioEncontrado;
            }
            return null;
        }









    }
}
