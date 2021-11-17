
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    class dthang
    {
        public Point diemdau;
        public Point diemcuoi;
        public Color mau;
        private double hesogoc, b1;
        public int b;
        public dthang()
        {
            diemdau = new Point(0,0);
            diemcuoi = new Point(0, 0);
            mau = Color.DarkBlue;
            hesogoc = 0;
            b1 = b = 0;
        }
        public dthang(Point dd, Point dc, Color m)
        {
            int d1 = dd.X; int r1 = dd.Y; int d2 = dc.X; int r2 = dc.Y;
            diemdau = dd;
            diemcuoi = dc;
            mau = m;
            if (d1 == d2) hesogoc = 0;
            else hesogoc = (r1 - r2) / (d1 - d2);
            b1 = r1 - hesogoc * d1;
            b = Convert.ToInt32(b1);
        }
        public void setpro(Point dd, Point dc, Color m)
        {
            diemdau = dd;
            diemcuoi = dc;
            mau = m;
        }
        public dthang getpro()
        {
            dthang item = new dthang(diemdau, diemcuoi, mau);
            return item;
        }
        public double gethsg()
        { return hesogoc; }
        public int getb()
        { return b; }
        public void vedthang(Graphics g)
        {
            //Này xài thuật toán Breshenhem nha
            int x, y;
            float p;
            float c2 = 0;
            float c = 0;
            
            int x1 = this.diemdau.X;
            int y1 = this.diemdau.Y;
            int x2 = this.diemcuoi.X;
            int y2 = this.diemcuoi.Y;


            float Dx = Math.Abs(x2 - x1);
            float Dy = Math.Abs(y2 - y1);
            c = Dx - Dy;
            c2 = 2 * c;
            x = x1;
            p = 2 * Dy - Dx;
            y = y1;

            int x_unit = 5, y_unit = 5;

            if (x2 - x1 < 0)
                x_unit = -x_unit;
            if (y2 - y1 < 0)
                y_unit = -y_unit;
            ToaDo.putpixel(new Point(x,y),g, this.mau);
            if (x1 == x2)   // duong thang dung
            {
                while (y != y2)
                {
                    y += y_unit;
                    ToaDo.putpixel(new Point(x, y), g, this.mau);
                }
            }

            else if (y1 == y2)  // duong ngang
            {
                while (x != x2)
                {

                    x += x_unit;
                    ToaDo.putpixel(new Point(x, y), g, this.mau);
                }
            }

            else if (x1 != x2 && y1 != y2)  // duong xien
            {
                if ((Math.Abs(y2 - y1)) <= 25)
                {
                    while (x != x2)
                    {
                        if (p < 0) p += 2 * Dy;
                        else
                        {
                            p += 2 * (Dy - Dx);
                            y += y_unit;
                        }
                        x += x_unit;
                        ToaDo.putpixel(new Point(x, y), g, this.mau);
                    }
                }
                else
                {
                    if (x2 >= x1)
                    {
                        // var sign=5;
                        // (y2>y1)? sign=5:sign=-5;
                        while (!(x == x2 + 5 || y == y2))
                        {

                            c2 = 2 * c;
                            if (c2 > -Dy)
                            {
                                c = c - Dy;
                                x = x + x_unit;
                            }
                            if (c2 < Dx)
                            {
                                c = c + Dx;
                                y = y + y_unit;
                            }
                            ToaDo.putpixel(new Point(x, y), g, this.mau);
                        }
                    }
                    if (x2 < x1)
                    {
                        // var sign=5;
                        // (y2>y1)? sign=+5:sign=-5;
                        while (!(x == x2 - 5 || y == y2))
                        {

                            c2 = 2 * c;
                            if (c2 > -Dy)
                            {
                                c = c - Dy;
                                x = x + x_unit;
                            }
                            if (c2 < Dx)
                            {
                                c = c + Dx;
                                y = y + y_unit;
                            }
                            ToaDo.putpixel(new Point(x, y), g, this.mau);
                        }
                    }
                }
            }
        }
        public int netdut(Point p, Graphics g,Color c, int length)
        {
            if( length%7>=0 && length%7 < 5)
            {
                ToaDo.putpixel(p, g, this.mau);
            }
            length++;
            return length;
        }
        public void venetdut(Graphics g)
        {
            //Này xài thuật toán Breshenhem nha
            int x, y;
            float p;
            float c2 = 0;
            float c = 0;
            int length = 0;

            int x1 = this.diemdau.X;
            int y1 = this.diemdau.Y;
            int x2 = this.diemcuoi.X;
            int y2 = this.diemcuoi.Y;


            float Dx = Math.Abs(x2 - x1);
            float Dy = Math.Abs(y2 - y1);
            c = Dx - Dy;
            c2 = 2 * c;
            x = x1;
            p = 2 * Dy - Dx;
            y = y1;

            int x_unit = 5, y_unit = 5;

            if (x2 - x1 < 0)
                x_unit = -x_unit;
            if (y2 - y1 < 0)
                y_unit = -y_unit;
            ToaDo.putpixel(new Point(x, y), g, this.mau);
            if (x1 == x2)   // duong thang dung
            {
                while (y != y2)
                {
                    y += y_unit;
                    length=netdut(new Point(x, y), g, this.mau, length);
                }
            }

            else if (y1 == y2)  // duong ngang
            {
                while (x != x2)
                {

                    x += x_unit;
                    length = netdut(new Point(x, y), g, this.mau, length);
                }
            }

            else if (x1 != x2 && y1 != y2)  // duong xien
            {
                if ((Math.Abs(y2 - y1)) <= 25)
                {
                    while (x != x2)
                    {
                        if (p < 0) p += 2 * Dy;
                        else
                        {
                            p += 2 * (Dy - Dx);
                            y += y_unit;
                        }
                        x += x_unit;
                        length = netdut(new Point(x, y), g, this.mau, length);
                    }
                }
                else
                {
                    if (x2 >= x1)
                    {
                        // var sign=5;
                        // (y2>y1)? sign=5:sign=-5;
                        while (!(x == x2 + 5 || y == y2))
                        {

                            c2 = 2 * c;
                            if (c2 > -Dy)
                            {
                                c = c - Dy;
                                x = x + x_unit;
                            }
                            if (c2 < Dx)
                            {
                                c = c + Dx;
                                y = y + y_unit;
                            }
                            length = netdut(new Point(x, y), g, this.mau, length);
                        }
                    }
                    if (x2 < x1)
                    {
                        // var sign=5;
                        // (y2>y1)? sign=+5:sign=-5;
                        while (!(x == x2 - 5 || y == y2))
                        {

                            c2 = 2 * c;
                            if (c2 > -Dy)
                            {
                                c = c - Dy;
                                x = x + x_unit;
                            }
                            if (c2 < Dx)
                            {
                                c = c + Dx;
                                y = y + y_unit;
                            }
                            length = netdut(new Point(x, y), g, this.mau, length);
                        }
                    }
                }
            }
        }


    }
}
