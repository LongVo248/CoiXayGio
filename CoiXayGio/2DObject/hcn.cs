using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    class hcn
    {
        public Point d1, d2;
        public Color mau;
        public Point d3, d4;
        public hcn()
        {
            d1 = new Point(0, 0);
            d2 = new Point(0, 0);
            d3 = new Point(0, 0);
            d4 = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public hcn(Point dd1, Point dd2, Color m)
        {
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3d4();
            mau = m;
        }
        public hcn(Point dd1, Point dd2, Point dd3, Point dd4, Color m)
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
            d3 = new Point(d2.X, d1.Y);
            d4 = new Point(d1.X, d2.Y);
        }
        public void setpro(Point dd1, Point dd2, Color m)
        {
            d1 = dd1;
            d2 = dd2;
            d3d4();
            mau = m;
        }
        public hcn getpro()
        {
            hcn item = new hcn(d1, d2, mau);
            return item;
        }
        public void vehcn(Graphics g)
        {
            (new dthang(d1, d3, this.mau)).vedthang(g);
            (new dthang(d3, d2, this.mau)).vedthang(g);
            (new dthang(d2, d4, this.mau)).vedthang(g);
            (new dthang(d1, d4, this.mau)).vedthang(g);
        }
        public bool tyle_hcn(int s)
        {
            this.d1 = this.d1.tyle(d1,s,s);
            this.d2 = this.d2.tyle(d2,s,s);
            this.d3 = this.d3.tyle(d3,s,s);
            this.d4 = this.d4.tyle(d4,s,s);
            return true;
        }
    }
}

