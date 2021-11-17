using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CoiXayGio._2DObject
{
    public static class PhepBienDoi
    {
        /// <summary>
        /// Applies a clockwise rotation.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2">Original point.</param>
        /// <param name="alpha">Alpha.</param>
        /// <returns></returns>
        public static Point Tinhtien(this ref Point d1, int dx, int dy)
        {
            int x, y;
            x = d1.X; y = d1.Y;
            double[,] matran1;
            double[] mang;
            mang = new double[3];
            matran1 = new double[3, 3];

            //Ma tran cua phep tinh tien diem p theo vecter(dx,dy);
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = dx; matran1[2, 1] = dy; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt2 = nhanMT2(matran1, mang);
            Point kq = new Point(ToaDo.round(pt2.X), ToaDo.round(pt2.Y));
            return kq;
        }
        public static Point nhanMT2(float[,] matran, float[] mang)//
        {
            float[] mangtam;

            mangtam = new float[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        public static Point nhanMT2(int[,] matran, int[] mang)
        {
            int[] mangtam;
            mangtam = new int[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(mangtam[0], mangtam[1]);
            return pt;
        }
        public static  Point nhanMT2(double[,] matran, double[] mang)
        {
            double[] mangtam;
            mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        /// <summary>
        /// Applies a clockwise rotation.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2">Original point.</param>
        /// <param name="alpha">Alpha.</param>
        /// <returns></returns>
        public static Point Quay(this Point d1,Point d2, int gocquay)// Quay 1 diem (x,y)quanh diem(xo,yo)1 goc a;
        {
            Point dd1, dd2;
            dd1 = ToaDo.toado1(d1.X, d1.Y);
            dd2 = ToaDo.toado1(d2.X, d2.Y);
            int x, y, xo, yo;
            x = dd1.X; y = dd1.Y; xo = dd2.X; yo = dd2.Y;
            double[,] matran1;
            double[,] matran2;
            double[,] matran3;
            double[] mang;
            double c, s;
            mang = new double[3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            matran3 = new double[3, 3];
            // ma tran tinh tien (xo,yo)ve goc toa do
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt = nhanMT2(matran1, mang);
            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin((Math.PI * gocquay) / 180);
            c = Math.Cos((Math.PI * gocquay) / 180);
            matran2[0, 0] = c; matran2[0, 1] = s; matran2[0, 2] = 0;
            matran2[1, 0] = -1 * s; matran2[1, 1] = c; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran2, mang);
            // ma tran doi diem ve toa do cu
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran3, mang);
            Point kq = ToaDo.toado2(pt2.X, pt2.Y);
            return kq;
        }
        public static Point tyle(this Point d1, Point d2, float sx, float sy)
        {
            Point dd1, dd2;
            dd1 = ToaDo.toado1(d1.X, d1.Y);
            dd2 = ToaDo.toado1(d2.X, d2.Y);
            int x1, y1, xo, yo;
            x1 = dd1.X; y1 = dd1.Y; xo = dd2.X; yo = dd2.Y;
            float[,] matran1;
            float[,] matran2;
            float[,] matran3;

            float[] mang;
            float[] mangtam = { 0, 0, 0 };
            mangtam = new float[3];
            mang = new float[3];
            matran1 = new float[3, 3];
            matran2 = new float[3, 3];
            matran3 = new float[3, 3];
            //    putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            //    putPixel(xo, yo, xo, yo, 0, 0, 1);// Tam ty le ...
            //Ma tran tinh tien ve tam O ...
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);
            //Ma tran ty le ...
            matran2[0, 0] = sx; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = sy; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
            //Ma tran tinh tien nguoc ve vi tri cu...
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = nhanMT2(matran3, mang);
            Point kq = ToaDo.toado2(pt3.X, pt3.Y);
            return kq;
        }
        public static Point BienDang(double m, int b,  Point diem, int hsbd)
        {// Bien dang diem (x,y)theo phuong duong thang y=mx+b, he so bien dang la shxy
            Point dd = ToaDo.toado1(diem.X, diem.Y);
            int x, y;
            x = dd.X; y = dd.Y;
            double[,] matran0;
            double[,] matran1;
            double[,] matran2;
            double[,] matran3;
            double[,] matran4;
            double[] mang;
            double c, s, _c, _s;
            mang = new double[3];
            matran0 = new double[3, 3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            matran3 = new double[3, 3];
            matran4 = new double[3, 3];
            double gocQuay = -1 * Math.Atan(m);

            matran0[0, 0] = 1; matran0[0, 1] = 0; matran0[0, 2] = 0;
            matran0[1, 0] = 0; matran0[1, 1] = 1; matran0[1, 2] = 0;
            matran0[2, 0] = 0; matran0[2, 1] = -b; matran0[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt0 = nhanMT2(matran0, mang);
            //  putPixel(x, y, x, y, 0, 0, 0);

            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin(gocQuay);
            c = Math.Cos(gocQuay);
            matran1[0, 0] = c; matran1[0, 1] = s; matran1[0, 2] = 0;
            matran1[1, 0] = -1 * s; matran1[1, 1] = c; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = pt0.X; mang[1] = pt0.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);

            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = hsbd; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);

            _s = -s;
            _c = c;
            matran3[0, 0] = _c; matran3[0, 1] = _s; matran3[0, 2] = 0;
            matran3[1, 0] = -1 * _s; matran3[1, 1] = _c; matran3[1, 2] = 0;
            matran3[2, 0] = 0; matran3[2, 1] = 0; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = nhanMT2(matran3, mang);

            matran4[0, 0] = 1; matran4[0, 1] = 0; matran4[0, 2] = 0;
            matran4[1, 0] = 0; matran4[1, 1] = 1; matran4[1, 2] = 0;
            matran4[2, 0] = 0; matran4[2, 1] = b; matran4[2, 2] = 1;
            mang[0] = pt3.X; mang[1] = pt3.Y; mang[2] = 1;
            Point pt4 = nhanMT2(matran4, mang);
            Point kq = ToaDo.toado2(pt4.X, pt4.Y);
            return kq;
        }
        public static Point doixung( this Point d1, Point d2)// ve diem doi xung cua (x1,y1)qua tam doi xung (x2,y2)
        {
            int x1, y1, x2, y2;
            x1 = d1.X; y1 = d1.Y; x2 = d2.X; y2 = d2.Y;
            int[,] matran1;
            int[,] matran2;
            int[] mang;
            int[] mangtam = { 0, 0, 0 };
            mangtam = new int[3];
            mang = new int[3];
            matran1 = new int[3, 3];
            matran2 = new int[3, 3];
            // putpixel(x1, x2, getcolor(x1, y1)); putpixel(pt2.X, pt2.Y, getcolor(x1, y1));
            // putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            // putPixel(x2, y2, x2, y2, 0, 0, 1);// Tam doi xung...
            //Ma tran tinh tien ve tam I rki sau do lay doi xung p' qua tam I
            matran1[0, 0] = -1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = -1; matran1[1, 2] = 0;
            matran1[2, 0] = x2; matran1[2, 1] = y2; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = x2; matran2[2, 1] = y2; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
            Point kq = new Point(ToaDo.round(pt2.X), ToaDo.round(pt2.Y));
            return kq;
        }
        //public static double[] ConvertToMatrix(this Point p)
        //{
        //    return new double[] { p.X, p.Y, 1 };
        //}
        //private static double[,] SetUpForMatrixScale(this double[,] matrix, double x)
        //{
        //    if (matrix.Length == 0 || matrix == null)
        //    {
        //        matrix = new double[3, 3] {
        //           { 1, 0, 0},
        //           { 0, 1, 0},
        //           { 0, 0, 1}
        //        };
        //        return matrix;
        //    }

        //    matrix[0, 0] = x; matrix[0, 1] = 0; matrix[0, 2] = 0;
        //    matrix[1, 0] = 0; matrix[1, 1] = x; matrix[1, 2] = 0;
        //    matrix[2, 0] = 0; matrix[2, 1] = 0; matrix[2, 2] = 1;
        //    return matrix;
        //}
        //public static Point GetNewPointByMulMatixs(double[,] matran, double[] mang)
        //{
        //    //Multiply two matrics: 3x3 and 3x1. Else => result false.
        //    double[] mangtam;
        //    mangtam = new double[3];

        //    int dem = 0;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
        //        dem++;
        //    }

        //    Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
        //    return pt;
        //}
        //public static Point Scale(this Point d1, double x)
        //{
        //    double[] arr = new double[3];
        //    double[,] matrix = new double[3, 3];

        //    arr = d1.ConvertToMatrix();
        //    matrix = matrix.SetUpForMatrixScale(x);
        //    Point p = GetNewPointByMulMatixs(matrix, arr);

        //    return p;
        //}
    }
}
