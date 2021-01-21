using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavarYapim.Properties;

namespace UcakSavarYapim
{
    public partial class Form1 : Form
    {
        int sayi = 0;
        PictureBox ucakSavar = new PictureBox();
        PictureBox ucak = new PictureBox();
        PictureBox mermi = new PictureBox();
        ArrayList mermiList = new ArrayList();
        ArrayList dusmanUcak = new ArrayList();


        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            ucakSavar.Image = Resources.ucaksavar;
            this.Controls.Add(ucakSavar);
            ucakSavar.Location = new Point(300,475);

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dusmanUcak.Add(UcakUret());

            foreach (PictureBox item in dusmanUcak)
            {
                UcakHareket(item);
            }
        }

        private void UcakHareket(PictureBox ucak)
        {
            ucak.Image = Resources.ucak;
            int x = ucak.Location.X;
            int y = ucak.Location.Y;
            y += 5;
            //x = x + 2;
            ucak.Location = new Point(x,y);
            this.Controls.Add(ucak);
        }

        PictureBox UcakUret()
        {
            PictureBox ucak = new PictureBox();
            ucak.Image = Resources.ucak;
            Random rnd = new Random();
            int ucakBaslat = rnd.Next(1000);
            ucak.Location = new Point(ucakBaslat,0);

            timer3.Enabled = true;

            return ucak;;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            UcakSavarHareket(e);

            if (e.KeyCode==Keys.Space)
            {
                mermiList.Add(MermiUret());
                timer2.Enabled = true;
            }
        }

        private object MermiUret()
        {
            PictureBox mermi = new PictureBox();
            mermi.Image = Resources.mermi2;
            mermi.SizeMode = PictureBoxSizeMode.StretchImage;
            mermi.Location = new Point(ucakSavar.Location.X,ucakSavar.Location.Y);
            this.Controls.Add(mermi);

            return mermi;

        }

        private void UcakSavarHareket(KeyEventArgs e)
        {
            int ucakSavarx = ucakSavar.Location.X;
            int ucakSavary = ucakSavar.Location.Y;

            if (e.KeyCode == Keys.Right)
                ucakSavarx = ucakSavarx + 5;

            else if (e.KeyCode == Keys.Left)
                ucakSavarx = ucakSavarx - 5;

            ucakSavar.Location = new Point(ucakSavarx,ucakSavary);
            this.Controls.Add(ucakSavar);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach  (PictureBox herhangi in mermiList)
            {
                MermiHareket(herhangi);
            }
        }

        private void MermiHareket(PictureBox mermi)
        {
            mermi.Image = Resources.mermi;
            int x = mermi.Location.X;
            int y = mermi.Location.Y;
            y = y - 5;
            mermi.Location = new Point(x,y);
            this.Controls.Add(mermi);
        }

        
        PictureBox KaldırılanUcaklar = new PictureBox();
        PictureBox KaldırılanMermiler = new PictureBox();

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox item1 in mermiList)
            {
                foreach (PictureBox item2 in dusmanUcak)
                {
                    if (item1.Bounds.IntersectsWith(item2.Bounds))
                    {
                        this.Controls.Remove(item1);
                        this.Controls.Remove(item2);
                        KaldırılanMermiler = item1;
                        KaldırılanUcaklar = item2;
                        sayi++;
                        lblPuan.Text=sayi.ToString();
                    }
                    
                }
            }
            mermiList.Remove(KaldırılanMermiler);
            dusmanUcak.Remove(KaldırılanUcaklar);
        }
    }
}
