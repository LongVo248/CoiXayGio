using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CoiXayGio._2DObject;

namespace CoiXayGio._3DObject
{
     public class HinhHopChuNhat
    {
        private int chieudai;
        private int chieurong;
        private int chieucao;
        private int[,] dinh;
        public int Chieudai { get => chieudai; set => chieudai = value; }
        public int Chieurong { get => chieurong; set => chieurong = value; }
        public int Chieucao { get => chieucao; set => chieucao = value; }
        public int[,] Dinh { get => dinh; set => dinh = value; }
        public HinhHopChuNhat(int x, int y, int z, int ChieuDai, int ChieuRong, int ChieuCao)
        {
            this.chieucao = ChieuCao;
            this.chieudai = ChieuDai;
            this.chieurong = ChieuRong;
            int[,] dinh_Temp = { { x, y, z },//A
                                    { x+ChieuDai,y,z },
                            { x+ChieuDai,y,z+ChieuRong },
                            { x,y,z+ChieuRong},

                            { x,y+ChieuCao,z },
                            { x+ChieuDai,y+ChieuCao,z },
                            { x+ChieuDai,y+ChieuCao,z+ ChieuRong},
                            { x,y+ChieuCao,z+ChieuRong} };
            this.dinh = dinh_Temp;
        }
        public void veHinhHop(Graphics g)
        {

            // Vẽ nét đứt
            DrawLine(g, 0, 1, 2);
            DrawLine(g, 3, 0, 2);
            DrawLine(g, 0, 4, 2);
            // Vẽ nét liền
            DrawLine(g, 1, 2);
            DrawLine(g, 2, 3);
            DrawLine(g, 4, 5);
            DrawLine(g, 5, 6);
            DrawLine(g, 6, 7);
            DrawLine(g, 7, 4);
            DrawLine(g, 1, 5);
            DrawLine(g, 2, 6);
            DrawLine(g, 3, 7);

            Point point;
            for (int i = 0; i < 8; i++)
            {
                point =ToaDo.NguoiDungMayTinh_3D(this.Dinh[i, 0], this.Dinh[i, 1], this.Dinh[i, 2]);
                ToaDo.putpixel(point, g, Color.Red);
                char c = (char)(65 + i);
                g.DrawString(c.ToString(), new Font("Verdana", 14), Brushes.Red, point);
            }
        }
        public void DrawLine(Graphics g, int A, int B, int n = 1)
        {
            Point point1 = ToaDo.NguoiDungMayTinh_3D(this.Dinh[A, 0], this.Dinh[A, 1], this.Dinh[A, 2]),
                  point2 = ToaDo.NguoiDungMayTinh_3D(this.Dinh[B, 0], this.Dinh[B, 1], this.Dinh[B, 2]);

            dthang dt = new dthang(point1, point2, Color.Black);
            if (n == 2)
            {
                dt.venetdut(g);
            }
            else
                dt.vedthang(g);

            Point point;
            for (int i = 0; i < 8; i++)
            {
                point = ToaDo.NguoiDungMayTinh_3D(this.Dinh[i, 0], this.Dinh[i, 1], this.Dinh[i, 2]);
                ToaDo.putpixel(point, g, Color.Pink);
                char c = (char)(65 + i);
                g.DrawString(c.ToString(), new Font("Verdana", 14), Brushes.Red, point);
            }
        }


    }
}
