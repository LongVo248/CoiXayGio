using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace CoiXayGio._2DObject
{
    public class Xe :INotifyPropertyChanged
    {
        private Point[] dsDiem_Xe=new Point[26];
        public Point[] DsDiem_Xe_Clone1= new Point[25];
        private hcn thungxe;
        private htron banht;//bansh xe trc
        private htron banhs;//banh sau
        private htron banhg;//banh giua
        private Color color_thanxe ;
        private Color color_viendauxe;
        private Color color_vienthanxe ;
        private Color color_tamxe;
        private Color color_dauxe ;
        private Color color_banhxe;
        private int bk_banxe;
        public  bool flagBoder;
        public Point[] DsDiem_Xe { get => dsDiem_Xe; set => dsDiem_Xe = value; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Xe()
        {
            flagBoder = false;

            color_thanxe = Color.Navy;
            color_vienthanxe = Color.BlueViolet;
            color_dauxe = Color.Firebrick;
            color_viendauxe = Color.Crimson;
            color_tamxe = Color.Gray;
            color_banhxe = Color.Black;
            bk_banxe = 18;
            banht = new htron();
            banhs = new htron();
            // thung xe
            DsDiem_Xe[0] = new Point(-75, 0);
            DsDiem_Xe[1] = new Point(-75, 20); // thungf xe cao 20
            DsDiem_Xe[2] = new Point(-35, 20);//thungf xe dai 40
            DsDiem_Xe[3] = new Point(-35, 0);

            //Dau xe
            DsDiem_Xe[4] = new Point(-33, 18);// dau xe cao 18
            DsDiem_Xe[5] = new Point(-33, 0);
            DsDiem_Xe[6] = new Point(-20, 0);//dau xe dai 13
            DsDiem_Xe[7] = new Point(-20, 8);
            DsDiem_Xe[8] = new Point(-25, 8);
            DsDiem_Xe[9] = new Point(-29, 15);

            //banh xe-Tam
            DsDiem_Xe[10] = new Point(-67, -1);//banh sau
            DsDiem_Xe[11] = new Point(-56, -1);//banh giua
            DsDiem_Xe[12] = new Point(-27, -1);//banh truoc

            //Tăm xe
            //banh truoc
            DsDiem_Xe[13] = new Point(DsDiem_Xe[10].X + bk_banxe/5, DsDiem_Xe[10].Y); 
            DsDiem_Xe[14] = new Point(DsDiem_Xe[10].X - bk_banxe/5, DsDiem_Xe[10].Y);
            DsDiem_Xe[15] = new Point(DsDiem_Xe[10].X, DsDiem_Xe[10].Y + bk_banxe/5);
            DsDiem_Xe[16] = new Point(DsDiem_Xe[10].X, DsDiem_Xe[10].Y - bk_banxe/5);

            DsDiem_Xe[17] = new Point(DsDiem_Xe[11].X + bk_banxe/5, DsDiem_Xe[11].Y);
            DsDiem_Xe[18] = new Point(DsDiem_Xe[11].X - bk_banxe/5, DsDiem_Xe[11].Y);
            DsDiem_Xe[19] = new Point(DsDiem_Xe[11].X, DsDiem_Xe[11].Y + bk_banxe/5);
            DsDiem_Xe[20] = new Point(DsDiem_Xe[11].X, DsDiem_Xe[11].Y - bk_banxe/5);

            DsDiem_Xe[21] = new Point(DsDiem_Xe[12].X + bk_banxe/5, DsDiem_Xe[12].Y);
            DsDiem_Xe[22] = new Point(DsDiem_Xe[12].X - bk_banxe/5, DsDiem_Xe[12].Y);
            DsDiem_Xe[23] = new Point(DsDiem_Xe[12].X, DsDiem_Xe[12].Y + bk_banxe/5);
            DsDiem_Xe[24] = new Point(DsDiem_Xe[12].X, DsDiem_Xe[12].Y - bk_banxe/5);

            DsDiem_Xe[25] = new Point(-48, 0);// điêm đàu và cuối xe cộng lại chia 2


            for (int i = 0; i < DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i] = DsDiem_Xe[i].toado2();
            }
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(""));
            }

        }
        public void veXe(Graphics g)
        {


            thungxe = new hcn(DsDiem_Xe[0], DsDiem_Xe[2], DsDiem_Xe[1], DsDiem_Xe[3], color_thanxe);

            dthang dauxe1 = new dthang(DsDiem_Xe[4], DsDiem_Xe[5], color_dauxe);
            dthang dauxe2 = new dthang(DsDiem_Xe[5], DsDiem_Xe[6], color_dauxe);
            dthang dauxe3 = new dthang(DsDiem_Xe[6], DsDiem_Xe[7], color_dauxe);
            dthang dauxe4 = new dthang(DsDiem_Xe[7], DsDiem_Xe[8], color_dauxe);
            dthang dauxe5 = new dthang(DsDiem_Xe[8], DsDiem_Xe[9], color_dauxe);
            dthang dauxe6 = new dthang(DsDiem_Xe[9], DsDiem_Xe[4], color_dauxe);

            banhs = new htron(bk_banxe, DsDiem_Xe[10], color_banhxe);
            banhg = new htron(bk_banxe, DsDiem_Xe[11], color_banhxe);
            banht = new htron(bk_banxe, DsDiem_Xe[12], color_banhxe);

            

            thungxe.vehcn(g);
            dauxe1.vedthang(g);
            dauxe2.vedthang(g);
            dauxe3.vedthang(g);
            dauxe4.vedthang(g);
            dauxe5.vedthang(g);
            dauxe6.vedthang(g);

            banhs.vehtron(g);
            banht.vehtron(g);
            banhg.vehtron(g);

         

        }
        public void tomauthanxe(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color_vienthanxe);
            SolidBrush brush1 = new SolidBrush(color_viendauxe);

            Point[] curvePoint1 = { DsDiem_Xe[4], DsDiem_Xe[5], DsDiem_Xe[6], DsDiem_Xe[7], DsDiem_Xe[8], DsDiem_Xe[9], DsDiem_Xe[4] };
            Point[] curvePoint = { DsDiem_Xe[0], DsDiem_Xe[1], DsDiem_Xe[2], DsDiem_Xe[3], DsDiem_Xe[0] };
            g.FillPolygon(brush, curvePoint);
            g.FillPolygon(brush1, curvePoint1);

        }
        public void vevatobanhxe(Graphics g)
        {
            //vì bánh xe phải nèm trên tất cả  nên để ra riêng, nếu ko là bị viền xe đè lên
            SolidBrush brush3 = new SolidBrush(color_banhxe);

            g.FillEllipse(brush3, DsDiem_Xe[10].X - bk_banxe, DsDiem_Xe[10].Y - bk_banxe, bk_banxe * 2, bk_banxe * 2);
            g.FillEllipse(brush3, DsDiem_Xe[11].X - bk_banxe, DsDiem_Xe[10].Y - bk_banxe, bk_banxe * 2, bk_banxe * 2);
            g.FillEllipse(brush3, DsDiem_Xe[12].X - bk_banxe, DsDiem_Xe[10].Y - bk_banxe, bk_banxe * 2, bk_banxe * 2);

            dthang tam1_banht = new dthang(DsDiem_Xe[13], DsDiem_Xe[14], color_tamxe);
            dthang tam2_banht = new dthang(DsDiem_Xe[15], DsDiem_Xe[16], color_tamxe);

            dthang tam1_banhg = new dthang(DsDiem_Xe[17], DsDiem_Xe[18], color_tamxe);
            dthang tam2_banhg = new dthang(DsDiem_Xe[19], DsDiem_Xe[20], color_tamxe);

            dthang tam1_banhs = new dthang(DsDiem_Xe[21], DsDiem_Xe[22], color_tamxe);
            dthang tam2_banhs = new dthang(DsDiem_Xe[23], DsDiem_Xe[24], color_tamxe);

            tam1_banht.vedthang(g);
            tam2_banht.vedthang(g);

            tam1_banhg.vedthang(g);
            tam2_banhg.vedthang(g);

            tam1_banhs.vedthang(g);
            tam2_banhs.vedthang(g);
        }
        public void quaybanhxe(Graphics g, int gocquay)
        {
            DsDiem_Xe[13] = DsDiem_Xe[13].Quay(DsDiem_Xe[10], gocquay);
            DsDiem_Xe[14] = DsDiem_Xe[14].Quay(DsDiem_Xe[10], gocquay);
            DsDiem_Xe[15] = DsDiem_Xe[15].Quay(DsDiem_Xe[10], gocquay);
            DsDiem_Xe[16] = DsDiem_Xe[16].Quay(DsDiem_Xe[10], gocquay);

            DsDiem_Xe[17] = DsDiem_Xe[17].Quay(DsDiem_Xe[11], gocquay);
            DsDiem_Xe[18] = DsDiem_Xe[18].Quay(DsDiem_Xe[11], gocquay);
            DsDiem_Xe[19] = DsDiem_Xe[19].Quay(DsDiem_Xe[11], gocquay);
            DsDiem_Xe[20] = DsDiem_Xe[20].Quay(DsDiem_Xe[11], gocquay);
            
            DsDiem_Xe[21] = DsDiem_Xe[21].Quay(DsDiem_Xe[12], gocquay);
            DsDiem_Xe[22] = DsDiem_Xe[22].Quay(DsDiem_Xe[12], gocquay);
            DsDiem_Xe[23] = DsDiem_Xe[23].Quay(DsDiem_Xe[12], gocquay);
            DsDiem_Xe[24] = DsDiem_Xe[24].Quay(DsDiem_Xe[12], gocquay);
            NotifyPropertyChanged();
        }
        public void  doixung()
        {
            for(int i=0; i<DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i] = DsDiem_Xe[i].doixung(new Point(DsDiem_Xe[25].X, DsDiem_Xe[i].Y));
            }
            NotifyPropertyChanged();
        }
        public void tinhtien(int xDonVi, int yDonVi )
        {
            for (int i = 0; i < DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i] = DsDiem_Xe[i].Tinhtien(xDonVi, yDonVi);
               

                //if (DsDiem_Xe[i].X >= ToaDo.kichthuoc * 2 - 20 || DsDiem_Xe[i].X <= 20)// trừ đi 20 để tránh bị lỗi

            }
            if (((DsDiem_Xe[0].X >= ToaDo.kichthuoc * 2 - 30 || DsDiem_Xe[0].X <= 30) && (DsDiem_Xe[1].X >= ToaDo.kichthuoc * 2 - 30 || DsDiem_Xe[1].X <= 30)) 
                    ||((DsDiem_Xe[6].X >= ToaDo.kichthuoc * 2 - 20 || DsDiem_Xe[6].X <= 20 ) &&(DsDiem_Xe[6].X >= ToaDo.kichthuoc * 2 - 20 || DsDiem_Xe[6].X <= 20)))
            {
                flagBoder = !flagBoder;
                
            }
            NotifyPropertyChanged();
        }
        public void doixungOx()
        {
            for(int i=0; i<DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i]=DsDiem_Xe[i].toado1();
                doiXungOX(ref DsDiem_Xe[i]);
                DsDiem_Xe[i] = DsDiem_Xe[i].toado2();
            }
        }
        public void doixungOy()
        {
            for(int i=0; i<DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i] = DsDiem_Xe[i].toado1();
                doiXungOY(ref DsDiem_Xe[i]);
                DsDiem_Xe[i] = DsDiem_Xe[i].toado2();
            }
        }
        public void doixungO()
        {
            for(int i=0; i<DsDiem_Xe.Length; i++)
            {
                DsDiem_Xe[i] = DsDiem_Xe[i].toado1();
                doiXungQuaGoc(ref DsDiem_Xe[i]);
                DsDiem_Xe[i] = DsDiem_Xe[i].toado2();
            }
        }
        private void doiXungOX(ref Point pn)
        {
            double[] matran1 = new double[3] { pn.X, pn.Y, 1 };
            // khởi tạo ma trận tịnh tiến
            double[,] matran2 = new double[3, 3] { { 1,  0 , 0 },
                                             { 0,  -1 , 0 },
                                             { 0,  0, 1} };

            pn = nhanMT(matran2, matran1);

        }

        private void doiXungOY(ref Point pn)
        {
            double[] matran1 = new double[3] { pn.X, pn.Y, 1 };
            // khởi tạo ma trận tịnh tiến
            double[,] matran2 = new double[3, 3] { { -1,  0 , 0 },
                                             { 0,  1 , 0 },
                                             { 0,  0, 1} };

            pn = nhanMT(matran2, matran1);

        }

        private void doiXungQuaGoc(ref Point pn)
        {
            double[] matran1 = new double[3] { pn.X, pn.Y, 1 };
            // khởi tạo ma trận tịnh tiến
            double[,] matran2 = new double[3, 3] { {- 1,  0 , 0 },
                                             { 0,  -1 , 0 },
                                             { 0,  0, 1} };

            pn = nhanMT(matran2, matran1);

        }
        private Point nhanMT(double[,] matran, double[] mang)
        {
            double[] mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }

    }
}
