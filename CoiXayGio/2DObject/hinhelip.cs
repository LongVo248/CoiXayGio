using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    class hinhelip
    {
        public Point tam;
        public int a, b;
        public Color mau;
        public hinhelip()
        {
            tam = new Point(0, 0);
            a = b = 0;
            mau = Color.DarkGreen;
        }
        public hinhelip(Point t, int aa, int bb, Color m)
        {
            tam = new Point(t.X, t.Y);
            a = aa; b = bb;
            mau = m;
        }
        public void setpro(Point t, int aa, int bb, Color m)
        {
            tam = t;
            a = aa; b = bb;
            mau = m;
        }
        public hinhelip getpro()
        {
            hinhelip item = new hinhelip(tam, a, b, mau);
            return item;
        }
        private void put4pitxel(int x, int y, Graphics g)
        {
            ToaDo.putpixel(new Point(tam.X + x, tam.Y + y), g, this.mau);
            ToaDo.putpixel(new Point(tam.X - x, tam.Y + y), g, this.mau);
            ToaDo.putpixel(new Point(tam.X - x, tam.Y - y), g, this.mau);
            ToaDo.putpixel(new Point(tam.X + x, tam.Y - y), g, this.mau);

        }
        private void put4pitxel_3D(int x, int y, Graphics g)
        {   
            if (x % 10 != 0)
            {
                ToaDo.putpixel(new Point(tam.X - x, tam.Y - y), g, this.mau);
                ToaDo.putpixel(new Point(tam.X + x, tam.Y - y), g, this.mau);
            }
            ToaDo.putpixel(new Point(tam.X + x, tam.Y + y), g, this.mau);
            ToaDo.putpixel(new Point(tam.X - x, tam.Y + y), g, this.mau);
        }

        public void veelip(Graphics g)
        {

            //code ve elip
            //Elip su dung thuat toan midpoint
            int x, y, cx, cy;
            cx = tam.X; cy = tam.Y;
            x = 0; y =this.b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            put4pitxel(x, y,g);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                if (x % 5 == 0) put4pitxel(x, ToaDo.round(y), g);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                if (x % 5 == 0) put4pitxel(x, ToaDo.round(y),g);
            }

        }
        public void venetdut_elip(Graphics g)
        {
            int x, y, cx, cy, a, b;
            cx = this.tam.X;
            cy = this.tam.Y;
            a = this.a;
            b = this.b;
            x = 0;
            y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            put4pitxel_3D(x, y, g);

            while (Dx <= Dy)
            {
                x += 1;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y -= 1;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                if (x % 5 == 0)
                    put4pitxel_3D(x, ToaDo.round(y), g);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y >= 0)
            {
                y -= 1;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x += 1;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                if (x % 5 == 0)
                    put4pitxel_3D(x, ToaDo.round(y), g);

            }
        }
    }

}
