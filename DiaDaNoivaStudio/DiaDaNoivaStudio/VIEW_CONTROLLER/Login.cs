using DiaDaNoivaStudio.MODEL;
using DiaDaNoivaStudio.VIEW_CONTROLLER;
using System;
using System.Drawing;//para utilir propriedade Color nos campos textos 23/09/2020 elias
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace DiaDaNoivaStudio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        #region drag drop
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "" || txtSenha.Text == "")
                {
                    //  lblError.Visible = true;
                    //  lblError.Text = "Campos usuário e senha devem ser preenchidos!";
                    lblError.Visible = true;
                    lblError.Text = "favor preencher usuário e senha!";
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                    txtUsuario.Focus();
                    return;
                }

                var login = Usuario.EncontrarUsuario(txtUsuario.Text, txtSenha.Text);
                if (login == null)
                {
                    lblError.Visible = true;
                    lblError.Text = "Usuário ou Senha Inválidos!";
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                }
                else
                {

                    //  Principal principal = new Principal();//elias 02/07/2018
                    //  Hide();
                    //  principal.ShowDialog();




                    var newlogin = Usuario.findByNameAndPassword(txtUsuario.Text, txtSenha.Text);
                    string perfil = login.perfil;
                    int codUsuario = login.cod_Usuario;
                    lblErro.Visible = false;
                    Principal principal = new Principal(perfil);
                    Hide();
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    principal.ShowDialog();
                    Show();
                    txtUsuario.Focus();
                }  //   */

                //      Principal principal = new Principal();//elias 02/07/2018
                //      Hide();
                //       principal.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show("erro no login", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Digite senha")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.LightGray;
                txtSenha.UseSystemPasswordChar = true;
            }
        }

       

        /*
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnEntrar_Click(null, null);
        }*/


        /*

                private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
            {
                lblErro.Visible = false;
            }*/


    }
}
