using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    class htron
    {


        public int bkinh;
        public Point tam;
        public Color mau;
        public htron()
        {
            bkinh = 0;
            tam = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public htron(int bk, Point tamht, Color m)
        {
            bkinh = bk;
            tam = new Point(tamht.X, tamht.Y);
            mau = m;
        }
        public void setpro(int bk, Point tamht, Color m)
        {
            bkinh = bk;
            tam = tamht;
            mau = m;
        }
        public htron getpro()
        {
            htron item = new htron(bkinh, tam, mau);
            return item;
        }
        public void vehtron(Graphics g)
        {
            //midpoint
            int x = 0;
            int y = this.bkinh;
            int p = 3 - 2 * this.bkinh;
            // int maxX = Math.Sqrt(2) / 2 * R;
            while (x <= y)
            {
                if (p < 0)
                    p = p + 4 * x - 6;
                else
                {
                    y -= 5;
                    p = p + 4 * (x - y) + 10;
                }
                Drawn8Point(x, y, g, this.mau);
                x += 5;
            }
        }
        public void Drawn8Point(int x, int y, Graphics g, Color color)
        {
            ToaDo.putpixel(new Point(x + tam.X, y + tam.Y), g, color);
            ToaDo.putpixel(new Point(y + tam.X, x + tam.Y), g, color);
            ToaDo.putpixel(new Point(-x + tam.X, -y + tam.Y), g, color);
            ToaDo.putpixel(new Point(-y + tam.X, -x + tam.Y), g, color);
            ToaDo.putpixel(new Point(-x + tam.X, y + tam.Y), g, color);
            ToaDo.putpixel(new Point(-y + tam.X, x + tam.Y), g, color);
            ToaDo.putpixel(new Point(x + tam.X, -y + tam.Y), g, color);
            ToaDo.putpixel(new Point(y + tam.X, -x + tam.Y), g, color);
        }
    }
}
