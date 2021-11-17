using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CoiXayGio._2DObject
{
    public class CXG: INotifyPropertyChanged
    {
        public int goc = 15;// góc mỗi lần quay cánh quạt->tương ứng với tốc độ của chính cánh quạt, góc càng lớn, càng thấy xoay nhanh
        public Color color_than = Color.SaddleBrown;
        public Color color_vienthan = Color.SaddleBrown;
        public Color color_canh = Color.Teal;
        public Color color_viencanh = Color.Green;
        public Point[] dsPoint = new Point[25];
        public Point[] dsPoint_CXG_Clone = new Point[25];
        private static hcn canh1 = new hcn();
        private static hcn canh2 = new hcn();
        private static hcn canh3 = new hcn();
        private static hcn canh4 = new hcn();
        public bool flagCxg;
        public Point[] DsPoint_CXG
        {
            get => dsPoint;
            set
            {
                dsPoint = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CXG()
        {
            flagCxg = false;
            //Than quat
           
            DsPoint_CXG[0] = new Point(5, 30);
            DsPoint_CXG[1] = new Point(20, 0);
            DsPoint_CXG[2] = new Point(15, 30);
            DsPoint_CXG[3] = new Point(0, 0);

            //canh quat
            DsPoint_CXG[5] = new Point(30, 38);
            DsPoint_CXG[6] = new Point(2, 50);
            DsPoint_CXG[7] = new Point(-10, 22);
            DsPoint_CXG[8] = new Point(18, 10);
            // Diem trung tam 4 canh quat(10,30)
            DsPoint_CXG[4] = new Point(10, 30);

            for (int i = 0; i < DsPoint_CXG.Length; i++)
            {
                DsPoint_CXG[i] = ToaDo.toado2(DsPoint_CXG[i]);
            }

            canh1 = new hcn(DsPoint_CXG[5], DsPoint_CXG[4], color_viencanh);// Điểm gốc là ko thay đổi
            canh2 = new hcn(DsPoint_CXG[6], DsPoint_CXG[4], color_viencanh);// điểm gốc là trung tâm của 4 cánh quạt
            canh3 = new hcn(DsPoint_CXG[7], DsPoint_CXG[4], color_viencanh);
            canh4 = new hcn(DsPoint_CXG[8], DsPoint_CXG[4], color_viencanh);

            //lấy các điểm d3 d4 vào mảng để quản lí
            DsPoint_CXG[9] = canh1.d3;
            DsPoint_CXG[10] = canh1.d4;

            DsPoint_CXG[11] = canh2.d3;
            dsPoint[12] = canh2.d4;

            DsPoint_CXG[13] = canh3.d3;
            DsPoint_CXG[14] = canh3.d4;

            DsPoint_CXG[15] = canh4.d3;
            DsPoint_CXG[16] = canh4.d4;

            NotifyPropertyChanged();
        }
        public void VeCXG(Graphics g)
        {
            // xoay cái rồi mới vẽ
            canh1 = new hcn(DsPoint_CXG[5], DsPoint_CXG[4], DsPoint_CXG[9], DsPoint_CXG[10], color_viencanh);
            canh2 = new hcn(DsPoint_CXG[6], DsPoint_CXG[4], DsPoint_CXG[11], DsPoint_CXG[12], color_viencanh);
            canh3 = new hcn(DsPoint_CXG[7], DsPoint_CXG[4], DsPoint_CXG[13], DsPoint_CXG[14], color_viencanh);
            canh4 = new hcn(DsPoint_CXG[8], DsPoint_CXG[4], DsPoint_CXG[15], DsPoint_CXG[16], color_viencanh);

            xoayCacCanh(ref canh1, ref canh2, ref canh3, ref canh4);
            //Vẽ thân nè
            hthang than = new hthang(DsPoint_CXG[0], DsPoint_CXG[1], DsPoint_CXG[2], DsPoint_CXG[3], color_vienthan);
            than.veHThang(g);

            //Vẽ cánh nè
            // to mau roi moi ve, để viền đè lên nền mới tô
            ToMau(g);
            canh1.vehcn(g);
            canh2.vehcn(g);
            canh3.vehcn(g);
            canh4.vehcn(g);

        }
        private void xoayCacCanh(ref hcn canh1, ref hcn canh2, ref hcn canh3, ref hcn canh4)
        {

            //xoay 4 diem cua cac hcn
            canh1 = new hcn(canh1.d1.Quay(DsPoint_CXG[4], goc), DsPoint_CXG[4], canh1.d3.Quay(DsPoint_CXG[4], goc), canh1.d4.Quay(DsPoint_CXG[4], goc), color_viencanh);
            canh2 = new hcn(canh2.d1.Quay(DsPoint_CXG[4], goc), DsPoint_CXG[4], canh2.d3.Quay(DsPoint_CXG[4], goc), canh2.d4.Quay(DsPoint_CXG[4], goc), color_viencanh);
            canh3 = new hcn(canh3.d1.Quay(DsPoint_CXG[4], goc), DsPoint_CXG[4], canh3.d3.Quay(DsPoint_CXG[4], goc), canh3.d4.Quay(DsPoint_CXG[4], goc), color_viencanh);
            canh4 = new hcn(canh4.d1.Quay(DsPoint_CXG[4], goc), DsPoint_CXG[4], canh4.d3.Quay(DsPoint_CXG[4], goc), canh4.d4.Quay(DsPoint_CXG[4], goc), color_viencanh);

            DsPoint_CXG[5] = DsPoint_CXG[5].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[9] = DsPoint_CXG[9].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[10] = DsPoint_CXG[10].Quay(DsPoint_CXG[4], goc);

            DsPoint_CXG[6] = DsPoint_CXG[6].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[11] = DsPoint_CXG[11].Quay(DsPoint_CXG[4], goc);
            dsPoint[12] = DsPoint_CXG[12].Quay(DsPoint_CXG[4], goc);

            DsPoint_CXG[7] = DsPoint_CXG[7].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[13] = DsPoint_CXG[13].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[14] = DsPoint_CXG[14].Quay(DsPoint_CXG[4], goc);

            DsPoint_CXG[8] = DsPoint_CXG[8].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[15] = DsPoint_CXG[15].Quay(DsPoint_CXG[4], goc);
            DsPoint_CXG[16] = DsPoint_CXG[16].Quay(DsPoint_CXG[4], goc);

            //canh1 = new hcn(DsPoint[5], DsPoint[4], DsPoint[9], DsPoint[10], color_viencanh);
            //canh2 = new hcn(DsPoint[6], DsPoint[4], DsPoint[11], DsPoint[12], color_viencanh);
            //canh3 = new hcn(DsPoint[7], DsPoint[4], DsPoint[13], DsPoint[14], color_viencanh);
            //canh4 = new hcn(DsPoint[8], DsPoint[4], DsPoint[15], DsPoint[16], color_viencanh);
            NotifyPropertyChanged();
        }
        public void ToMau(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color_than);
            SolidBrush brush1 = new SolidBrush(color_canh);
            Point[] curvePoints = { DsPoint_CXG[0], DsPoint_CXG[2], DsPoint_CXG[1], DsPoint_CXG[3], DsPoint_CXG[0] };

            Point[] curvePoints1 = { canh1.d1, canh1.d3, canh1.d2, canh1.d4, canh1.d1 };
            Point[] curvePoints2 = { canh2.d1, canh2.d3, canh2.d2, canh2.d4, canh2.d1 };
            Point[] curvePoints3 = { canh3.d1, canh3.d3, canh3.d2, canh3.d4, canh3.d1 };
            Point[] curvePoints4 = { canh4.d1, canh4.d3, canh4.d2, canh4.d4, canh4.d1 };

            g.FillPolygon(brush, curvePoints);

            g.FillPolygon(brush1, curvePoints1);
            g.FillPolygon(brush1, curvePoints2);
            g.FillPolygon(brush1, curvePoints3);
            g.FillPolygon(brush1, curvePoints4);

        }
        public void tinhtien(int xDonVi, int yDonVi)
        {
            for (int i = 0; i < DsPoint_CXG.Length; i++)
            {
                DsPoint_CXG[i] = DsPoint_CXG[i].Tinhtien(xDonVi, yDonVi);
                if (DsPoint_CXG[i].X >= ToaDo.kichthuoc * 2 || DsPoint_CXG[i].X <= 100)
                {
                    flagCxg = !flagCxg;
                }
            }
           
            NotifyPropertyChanged();
        }
    }
}
