using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Vision.Motion;

namespace Goruntuisleme
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice kameraAygit;
        private FilterInfoCollection webcamAygit;
        bool LEDdurumu = false;
        SerialPort seriPort;

        public Form1()
        {
            InitializeComponent();

            seriPort = new SerialPort();
            seriPort.PortName = "COM3";
            seriPort.BaudRate = 9600;
            seriPort.Open();
        }

        //*****************************************

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (seriPort.IsOpen) seriPort.Close();
            if (kameraAygit != null && kameraAygit.IsRunning)
            {
                kameraAygit.SignalToStop();
                kameraAygit = null;
            }
        }

        //*****************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            labelleddurum.Visible = false;
            webcamAygit = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcamAygit)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name); // WebCamleri listele
                comboBox1.SelectedIndex = 0;
            }

        }

        //*****************************************

        void cam_goruntu_new_frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            var filter2 = new Mirror(false, true);
            filter2.ApplyInPlace(image1);
            var filter = new Mirror(false, true);
            filter.ApplyInPlace(image);
            pictureBox1.Image = image;
            

            EuclideanColorFiltering filter1 = new EuclideanColorFiltering();
            filter1.CenterColor = new RGB(Color.FromArgb(10, 14, 200));
            filter1.Radius = 100;
            filter1.ApplyInPlace(image1);
            nesnebul(image1);



        }

        //*****************************************

        public void nesnebul(Bitmap image)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 2;
            blobCounter.MinHeight = 2;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            Grayscale griFiltre = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap griImage = griFiltre.Apply(image);
            blobCounter.ProcessImage(griImage);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            pictureBox2.Image = image;
            foreach (Rectangle recs in rects)
            {
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    //Graphics g = Graphics.FromImage(image);
                    Graphics g = pictureBox1.CreateGraphics();
                    using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                    //Cizdirilen Dikdörtgenin Koordinatlari aliniyor.
                    int objectX = objectRect.X + (objectRect.Width / 2);
                    int objectY = objectRect.Y + (objectRect.Height / 2);
                    int saklax = objectX;
                    int saklay = objectY;
                    g.DrawString(objectX.ToString() + "X" + objectY.ToString(), new Font("Arial", 12), Brushes.Black, new System.Drawing.Point(560, 10));
                    g.Dispose();
                    int[] dizi = new int[100];
                    //bölge 1
                    if (saklax < 213 && saklay < 160 && saklax > 0 && saklay > 0)
                    {
                        seriPort.Write("1");
                        LEDdurumu = true;
                    }
                    if (saklax < 426 && saklay < 160 && saklax > 213 && saklay > 0)
                    {
                        seriPort.Write("2");
                        LEDdurumu = true;
                    }
                    if (saklax < 640 && saklay < 160 && saklax > 426 && saklay > 0)
                    {
                        seriPort.Write("3");
                        LEDdurumu = true;

                    }
                    if (saklax < 213 && saklay < 320 && saklax > 0 && saklay > 160)
                    {
                        seriPort.Write("4");
                        LEDdurumu = true;
                    }
                    if (saklax < 426 && saklay < 320 && saklax > 213 && saklay > 160)
                    {
                        seriPort.Write("5");
                        LEDdurumu = true;

                    }
                    if (saklax < 640 && saklay < 320 && saklax > 426 && saklay > 160)
                    {
                        seriPort.Write("6");
                        LEDdurumu = true;
                    }
                    if (saklax < 213 && saklay < 480 && saklax > 0 && saklay > 320)
                    {
                        seriPort.Write("7");
                        LEDdurumu = true;
                    }
                    if (saklax < 426 && saklay < 480 && saklax > 213 && saklay > 320)
                    {
                        seriPort.Write("8");
                        LEDdurumu = true;
                    }
                    if (saklax < 640 && saklay < 480 && saklax > 426 && saklay > 320)
                    {
                        seriPort.Write("9");
                        LEDdurumu = true;
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kameraAygit = new VideoCaptureDevice(webcamAygit[comboBox1.SelectedIndex].MonikerString);//webcam listesinden kafadan birinciyi al diyoruz.
            kameraAygit.NewFrame += new NewFrameEventHandler(cam_goruntu_new_frame);
            kameraAygit.Start();
        }

    }
}


