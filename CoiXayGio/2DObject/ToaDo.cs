using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    public static class ToaDo
    {
        public static int kichthuoc = 600;// kich thuoc he toa do 
        static ToaDo()
        {
        }
        public static int round(double tds)
        {
            int tdm;
            double sodu = tds % 5;
            if (sodu != 0)
            {
                if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > 2 * kichthuoc) tdm = 2 * kichthuoc;
            return tdm;
        }
        public static void putpixel(Point p, Graphics g, Color m)
        {
            int pointX = round(p.X),
            pointY = round(p.Y);
            //if (x < 0 || x > 800 || y < 0 || y > 800) return;
            //Pen p = new Pen(m);
            SolidBrush b = new SolidBrush(m);
            //grfx.DrawEllipse(p, x, y, 2, 2);
            //grfx.FillEllipse(b, x, y, 2, 2);
            //grfx.DrawEllipse(p, x - 2, y - 2, 2, 2);
            //grfx.FillEllipse(b, x - 2, y - 2, 2, 2);
            //grfx.DrawEllipse(p, x, y - 2, 2, 2);
            //grfx.FillEllipse(b, x, y - 2, 2, 2);
            //grfx.DrawEllipse(p, x - 2, y, 2, 2);
            //grfx.FillEllipse(b, x - 2, y, 2, 2);
            //putcolor(x, y, m);
            g.FillRectangle(b, p.X - 2, p.Y - 2, 5, 5);
        }
        public static Point toado1(this int x, int y)//lon ra nho
        {
            return (new Point(x / 5 - kichthuoc * 2 / 10, kichthuoc * 2 / 10 - y / 5));//voi x va y deu chia het cho 5
        }
        public static Point toado1(this Point d1)//lon ra nho
        {
            return (new Point(d1.X / 5 - kichthuoc * 2 / 10, kichthuoc * 2 / 10 - d1.Y / 5));//voi x va y deu chia het cho 5
        }

        public static Point toado2(int x, int y)//nho ra lon
        {
            return (new Point(x * 5 + kichthuoc, kichthuoc - 5 * y));
        }
        public static Point toado2(double x, double y)//nho ra lon
        {
            return (new Point(round(x * 5 + kichthuoc), round(kichthuoc - 5 * y)));
        }
        public static Point toado2(this Point p)
        {
            return (new Point(round(p.X * 5 + kichthuoc), round(kichthuoc - 5 * p.Y)));
        }
        //sử dụng công thức Cavalier
        public static Point Chuyen3DThanh2D(float X, float Y, float Z)
        {
            float alpha = (float)Math.PI / 4,
                  phi = (float)Math.PI / 4,
                  L,
                  Xp,
                  Yp;
            L = Z / (float)Math.Tan(alpha);
            //Xp = (float)(X + L * (float)Math.Cos(phi));
            //Yp = (float)(Y + L * (float)Math.Sin(phi));


            Xp = (float)(X - (float)Z * Math.Sqrt(2) / 2);
            Yp = (float)(Y - (float)Z * Math.Sqrt(2) / 2);

            return new Point((int)Xp, (int)Yp);
        }
        /// <summary>
        /// Chuyển tọa độ người dùng về tọa độ máy tính trong 3D
        /// </summary>
        public static Point NguoiDungMayTinh_3D(int X, int Y, int Z)
        {
            Point point = new Point();
            point = Chuyen3DThanh2D(X, Y, Z);
            int width = ToaDo.kichthuoc*2/5,//600
                height = ToaDo.kichthuoc*2/5,
                x = point.X,
                y = point.Y;

            x = x > 0 ? (x + width * 2 / 5) * 5 : (width * 2 / 5 - Math.Abs(x)) * 5;
            y = y > 0 ? (height / 2 - y) * 5 : y = (height / 2 + Math.Abs(y)) * 5;
            return new Point(x, y);
        }
        /// <summary>
        /// Chuyển từ tọa độ máy tính về tọa độ người dùng trong 3D
        /// </summary>
        public static Point MayTinhNguoiDung_3D(Point p)
        {
            p.X = round(p.X);
            p.Y = round(p.Y);
            int width = ToaDo.kichthuoc*2/5,
                height = ToaDo.kichthuoc*2/5,
                x = p.X / 5,
                y = p.Y / 5;

            x = x > width * 2 / 5 ? x - width * 2 / 5 : (width * 2 / 5 - x) * -1;
            y = y > height / 2 ? (height / 2 - y) : height / 2 - y;

            return new Point(x, y);
        }
    }
}
