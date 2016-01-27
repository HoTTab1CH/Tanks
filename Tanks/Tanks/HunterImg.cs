using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class HunterImg
    {
        Image[] up = new Image[]
    {
            Properties.Resources.Hunter0_1_I,
            Properties.Resources.Hunter0_1_II,
            Properties.Resources.Hunter0_1_III,
            Properties.Resources.Hunter0_1_IV
    };

        Image[] down = new Image[]
            {
            Properties.Resources.Hunter01_I,
            Properties.Resources.Hunter01_II,
            Properties.Resources.Hunter01_III,
            Properties.Resources.Hunter01_IV
            };
        Image[] right = new Image[]
            {
            Properties.Resources.Hunter10_I,
            Properties.Resources.Hunter10_II,
            Properties.Resources.Hunter10_III,
            Properties.Resources.Hunter10_IV
            };

        Image[] left = new Image[]
            {
            Properties.Resources.Hunter_10_I,
            Properties.Resources.Hunter_10_II,
            Properties.Resources.Hunter_10_III,
            Properties.Resources.Hunter_10_IV
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
