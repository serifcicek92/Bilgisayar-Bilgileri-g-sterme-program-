using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Management;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            
            InitializeComponent();
            //int genislik, yukseklik, bitsayisi;
            //genislik = Screen.PrimaryScreen.Bounds.Width;
            //yukseklik = Screen.PrimaryScreen.Bounds.Height;
            //bitsayisi = Screen.PrimaryScreen.BitsPerPixel;
            ////MessageBox.Show("Ekran Çözünürlüðü: " + genislik + "x" + yukseklik + Environment.NewLine + "Bit Sayýsý:" + bitsayisi);
            ///
            int genislik, yukseklik, bitsayisi;
            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;
            bitsayisi = Screen.PrimaryScreen.BitsPerPixel;
            string Depo = textBox1.Text;
            string bilgisayarAdi = Dns.GetHostName();// Makine Adýyla Ayný
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            string kAdi = Environment.UserName;
            string domain = Environment.UserDomainName;
            string versiyon = Environment.Version.ToString();
            //string arayuz = Environment.UserInteractive.ToString(); //ture dönen deðer
            string makineAdi = Environment.MachineName;
            //string osVer = Environment.OSVersion.ToString(); // m,c w,n net 6.2.9200.0
            //string pC = Environment.ProcessorCount.ToString();
            //string a = Environment.StackTrace.ToString();
            //string b = Environment.TickCount.ToString();
            //string c = Environment.WorkingSet.ToString();

            string macAdres = MAC();
            CPU cpu = new CPU();
            RAM ram = new RAM();
            string islemciMarka = cpu.LblCpuMarka();
            string islemciSayisi = cpu.LblCpuSayisi();
            string ramboyut = ram.RAMget().ToString();

            label8.Text = ipAdresi;
            label9.Text = macAdres;
            label10.Text = kAdi;
            label11.Text = makineAdi;
            label12.Text = ramboyut;
            label13.Text = islemciMarka;
            label15.Text = genislik + " X " + yukseklik;
            


        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int genislik, yukseklik, bitsayisi;
            genislik = Screen.PrimaryScreen.Bounds.Width;
            yukseklik = Screen.PrimaryScreen.Bounds.Height;
            bitsayisi = Screen.PrimaryScreen.BitsPerPixel;
            MessageBox.Show("Ekran Çözünürlüðü: " + genislik + "x" + yukseklik + Environment.NewLine + "Bit Sayýsý:" + bitsayisi);
            string Depo = textBox1.Text;
            string bilgisayarAdi = Dns.GetHostName();// Makine Adýyla Ayný
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            string kAdi = Environment.UserName;
            string domain = Environment.UserDomainName;
            string versiyon = Environment.Version.ToString();
            //string arayuz = Environment.UserInteractive.ToString(); //ture dönen deðer
            string makineAdi = Environment.MachineName;
            //string osVer = Environment.OSVersion.ToString(); // m,c w,n net 6.2.9200.0
            //string pC = Environment.ProcessorCount.ToString();
            //string a = Environment.StackTrace.ToString();
            //string b = Environment.TickCount.ToString();
            //string c = Environment.WorkingSet.ToString();

            string macAdres = MAC();
            CPU cpu = new CPU();
            RAM ram = new RAM();
            string islemciMarka = cpu.LblCpuMarka();
            string islemciSayisi = cpu.LblCpuSayisi();
            string ramboyut = ram.RAMget().ToString();


            string metin = "\n Depo Adý: \t" + Depo +
                "\n Ýp Adresi: \t" + ipAdresi +
                "\n Mac Adresi: \t" + macAdres+
                "\n Kullanýcý Adý: \t" + kAdi+
                "\n Versiyon: \t" + versiyon+
                "\n Makine Adi:\t" + makineAdi+ 
                "\n Ram Miktarý: \t" + ramboyut+
                "\n Ýþlemci Marka: \t" + islemciMarka
                ;


            Bitmap bmp = new Bitmap(genislik, yukseklik);
            bmp.SetPixel(0, 0, Color.FromArgb(63, 127, 191));
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(63,127,191)))
            {
                
                gfx.FillRectangle(brush, 0, 0, genislik, yukseklik);
            }

            int koordX = genislik - 800;
            int koorY = yukseklik - 450;
            RectangleF rectf = new RectangleF(koordX,koorY, 800, 500);

            Graphics g = Graphics.FromImage(bmp);

            int fontsize = 20;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(metin, new Font("Tahoma", fontsize), Brushes.White, rectf);
            //g.DrawString("yourText", new Font("Tahoma", 8), Brushes.Black, rectf);

            g.Flush();


            //bmp.Save("c:\\deneme\\resimmmm.png");


            Wallpaper.Set(bmp, Wallpaper.Style.Stretched);

            //****-----------------------------------------------------------------------------
            //try
            //{
            //    Bitmap image1 = (Bitmap)Image.FromFile(@"C:\Documents and Settings\" +
            //        @"All Users\Documents\My Music\music.bmp", true);

            //    TextureBrush texture = new TextureBrush(image1);
            //    texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            //    Graphics formGraphics = this.CreateGraphics();
            //    formGraphics.FillEllipse(texture,
            //        new RectangleF(90.0F, 110.0F, 100, 100));
            //    formGraphics.Dispose();

            //}
            //catch (System.IO.FileNotFoundException)
            //{
            //    MessageBox.Show("There was an error opening the bitmap." +
            //        "Please check the path.");
            //}

            //MessageBox.Show("Thanks!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string MAC()
        {
            try
            {
                String macadress = string.Empty;
                string mac = null;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    OperationalStatus ot = nic.OperationalStatus;
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macadress = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                for (int i = 0; i <= macadress.Length - 1; i++)
                {
                    mac = mac + ":" + macadress.Substring(i, 2);
                    // mac adresini alýrken parça parça aldýðýndan 
                    //aralarýna : iþaretini biz atýyoruz.
                    i++;
                }
                mac = mac.Remove(0, 1);
                // en sonda kalan fazladan : iþaretini siliyoruz.
                return mac;
            }
            catch
            {

            }
            return null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
