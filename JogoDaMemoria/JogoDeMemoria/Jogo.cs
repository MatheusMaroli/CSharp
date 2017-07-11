using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDeMemoria
{


    public partial class Jogo : Form
    {
        private RegraJogo _Jogo;

        public void AtualizarJogada(int qtdade)
        {
            lblCliques.Text = qtdade.ToString();
        }

        public Jogo()
        {
            InitializeComponent();
            _Jogo = new RegraJogo(this);         
        }
        

    }
}
