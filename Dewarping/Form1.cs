using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Dewarping
{
    public partial class Dewarping : Form
    {
        Bitmap picture2, picture1; 
        
        double shag;
        int Hf, Wf, He, We, counter;
        double R, Cfx, Cfy;
        const double PI = 3.141592653589793;

        public Dewarping()
        {
            InitializeComponent();
        }


        static public double linear(int x, double[] xd, int[] yd)
        {
            if (xd.Length != yd.Length)
            {
                throw new ArgumentException("Arrays must be of equal length."); 
            }
            double sum = 0;
            int i = 0;

                while (i <= xd.Length - 1)
                {
                    
                    if (xd[i] > x)
                    {

                    sum = yd[i - 1] + (x - xd[i - 1]) * (yd[i] - yd[i - 1]) / (xd[i] - xd[i - 1]);
                        i = xd.Length;
                    }
                    i++;
                }
                
            return sum;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e) // - алгоритм с маштабированием. Попытка ниписать свой "велосипед". Маштабирование удалось, но возникает построчный сдвиг. Планирую пытаться доделать.
        {
            int R = pictureBox1.Image.Height /2 -1;
            int XY = R;
            int nW = 0;
            
            Bitmap bitmap2 = (Bitmap)pictureBox1.Image;
            Color color;

            Bitmap picture4;
            int[,] Re4;     
            int[,] Gree4;   
            int[,] Blu4;

            int x = 0;
            int y = R;
            int delta = 1 - 2 * R;
            int error = 0;


            while (y >= x)
            {
                nW++;
                nW++;
                if (x != 0)
                {
                    nW++;
                }

                if (x != 0)
                {
                    nW++;
                }
                if (x != y)
                {
                    nW++;
                }
                if (x != y)
                {
                    nW++;
                }
                if (x != 0 && x != y)
                {
                    nW++;
                }
                if (x != 0 && x != y)
                {
                    nW++;
                }
                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);

            }
            Re4 = new int[nW, R];
            Gree4 = new int[nW, R];
            Blu4 = new int[nW, R];

            while (R > 20)
            {
                x = 0;
                y = R;
                
                delta = 1 - 2 * R;
                error = 0;

                List<int> Red1 = new List<int>();
                List<int> Green1 = new List<int>();
                List<int> Blue1 = new List<int>();
                List<int> Red2 = new List<int>();
                List<int> Green2 = new List<int>();
                List<int> Blue2 = new List<int>();
                List<int> Red3 = new List<int>();
                List<int> Green3 = new List<int>();
                List<int> Blue3 = new List<int>();
                List<int> Red4 = new List<int>();
                List<int> Green4 = new List<int>();
                List<int> Blue4 = new List<int>();
                List<int> Red5 = new List<int>();
                List<int> Green5 = new List<int>();
                List<int> Blue5 = new List<int>();
                List<int> Red6 = new List<int>();
                List<int> Green6 = new List<int>();
                List<int> Blue6 = new List<int>();
                List<int> Red7 = new List<int>();
                List<int> Green7 = new List<int>();
                List<int> Blue7 = new List<int>();
                List<int> Red8 = new List<int>();
                List<int> Green8 = new List<int>();
                List<int> Blue8 = new List<int>();


                int X_Y = XY;
                while (y >= x)
                {
                    color = bitmap2.GetPixel(X_Y + x, X_Y + y);
                    Red1.Add(color.R);
                    Green1.Add(color.G);
                    Blue1.Add(color.B);

                    color = bitmap2.GetPixel(X_Y + x, X_Y - y);
                    Red2.Add(color.R);
                    Green2.Add(color.G);
                    Blue2.Add(color.B);
                    if (x != 0) {
                        color = bitmap2.GetPixel(X_Y - x, X_Y + y);
                        Red3.Add(color.R);
                        Green3.Add(color.G);
                        Blue3.Add(color.B);
                    }

                    if (x != 0)
                    {
                        color = bitmap2.GetPixel(X_Y - x, X_Y - y);
                        Red4.Add(color.R);
                        Green4.Add(color.G);
                        Blue4.Add(color.B);
                    }
                    if (x != y)
                    {
                        color = bitmap2.GetPixel(X_Y + y, X_Y + x);
                        Red5.Add(color.R);
                        Green5.Add(color.G);
                        Blue5.Add(color.B);
                    }
                    if (x != y)
                    {
                        color = bitmap2.GetPixel(X_Y + y, X_Y - x);
                        Red6.Add(color.R);
                        Green6.Add(color.G);
                        Blue6.Add(color.B);
                    }
                    if (x != 0 && x != y)
                    {
                        color = bitmap2.GetPixel(X_Y - y, X_Y + x);
                        Red7.Add(color.R);
                        Green7.Add(color.G);
                        Blue7.Add(color.B);
                    }
                    if (x != 0 && x != y)
                    {
                        color = bitmap2.GetPixel(X_Y - y, X_Y - x);
                        Red8.Add(color.R);
                        Green8.Add(color.G);
                        Blue8.Add(color.B);
                    }
                

                    error = 2 * (delta + y) - 1;
                    if ((delta < 0) && (error <= 0))
                    {
                        delta += 2 * ++x + 1;
                        continue;
                    }
                    if ((delta > 0) && (error > 0))
                    {
                        delta -= 2 * --y + 1;
                        continue;
                    }
                    delta += 2 * (++x - --y);

                    
                }
                int longM = Red1.Count + Red2.Count + Red3.Count + Red4.Count + Red5.Count + Red6.Count + Red7.Count + Red8.Count;
                double[] Xs = new double[longM];
                int[] Xr = new int[longM];
                int[] Xg = new int[longM];
                int[] Xb = new int[longM];
                shag = ((double)nW) / (longM);
                Red1.Reverse();
                Green1.Reverse();
                Blue1.Reverse();
                Red4.Reverse();
                Green4.Reverse();
                Blue4.Reverse();
                Red6.Reverse();
                Green6.Reverse();
                Blue6.Reverse();
                Red7.Reverse();
                Green7.Reverse();
                Blue7.Reverse();
                int ir = 0;
                int ig = 0;
                int ib = 0;
                Xs[0] = 0;
                foreach (int i in Red2)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir)*shag;
                }
                foreach (int i in Red6)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir ) * shag;
                }
                foreach (int i in Red5)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir ) * shag;
                }
                foreach (int i in Red1)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir ) * shag;
                }
                foreach (int i in Red3)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir ) * shag;
                }
                foreach (int i in Red7)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir) * shag;
                }
                foreach (int i in Red8)
                {
                    Xr[ir] = i;
                    ir++;
                    Xs[ir] = (ir) * shag;
                }
                foreach (int i in Red4)
                {
                    Xr[ir] = i;
                    ir++;
                    if(ir < longM)
                    Xs[ir] = (ir ) * shag;
                }

                foreach (int i in Green2)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green6)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green5)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green1)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green3)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green7)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green8)
                {
                    Xg[ig] = i;
                    ig++;
                }
                foreach (int i in Green4)
                {
                    Xg[ig] = i;
                    ig++;
                }

                foreach (int i in Blue2)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue6)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue5)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue1)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue3)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue7)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue8)
                {
                    Xb[ib] = i;
                    ib++;
                }
                foreach (int i in Blue4)
                {
                    Xb[ib] = i;
                    ib++;
                }
                for(int j =0; j < nW-1; j++)
                {
                    Re4[j, XY - R] = Convert.ToInt32(linear(j, Xs, Xr)); 
                    Gree4[j, XY  - R] = Convert.ToInt32(linear(j, Xs, Xg));
                    Blu4[j, XY  - R] = Convert.ToInt32(linear(j, Xs, Xb));
                }
                R--;
            }
            picture4 = new Bitmap(nW, XY - 20);

            int x2, y2;
            
            for (x2 = 0; x2 < nW ; x2++)
            {
                for (y2 = 0; y2 < XY - 21; y2++)
                {
                    picture4.SetPixel(x2, y2, Color.FromArgb(Re4[x2, y2], Gree4[x2, y2], Blu4[x2, y2]));

                }
            }
            pictureBox2.Image = picture4;
            pictureBox2.Height = XY - 20;
            pictureBox2.Width = nW;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hf = pictureBox1.Image.Height;
            Wf = pictureBox1.Image.Width;
            R = Hf / 2;  
            Cfx = Wf / 2; 
            Cfy = Hf / 2;  

            He = (int)R;
            We = Convert.ToInt16(2 * PI * R);

            picture2 = new Bitmap(We, He);
            picture1 = (Bitmap)pictureBox1.Image;

            Counter obj = new Counter();
            obj.Xe = 0;
            obj.Ye = 0;
            obj.R = R;
            obj.Cfx = Cfx;
            obj.Cfy = Cfy;
            obj.He = He;
            obj.We = We;

            buildingArt(obj);
            
        }

        void buildingArt(object obj1)
        {
            Counter obj = (Counter)obj1;
            for (int Xe1 = 0; Xe1 < obj.We; Xe1++)
            {
                for (int Ye1 = 0; Ye1 < obj.He; Ye1++)
                {                   
                        int[] xy;                  
                        xy = findFisheye(Xe1, Ye1, obj.R, obj.Cfx, obj.Cfy, obj.He, obj.We);
                        picture2.SetPixel(obj.We - Xe1 - 1,
                        obj.He - Ye1 - 1,
                        picture1.GetPixel(xy[0], xy[1]));
                    
                }
            }
                 pictureBox2.Image = picture2;
                 pictureBox2.Height = He;
                 pictureBox2.Width = We;
            
        }

        int[] findFisheye(int Xe1, int Ye1, double R1, double Cfx1, double Cfy1, double He1, double We1)
        {
            int[] fisheyePoint = new int[2];
            double theta, r, Xf, Yf; //Polar coordinates

            r = Ye1 / He1 * R1;
            theta = Xe1 / We1 * 2.0 * PI;
            Xf = Cfx1 + r * Math.Sin(theta);
            Yf = Cfy1 + r * Math.Cos(theta);
            fisheyePoint[0] = Convert.ToInt16(Xf);
            fisheyePoint[1] = Convert.ToInt16(Yf);

            return fisheyePoint;
        }

        public class Counter
        {
            public int Xe;
            public int Ye;
            public double R;
            public double Cfx;
            public double Cfy;
            public int He;
            public int We;

        }
    }
}
