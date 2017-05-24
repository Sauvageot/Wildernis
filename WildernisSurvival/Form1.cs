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
        int berryStly = 0;
        int meatStly = 0;
        int woodStly = 0;
        int waterStly = 0;
        int fiberStly = 0;

        int fiberOldStly = 0;
        int berryOldStly = 0;
        int waterOldStly = 0;

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
           berryStly = rnd.Next(1, 5);
           fiberStly = rnd.Next(0, 3);

           berryOldStly = berryOldStly + berryStly;
           fiberOldStly = fiberOldStly + fiberStly; 
           lbxStoryStly.Items.Add("You've collected " + berryStly + " berry's and " + fiberStly + " fiber.");

           lblBerryStly.Text = Convert.ToString(berryOldStly);
           lblFiberStly.Text = Convert.ToString(fiberOldStly);
           //btnExploreStly.Enabled = false;
           valHungerStly = valHungerStly - 15;
           valThirstStly = valThirstStly - 20;
           SetPgbValuesStly();

            //if (pgbThirstStly.Value <= 0);
            //{
            //    pgbThirstStly.Value = 0;
            //}
            
        }

        private void SetPgbValuesStly()
        {
            if (valHungerStly > 100)
            {
                pgbHungerStly.Value = 100;
                valHungerStly = 100;
                btnEatStly.Enabled = false;
            }
            else
            {
                btnEatStly.Enabled = true;
                pgbHungerStly.Value = valHungerStly;
            }

            if (valThirstStly > 100)
            {
                pgbThirstStly.Value = 100;
                btnDrinkStly.Enabled = false;
                valThirstStly = 100;
            }
            else
            {
                btnDrinkStly.Enabled = true;
                pgbThirstStly.Value = valThirstStly; 
            }
          
        }

        private void btnEatStly_Click(object sender, EventArgs e)
        {
            berryStly = berryOldStly - 5;
            valHungerStly = valHungerStly + 50;
            SetPgbValuesStly();
            lblBerryStly.Text = Convert.ToString(berryStly);
        }

        private void btnDrinkStly_Click(object sender, EventArgs e)
        {
            waterStly = waterOldStly - 2;
            valThirstStly = valThirstStly + 40;
            SetPgbValuesStly();
            lblWaterStly.Text = Convert.ToString(waterStly);
        }

        private void btnGetWaterStly_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            waterStly = rnd.Next(1, 4);

            waterOldStly = waterOldStly + waterStly;
            lbxStoryStly.Items.Add("You've collected " + waterStly + " liters of water.");
 
            valThirstStly = valThirstStly - 20;
            valHungerStly = valHungerStly - 15;
            SetPgbValuesStly();
            lblWaterStly.Text = Convert.ToString(waterOldStly);
        }
    }
}
