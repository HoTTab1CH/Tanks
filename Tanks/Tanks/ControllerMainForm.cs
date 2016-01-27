using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

[assembly: CLSCompliant(true)]
namespace Tanks
{
    delegate void Invoker();
    public partial class ControllerMainForm : Form
    {
        public ControllerMainForm() : this(390) { }
        public ControllerMainForm(int sizeField) : this(sizeField, 5) { }
        public ControllerMainForm(int sizeField, int amountTanks) : this(sizeField, amountTanks, 5) { }
        public ControllerMainForm(int sizeField, int amountTanks, int amountApples) : this(sizeField, amountTanks, amountApples, 20) { }
        public ControllerMainForm(int sizeField, int amountTanks, int amountApples, int speedGame)
        {
            InitializeComponent();
            model = new Model(sizeField, amountTanks, amountApples, speedGame);
            model.changeStrip += new StripDel(ChangerStatusStripLbl);
            view = new View(model);
            this.Controls.Add(view);
            SoundEnable = true;
            sp = new SoundPlayer(Properties.Resources.PacmanMove);
        }

        private void ChangerStatusStripLbl()
        {
            Invoke(new Invoker(SetValueToStrLbl));
        }
        private void SetValueToStrLbl()
        {
            GameStatus_lbl_ststrp.Text = model.gameStatus.ToString();
            if (model.gameStatus == GameStatus.playing && SoundEnable == true)
                sp.PlayLooping();
            else
                sp.Stop();
        }
        private void StartPause_btn_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoped;
                ChangerStatusStripLbl();
            }
            else
            {
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();
                ChangerStatusStripLbl();
                view.Invalidate();
            }

        }
        private void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                model.gameStatus = GameStatus.stoped;
                modelPlay.Abort();
            }

            DialogResult dr = MessageBox.Show("Ви справді хочете покинути гру?", "Танки", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,MessageBoxOptions.DefaultDesktopOnly);
            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }
        private void ManipulatePacman(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                case 'ф':
                case 'A':
                case 'Ф':

                    {
                        model.Pacman.NextDirect_x = -1;
                        model.Pacman.NextDirect_y = 0;
                    }
                    break;

                case 'd':
                case 'в':
                case 'D':
                case 'В':

                    {
                        model.Pacman.NextDirect_x = 1;
                        model.Pacman.NextDirect_y = 0;
                    }
                    break;

                case 'w':
                case 'ц':
                case 'W':
                case 'Ц':

                    {
                        model.Pacman.NextDirect_x = 0;
                        model.Pacman.NextDirect_y = -1;
                    }
                    break;

                case 's':
                case 'ы':
                case 'і':
                case 'S':
                case 'Ы':
                case 'І':

                    {
                        model.Pacman.NextDirect_x = 0;
                        model.Pacman.NextDirect_y = 1;
                    }
                    break;

                case 'K':
                case 'k':
                case 'Л':
                case 'л':



                    {
                        SetProjectileFromStart();
                    }
                    break;
            }
        }

        private void SetProjectileFromStart()
        {
            int fix = 13;
            model.Projectile.Direct_x = model.Pacman.Direct_x;
            model.Projectile.Direct_y = model.Pacman.Direct_y;

            if (model.Pacman.Direct_y == -1)
            {
                model.Projectile.X = model.Pacman.X + fix;
                model.Projectile.Y = model.Pacman.Y;
            }
            if (model.Pacman.Direct_y == 1)
            {
                model.Projectile.X = model.Pacman.X + fix;
                model.Projectile.Y = model.Pacman.Y + fix * 2;
            }

            if (model.Pacman.Direct_x == -1)
            {
                model.Projectile.X = model.Pacman.X;
                model.Projectile.Y = model.Pacman.Y + fix;
            }

            if (model.Pacman.Direct_x == 1)
            {
                model.Projectile.X = model.Pacman.X + fix * 2;
                model.Projectile.Y = model.Pacman.Y + fix;
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            view.Refresh();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
                   'Гра пакмен'
          Розробив Михайло Кушпіт
     у процесі вивчення платформи .NET

     Для керування використовуйте клавіші
         W A S D та K для стрільби
                ", "Tanks", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void SoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundEnable = !SoundEnable;
            if (SoundEnable)
                soundToolStripMenuItem.Text = "Sound ON";
            else soundToolStripMenuItem.Text = "Sound OFF";
        }

        View view;
        Model model;
        bool SoundEnable;
        Thread modelPlay;
        SoundPlayer sp;

    }
}
