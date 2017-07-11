using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDeMemoria
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

      /*  private void btnIniciar_Click(object sender, EventArgs e)
        {
            Hide();
            TelaMemorizar memorizar = new TelaMemorizar();
            memorizar.ShowDialog();                        
         }
        */
        private void btnSair_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            
            Hide();
            Jogo jogo = new Jogo();
            jogo.Show();
            
            
        }
    }
}
