using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CoiXayGio._2DObject;
using CoiXayGio._3DObject;

namespace CoiXayGio
{
    public static class bientoancuc
    {
        public static CXG cxg= new CXG();
        public static Xe hinhxe = new Xe();
        public static MatTroi mt= new MatTroi();
        public static bool flagXe;
        public static int xTinhTien_CXG=-3;
        public static int tocdo = 5;
        public static HinhHopChuNhat hinhhop;
        public static HinhTru hinhtru;
        public static DamMay may=new DamMay();
        public static DamMay may1=new DamMay(new Point(600,150),50);
        public static DamMay may2=new DamMay(new Point(800,100),70);
    }
}
