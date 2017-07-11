using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace JogoDeMemoria
{
    public partial class TelaGanhou : Form
    {
        private SoundPlayer ganhouSound;

        public TelaGanhou()
        {
            InitializeComponent();
         //   ganhouSound = new SoundPlayer("ganhou.wav");
        }

        private void TelaGanhou_Load(object sender, EventArgs e)
        {
          //  ganhouSound.PlayLooping();
        }

        private void btnJogarNovamente_Click(object sender, EventArgs e)
        {
           
         //   ganhouSound.Stop();
            Hide(); 
            TelaInicial inicial = new TelaInicial();
            inicial.ShowDialog();          
             
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Dispose(); 
           // ganhouSound.Stop();
        }
    }
}
