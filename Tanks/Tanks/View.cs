using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tanks
{
    partial class View : UserControl
    {
        public View(Model model)
        {
            InitializeComponent();

            this.model = model;

        }
        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawFireTank(e);
            DrawApple(e);
            DrawTank(e);
            DrawPacman(e);
            DrawProjectile(e);

            if (model.gameStatus != GameStatus.playing)
                return;

            Thread.Sleep(model.SpeedGame);
            Invalidate();

        }

        private void DrawFireTank(PaintEventArgs e)
        {
            foreach (FireTank ft in model.FireTank)
                e.Graphics.DrawImage(ft.CurrentImg, new Point(ft.X, ft.Y));
        }
        private void DrawProjectile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Projectile.Img, new Point(model.Projectile.X, model.Projectile.Y));
        }
        private void DrawPacman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Pacman.CurrentImg, new Point(model.Pacman.X, model.Pacman.Y));
        }
        private void DrawApple(PaintEventArgs e)
        {
            for (int i = 0; i < model.Apples.Count; i++)
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));
        }
        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].CurrentImg, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }
        private void DrawWall(PaintEventArgs e)
        {
            for (int y = 30; y < 390; y += 60)
                for (int x = 30; x < 390; x += 60)
                    e.Graphics.DrawImage(model.Wall.Img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }

        Model model;
    }
}
