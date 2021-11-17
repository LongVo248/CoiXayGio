using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    public  class DamMay
    {
        private int bk=40;
        private Point[] may;
        htron may1;
        htron may2;
        htron may3;
        hcn may4;
        public Color color_may = Color.White;
        public Point[] May { get => may; set => may = value; }

        public DamMay()
        {
            May = new Point[5];
            May[0] = new Point(100, 60);
            May[1] = new Point(140, 75);
            May[2] = new Point(60, 75);
        }
        public DamMay(Point point,int bk)
        {
            this.bk = bk;
            May = new Point[5];
            May[0] = point;
            May[1] = new Point(point.X+bk, point.Y+bk/2);
            May[2] = new Point(point.X-bk, point.Y+bk/2);
        }
        public void veMay(Graphics g)
        {
            may1 = new htron(bk, May[0], color_may);
            may2 = new htron(bk-15, May[1], color_may);
            may3 = new htron(bk-15, May[2], color_may);
            may4 = new hcn(May[1], new Point(May[2].X, May[2].Y + bk-15), color_may);

            may1.vehtron(g);
            may2.vehtron(g);
            may3.vehtron(g);
            may4.vehcn(g);
        }
        public void tomau(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color_may);
            Point[] curvePoint = { may4.d1, may4.d3, may4.d2, may4.d4, may4.d1 };
            g.FillEllipse(brush, may1.tam.X - may1.bkinh, may1.tam.Y - may1.bkinh, may1.bkinh * 2, may1.bkinh * 2);
            g.FillEllipse(brush, may2.tam.X - may2.bkinh, may2.tam.Y - may2.bkinh, may2.bkinh * 2, may2.bkinh * 2);
            g.FillEllipse(brush, may3.tam.X - may3.bkinh, may3.tam.Y - may3.bkinh, may3.bkinh * 2, may3.bkinh * 2);
            g.FillPolygon(brush, curvePoint);
        }
        public void MayTroi(Graphics graphics, int xDonvi, int yDonvi)
        {
            for(int i= 0; i<may.Length;i++)
            {
                May[i] = May[i].Tinhtien(xDonvi, yDonvi);
            }    
        }

       
    }
}
