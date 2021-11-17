using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace CoiXayGio._2DObject
{
    public class MatTroi : INotifyPropertyChanged
    {
        private htron mattroi;
        private int banKinh = 50;
        public int gocquay = 5;
        public Color color_Mattroi;
        public Color color_tiamt;
        public Point tammt;
        private Point[] tia = new Point[8];
        public Point[] tia_clone = new Point[8];
        internal htron Mattroi { get => mattroi; set => mattroi = value; }
        public int BanKinh { get => banKinh; set => banKinh = value; }
        public Point[] Tia { get => tia; set => tia = value; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MatTroi()
        {
            color_Mattroi = Color.Gold;
            color_tiamt = Color.Yellow;
            tammt = new Point(60, 80);//tam của mặt trời
            tammt = tammt.toado2();

            mattroi = new htron(BanKinh, tammt, color_Mattroi);

            Tia[0] = new Point(tammt.X + banKinh * 2, tammt.Y);
            Tia[1] = new Point(tammt.X, tammt.Y + banKinh * 2);
            Tia[2] = new Point(tammt.X - banKinh * 2, tammt.Y);
            Tia[3] = new Point(tammt.X, tammt.Y - banKinh * 2);

            Tia[4] = new Point(tammt.X + banKinh * 3 / 2, tammt.Y + banKinh * 3 / 2);
            Tia[5] = new Point(tammt.X - banKinh * 3 / 2, tammt.Y + banKinh * 3 / 2);
            Tia[6] = new Point(tammt.X + banKinh * 3 / 2, tammt.Y - banKinh * 3 / 2);
            Tia[7] = new Point(tammt.X - banKinh * 3 / 2, tammt.Y - banKinh * 3 / 2);
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(""));
            }

        }
        public void vetiamattroi(Graphics g)
        {
            dthang tiatemp;
            for (int i = 0; i < 8; i++)
            {
                tiatemp = new dthang(Tia[i], tammt, color_tiamt);
                tiatemp.vedthang(g);
            }

        }
        void tomau(htron ht, Graphics g)
        {
            SolidBrush brush = new SolidBrush(color_Mattroi);
            htron temp = ht;
            g.FillEllipse(brush, temp.tam.X - ht.bkinh, temp.tam.Y - ht.bkinh, ht.bkinh * 2, ht.bkinh * 2);
        }
        public void XoayTia(Graphics g)
        {
            for (int i = 0; i < 8; i++)
            {
                Tia[i] = Tia[i].Quay(tammt, gocquay);
            }
            NotifyPropertyChanged();
        }
        public void veMatTroi(Graphics g)
        {

            tomau(mattroi, g);
            mattroi.vehtron(g);

        }
        public void tyle_mattroi(int bk)
        {

            if(mattroi.bkinh<100)
                 mattroi.bkinh += bk;
            if (mattroi.bkinh == 80)
            {
                tia[0] = tia[0].tyle(tammt, 2, 2);
                tia[1] = tia[1].tyle(tammt, 2, 2);
                tia[2] = tia[2].tyle(tammt, 2, 2);
                tia[3] = tia[3].tyle(tammt, 2, 2);
                tia[4] = tia[4].tyle(tammt, 2, 2);
                tia[5] = tia[5].tyle(tammt, 2, 2);
                tia[6] = tia[6].tyle(tammt, 2, 2);
                tia[7] = tia[7].tyle(tammt, 2, 2);
            }
        }
        public void tyle1_mattroi(int bk)
        {
            if(mattroi.bkinh>50)
                mattroi.bkinh += bk;
            if (mattroi.bkinh == 80)
            {
                tia[0] = tia[0].tyle(tammt, 0.5f, 0.5f);
                tia[1] = tia[1].tyle(tammt, 0.5f, 0.5f);
                tia[2] = tia[2].tyle(tammt, 0.5f, 0.5f);
                tia[3] = tia[3].tyle(tammt, 0.5f, 0.5f);
                tia[4] = tia[4].tyle(tammt, 0.5f, 0.5f);
                tia[5] = tia[5].tyle(tammt, 0.5f, 0.5f);
                tia[6] = tia[6].tyle(tammt, 0.5f, 0.5f);
                tia[7] = tia[7].tyle(tammt, 0.5f, 0.5f);
            }
        }
    }
}
