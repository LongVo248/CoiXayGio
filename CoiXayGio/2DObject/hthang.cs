using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    class hthang
    {
        public Point d1, d2;
        public Color mau;
        public Point d3, d4;
        public int chieurong;
        public hthang()
        {
            d1 = new Point(0, 0);
            d2 = new Point(0, 0);
            d3 = new Point(0, 0);
            d4 = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public hthang(Point dd1, Point dd2, Color m)
        {
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3d4();
            mau = m;
        }
        public hthang(Point dd1, Point dd2, Point dd3, Point dd4, Color m)
        {
            // Point d;
            // if (dd1.Y> dd2.Y) { d = dd1; dd1 = dd2; dd2 = d; }
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3 = new Point(dd3.X, dd3.Y);
            d4 = new Point(dd4.X, dd4.Y);
            mau = m;
        }
        public void d3d4()
        {
            d3 = new Point(d1.X + chieurong, d1.Y);
            d4 = new Point(-d2.X + chieurong + 2 * d1.X, d2.Y);
        }
        public void setpro(Point dd1, Point dd2, Color m)
        {
            d1 = dd1;
            d2 = dd2;
            d3d4();
            mau = m;
        }
        public hthang getpro()
        {
            hthang item = new hthang(d1, d2, mau);
            return item;
        }
        public void veHThang(Graphics g)
        {
            //if (d1.X > d2.X)
            //    chieurong = -chieurong;
            //dthang canh1 = new dthang(d1, new Point(d1.X + chieurong, d1.Y), this.mau);
            //dthang canh2 = new dthang(new Point(d1.X + chieurong, d1.Y), d2, this.mau);
            //dthang canh3 = new dthang(d2, new Point(-d2.X + chieurong + 2 * d1.X, d2.Y), this.mau);
            //dthang canh4 = new dthang(d1, new Point(-d2.X + chieurong + 2 * d1.X, d2.Y), this.mau);
            dthang canh1 = new dthang(d1, d3, mau);
            dthang canh2 = new dthang(d3, d2,mau);
            dthang canh3 = new dthang(d2, d4,mau);
            dthang canh4 = new dthang(d4, d1,mau);
            canh1.vedthang(g);
            canh2.vedthang(g);
            canh3.vedthang(g);
            canh4.vedthang(g);
        }

    }
}
