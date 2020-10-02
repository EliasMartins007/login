using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace DiaDaNoivaStudio.VIEW_CONTROLLER
{
    public partial class Principal : Form
    {
        private string _perfil;
        public Principal(string perfil)//estava comentado para logar sem banco de dados 18/09/2020 elias
        {
            InitializeComponent();
        }


        private void Principal_load()
        {
            if (_perfil == "Profissional")
            {
                MessageBox.Show("teste perfil profissional!");
            }
        }

    }
}
