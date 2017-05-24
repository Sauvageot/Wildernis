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
        string currentSoundStly = "";
        [DllImport("winmm.dll")]
        private static extern long mciSendString(
        string strCommand,
        StringBuilder strReturn,
        int iReturnLength,
        IntPtr hwndCallback);

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
        /*DialogResult yesNoResultSsau = MessageBox.Show("pick one: Yes or No", "Yes/No", MessageBoxButtons.YesNo);

            if (yesNoResultSsau == DialogResult.Yes) 
            {
                lblSsau.Text = "Yes";
            }

            else
            {
                lblSsau.Text = "No";
            }
            */

private void PlayAudio(csClassSound Sounds)
        {
            StopAudio();

            //play audio
            mciSendString("open \"" + Sounds.soundPath
                          + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

        }
        private static void StopAudio()
        {
            //Stop audio if audio already played
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);
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
           // csClassSound.soundName = 
            berryStly = berryStly - 5;
            valHungerStly = valHungerStly + 40;
            SetPgbValuesStly();

            lblBerryStly.Text = Convert.ToString(berryStly);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory, "Current Location");
        }
    }
}
