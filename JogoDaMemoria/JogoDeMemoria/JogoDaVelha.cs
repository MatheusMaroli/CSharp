using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace JogoDeMemoria
{


    public class JogoDaVelha
    {
        private class ImagemButton
        {
            public int Tag {get;set; }
            public PictureBox Imagem{get;set; }
            

            public ImagemButton()
            {
                Imagem = new PictureBox();
            }
        }

        private List<Button> Buttons = new List<Button>();
        private List<ImagemButton> Imagem = new List<ImagemButton>();
        private PictureBox Box = new PictureBox() { Image = Image.FromFile(@"F:\C#\JogoDaMemoria-master\JogoDeMemoria\Resources\box.png") };


        private Button UltimoButtonClicado;
        private Button BtnAtual;
        private System.Timers.Timer Timer;
        private Form formJogo;

        public int ContadorDeJogadas { get; private set; }
        
        public JogoDaVelha(Form form)
        {
            formJogo = form;
            CarregarTimer();
            ContadorDeJogadas = 0;
            CarregarImagem();
            CarregarButton();
            RandomizarButtons();
            
        }

        private void CarregarTimer()
        {
            Timer = new System.Timers.Timer();
            Timer.Interval = 500;
            Timer.Elapsed += OcultaImagem;
            Timer.AutoReset = true;
        }

        private void CarregarButton()
        {
            var Tag = 1;
            var J = 0;
            
            for (var i=0; i<formJogo.Controls.Count; i++)
                if(formJogo.Controls[i] is Button)
                {
                    var btn =(Button)formJogo.Controls[i];
                    btn.Click += ClickBtnImagem;
                    btn.Tag = Tag;
                    btn.BackgroundImage = Box.Image;
                    Buttons.Add(btn);
                    if (J%2 != 0)
                        Tag++;
                    J++;
                }
        }


        private void RandomizarButtons()
        {
            var random = new Random();
            var quantidadeButton = Buttons.Count();
            foreach(var btn in Buttons)
            {
                var btnPosicaoRandom = BuscarButtonDoIndex(random.Next(0, quantidadeButton));
                var posicaoBtn = btn.Location;
                btn.Location = btnPosicaoRandom.Location;
                btnPosicaoRandom.Location = posicaoBtn;
            }

        }

        private Button BuscarButtonDoIndex(int posicao)
        {
            for(var i=0; i< Buttons.Count(); i++)
                if (i == posicao)
                    return Buttons[i];
            return null;
        }

        private void CarregarImagem()
        {
            DirectoryInfo Dir = new DirectoryInfo(@"F:\C#\JogoDaMemoria-master\JogoDeMemoria\Resources\Figura");
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.TopDirectoryOnly);
            
            for (var i=0; i<Files.Count(); i++)    
                Imagem.Add(new ImagemButton() {
                    Imagem = new PictureBox() { Image =  Image.FromFile(Files[i].FullName) },
                    Tag = i + 1 
                });
            
        }


        private void ClickBtnImagem(object sender, EventArgs e)
        {
            BtnAtual = (Button)sender;

            if (BtnAtual.BackgroundImage != Box.Image)
                return;

            if (UltimoButtonClicado == null)
            {
                UltimoButtonClicado = (Button)sender;
                UltimoButtonClicado.BackgroundImage = BuscarImagemButtonTag((int)UltimoButtonClicado.Tag);
            }
            else
            {
                BtnAtual.BackgroundImage =  BuscarImagemButtonTag((int)BtnAtual.Tag);

                if (! UltimoButtonClicado.Tag.Equals(BtnAtual.Tag))                
                    Timer.Enabled = true;

                if (!Timer.Enabled)
                    UltimoButtonClicado = null;

                ContadorDeJogadas += 1;
            }
            
            if (JogoAcabou())
                ResetJogo();

        }

        private void ResetJogo()
        {
            formJogo.Dispose();
            var telaGanhou = new TelaGanhou();
            telaGanhou.Show();
        }

        private bool JogoAcabou()
        {
            foreach(var btn in Buttons)
                if (btn.BackgroundImage == Box.Image)
                    return false;
            return true;
        }

        private void OcultaImagem(object sender, EventArgs e)
        {
            if (UltimoButtonClicado != null)
            {
                BtnAtual.BackgroundImage = Box.Image;
                UltimoButtonClicado.BackgroundImage = Box.Image;
                var timerOff = (System.Timers.Timer)sender;
                timerOff.Enabled =false;
                UltimoButtonClicado = null;
            }
        }

        private Image BuscarImagemButtonTag(int tag)
        {
            return Imagem.FirstOrDefault(i => i.Tag == tag).Imagem.Image;
        }
    }
}
