using System;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;
using System.IO;
using System.Windows.Media;
using Image = System.Windows.Controls.Image;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;


namespace WpfApp1.window
{

    public partial class Page3 : Page
    {
        public Color _brushBackground;
        public Page3()
        {
            InitializeComponent();
            DrawPoint();
        }


        private void DrawPoint()
        {
            int width = 400;
            int height = 450;
            displayImage.Width = width;
            displayImage.Height = height;
            _brushBackground = Color.Black;
            WriteableBitmap writeableBitmap = new WriteableBitmap(width, height, 72, 72, PixelFormats.Bgr32, null);
            writeableBitmap.Lock();
            Bitmap backBitmap = new Bitmap(width, height, writeableBitmap.BackBufferStride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, writeableBitmap.BackBuffer);

            Graphics graphics = Graphics.FromImage(backBitmap);
            graphics.Clear(_brushBackground);//整张画布置为黑色
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.FillEllipse(Brushes.White, 100, 80, 1, 1);
            graphics.FillEllipse(Brushes.White, 100, 90, 2, 2);
            graphics.FillEllipse(Brushes.White, 100, 100, 3,3);
            graphics.FillEllipse(Brushes.White, 100, 115, 4, 4);
            graphics.FillEllipse(Brushes.White, 100, 130, 6, 6);
            graphics.FillEllipse(Brushes.White, 100, 150, 7, 7);
            graphics.FillEllipse(Brushes.White, 100, 180, 8, 8);
            graphics.FillEllipse(Brushes.White, 100, 200, 10, 10);
            graphics.FillEllipse(Brushes.White, 100, 240, 12, 12);
            graphics.FillEllipse(Brushes.White, 100, 280, 16, 16);
            graphics.FillEllipse(Brushes.White, 100, 310, 18, 18);
            graphics.FillEllipse(Brushes.White, 100, 340, 20, 20);
            //graphics.FillEllipse(Brushes.White, 96, 166, 26, 26);
            //graphics.FillEllipse(Brushes.White, 166, 100, 30, 30);
            //graphics.FillEllipse(Brushes.White, 266, 100, 36, 36);



            // 显示图像

            graphics.Flush();
            graphics.Dispose();
            backBitmap.Dispose();
            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
            displayImage.Source = writeableBitmap;

        }
    }
}
