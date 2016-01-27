using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class PacmanImg
    {
        Image[] up = new Image[]
            {
            Properties.Resources.Pacman0_1_I,
            Properties.Resources.Pacman0_1_II,
            Properties.Resources.Pacman0_1_III,
            Properties.Resources.Pacman0_1_IV
            };

        Image[] down = new Image[]
            {
            Properties.Resources.Pacman01_I,
            Properties.Resources.Pacman01_II,
            Properties.Resources.Pacman01_III,
            Properties.Resources.Pacman01_IV
            };
        Image[] right = new Image[]
            {
            Properties.Resources.Pacman10_I,
            Properties.Resources.Pacman10_II,
            Properties.Resources.Pacman10_III,
            Properties.Resources.Pacman10_IV
            };

        Image[] left = new Image[]
            {
            Properties.Resources.Pacman_10_I,
            Properties.Resources.Pacman_10_II,
            Properties.Resources.Pacman_10_III,
            Properties.Resources.Pacman_10_IV
            };

        public Image[] Up
        {
            get
            {
                return up;
            }

        }

        public Image[] Down
        {
            get
            {
                return down;
            }

        }

        public Image[] Right
        {
            get
            {
                return right;
            }

        }

        public Image[] Left
        {
            get
            {
                return left;
            }

        }
    }
}
