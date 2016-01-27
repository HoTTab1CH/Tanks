using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Projectile
    {
        public Projectile()
        {
            img = projectileImg.Up;
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            x = y = -40;
            Direct_x = Direct_y = 0;
            range = 0;
        }
        public void Run()
        {
            if (Direct_x == 0 && Direct_y == 0)
                return;
            range += 3;
            x += Direct_x * 3;
            y += Direct_y * 3;
            PutImg();
            if (range > 240)
                DefaultSettings();
        }

        public int Direct_x
        {
            get
            {
                return direct_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else
                    direct_x = 0;
            }
        }
        public int Direct_y
        {
            get
            {
                return direct_y;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else
                    direct_y = 0;
            }
        }
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Image Img
        {
            get
            {
                return img;
            }

        }
        private void PutImg()
        {
            if (direct_x == 1)
                img = projectileImg.Right;
            if (direct_x == -1)
                img = projectileImg.Left;
            if (direct_y == 1)
                img = projectileImg.Down;
            if (direct_y == -1)
                img = projectileImg.Up;
        }

        private ProjectileImg projectileImg = new ProjectileImg();
        private Image img;
        private int x, y, direct_x, direct_y;
        private int range;

    }
}
