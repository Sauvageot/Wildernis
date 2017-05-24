using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WildernisSurvival
{
    public partial class Form1 : Form
    {
        int fiberOldStly = 0;
        int berryOldStly = 0;
        int berryStly = 0;
        int meatStly = 0;
        int woodStly = 0;
        int waterStly = 0;
        int fiberStly = 0;

        int valHungerStly = 100;
        int valThirstStly = 100;
        int valHealthStly = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbcMainStly.SelectedTab = tbpGameStly;
            // verandert tab controll
            tbcMainStly.Appearance = TabAppearance.FlatButtons;
            tbcMainStly.ItemSize = new Size(0, 1);
            tbcMainStly.SizeMode = TabSizeMode.Fixed;

            pgbHungerStly.Value = valHungerStly;
            pgbThirstStly.Value = valThirstStly;
            pgbHealthStly.Value = valHealthStly;
        }

        private void btnExploreStly_Click(object sender, EventArgs e)
        {
           Random rnd = new Random();
           berryStly = rnd.Next(1, 4);
           fiberStly = rnd.Next(1, 6);

           berryOldStly = berryOldStly + berryStly;
           fiberOldStly = fiberOldStly + fiberStly; 
           lbxStoryStly.Items.Add("You've collected " + berryStly + " berry's and " + fiberStly + " fiber.");

           lblBerryStly.Text = Convert.ToString(berryOldStly);
           lblFiberStly.Text = Convert.ToString(fiberOldStly);
           //btnExploreStly.Enabled = false;
           valHungerStly = valHungerStly - 15;
           valThirstStly = valHungerStly - 20;
           SetPgbValuesStly();

            //if (pgbThirstStly.Value <= 0);
            //{
            //    pgbThirstStly.Value = 0;
            //}
            
        }

        private void SetPgbValuesStly()
        {
            pgbHungerStly.Value = valHungerStly;
            pgbThirstStly.Value = valThirstStly;
        }

        private void btnEatStly_Click(object sender, EventArgs e)
        {
            berryStly = berryStly - 5;
            valHungerStly = valHungerStly + 40;
            SetPgbValuesStly();

            lblBerryStly.Text = Convert.ToString(berryStly);

        }
    }
}
