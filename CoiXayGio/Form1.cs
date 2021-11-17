using CoiXayGio._2DObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoiXayGio
{
    public partial class xe25 : Form
    {
        public bool click = false;
        public xe25()
        {
            
            InitializeComponent();
            this.timer1.Start();
            PicB_2D.BackColor = Color.Khaki;
            PicB_3D.Visible = false;
            tc_3D.Visible = false;

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            bientoancuc.cxg.PropertyChanged += cxg_PropertyChange;
            bientoancuc.hinhxe.PropertyChanged += hinhxe_PropertyChange;
            bientoancuc.mt.PropertyChanged += mt_Propertychange;

            if (!bientoancuc.hinhxe.flagBoder)
            {

                PicB_2D.BackColor = Color.Khaki;//Màu nền-Ngày
                bientoancuc.cxg.VeCXG(e.Graphics);
                bientoancuc.cxg.tinhtien(bientoancuc.xTinhTien_CXG, 0);
                if (bientoancuc.cxg.flagCxg)
                {
                    bientoancuc.xTinhTien_CXG = 0;
                    bientoancuc.tocdo = 9;
                }
                bientoancuc.mt.color_Mattroi = Color.Gold;
                bientoancuc.mt.color_tiamt = Color.Yellow;
                bientoancuc.mt.tyle_mattroi(1);
                bientoancuc.mt.vetiamattroi(e.Graphics);
                bientoancuc.mt.XoayTia(e.Graphics);
                bientoancuc.mt.veMatTroi(e.Graphics);
                bientoancuc.hinhxe.tomauthanxe(e.Graphics);
                bientoancuc.hinhxe.veXe(e.Graphics);
                bientoancuc.hinhxe.vevatobanhxe(e.Graphics);
                bientoancuc.hinhxe.quaybanhxe(e.Graphics, -15);
                bientoancuc.hinhxe.tinhtien(bientoancuc.tocdo, 0);
                HaiiiiQuayXe(bientoancuc.hinhxe.flagBoder);
            }
            else
            {              
                bientoancuc.cxg.VeCXG(e.Graphics);
                bientoancuc.cxg.tinhtien(bientoancuc.xTinhTien_CXG, 0);
                PicB_2D.BackColor = Color.Indigo;//Màu nền-Đêm
                bientoancuc.mt.color_Mattroi = Color.LavenderBlush;
                bientoancuc.mt.color_tiamt = Color.White;
                bientoancuc.mt.tyle1_mattroi(-1);
                bientoancuc.mt.vetiamattroi(e.Graphics);
                bientoancuc.mt.XoayTia(e.Graphics);
                bientoancuc.mt.veMatTroi(e.Graphics);// vẽ mặt trăng á :v
                bientoancuc.hinhxe.tomauthanxe(e.Graphics);
                bientoancuc.hinhxe.veXe(e.Graphics);
                bientoancuc.hinhxe.vevatobanhxe(e.Graphics);
                bientoancuc.hinhxe.quaybanhxe(e.Graphics, 15);
                bientoancuc.hinhxe.tinhtien(-bientoancuc.tocdo, 0);
                HaiiiiQuayXe(!bientoancuc.hinhxe.flagBoder);
            }
            bientoancuc.may.veMay(e.Graphics);
            bientoancuc.may1.veMay(e.Graphics);
            bientoancuc.may2.veMay(e.Graphics);

            bientoancuc.may.tomau(e.Graphics);
            bientoancuc.may1.tomau(e.Graphics);
            bientoancuc.may2.tomau(e.Graphics);
            if(click)
            {
                timer1.Stop();
            }


        }
        public void HienThongTin_CXG()
        {
            for(int i=0; i< bientoancuc.cxg.dsPoint_CXG_Clone.Length; i++ )
            {
                bientoancuc.cxg.dsPoint_CXG_Clone[i] = bientoancuc.cxg.dsPoint_CXG_Clone[i].toado1();
            }
           this.lb1.Text =bientoancuc.cxg.dsPoint_CXG_Clone[0].ToString();
           this.lb2.Text =bientoancuc.cxg.dsPoint_CXG_Clone[1].ToString();
           this.lb3.Text =bientoancuc.cxg.dsPoint_CXG_Clone[2].ToString();
           this.lb4.Text =bientoancuc.cxg.dsPoint_CXG_Clone[3].ToString();
           this.lb5.Text =bientoancuc.cxg.dsPoint_CXG_Clone[4].ToString();
           this.lb6.Text =bientoancuc.cxg.dsPoint_CXG_Clone[5].ToString();
           this.lb7.Text =bientoancuc.cxg.dsPoint_CXG_Clone[6].ToString();
           this.lb8.Text =bientoancuc.cxg.dsPoint_CXG_Clone[7].ToString();
           this.lb9.Text =bientoancuc.cxg.dsPoint_CXG_Clone[8].ToString();
           this.lb10.Text =bientoancuc.cxg.dsPoint_CXG_Clone[9].ToString();
           this.lb11.Text =bientoancuc.cxg.dsPoint_CXG_Clone[10].ToString();
           this.lb12.Text =bientoancuc.cxg.dsPoint_CXG_Clone[11].ToString();
           this.lb13.Text =bientoancuc.cxg.dsPoint_CXG_Clone[12].ToString();
           this.lb14.Text =bientoancuc.cxg.dsPoint_CXG_Clone[13].ToString();
           this.lb15.Text =bientoancuc.cxg.dsPoint_CXG_Clone[14].ToString();
           this.lb16.Text =bientoancuc.cxg.dsPoint_CXG_Clone[15].ToString();
        }
        public void HienThiThongTin_mt()
        {
            for (int i=0; i < bientoancuc.mt.tia_clone.Length;i++)
            {
                bientoancuc.mt.tia_clone[i] = bientoancuc.mt.tia_clone[i].toado1();
            }
            this.mt_tia1.Text = bientoancuc.mt.tia_clone[0].ToString();
            this.mt_tia2.Text = bientoancuc.mt.tia_clone[1].ToString();
            this.mt_tia3.Text = bientoancuc.mt.tia_clone[2].ToString();
            this.mt_tia4.Text = bientoancuc.mt.tia_clone[3].ToString();
            this.mt_tia5.Text = bientoancuc.mt.tia_clone[4].ToString();
            this.mt_tia6.Text = bientoancuc.mt.tia_clone[5].ToString();
            this.mt_tia7.Text = bientoancuc.mt.tia_clone[6].ToString();
            this.mt_tia8.Text = bientoancuc.mt.tia_clone[7].ToString();
            this.mt_bk.Text = bientoancuc.mt.Mattroi.bkinh.ToString();
            this.mat_tam_td.Text = bientoancuc.mt.tammt.toado1().ToString();

        }
        public void HienThongTin_Xe()
        {
            for (int i = 0; i < bientoancuc.hinhxe.DsDiem_Xe_Clone1.Length; i++)
            {
                bientoancuc.hinhxe.DsDiem_Xe_Clone1[i] = bientoancuc.hinhxe.DsDiem_Xe_Clone1[i].toado1();
            }
            this.xe1.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[0].ToString();
            this.xe2.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[1].ToString();
            this.xe3.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[2].ToString();
            this.xe4.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[3].ToString();

            this.xe5.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[4].ToString();
            this.xe6.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[5].ToString();
            this.xe7.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[6].ToString();
            this.xe8.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[7].ToString();
            this.xe9.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[8].ToString();
            
            this.xe10.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[9].ToString();
            this.xe11.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[10].ToString();
            this.xe12.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[11].ToString();
            
            this.xe13.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[12].ToString();
            this.xe14.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[13].ToString();
            this.xe15.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[14].ToString();
            this.xe16.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[15].ToString();
            this.xe17.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[16].ToString();
            this.xe18.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[17].ToString();
            this.xe19.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[18].ToString();
            this.xe20.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[19].ToString();
            this.xe21.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[20].ToString();
            this.xe22.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[21].ToString();
            this.xe23.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[22].ToString();
            this.xe24.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[23].ToString();
            this.lb.Text = bientoancuc.hinhxe.DsDiem_Xe_Clone1[24].ToString();
        }
        private void hinhxe_PropertyChange(object sender, PropertyChangedEventArgs e)
        {
            bientoancuc.hinhxe.DsDiem_Xe_Clone1 = (Point[])bientoancuc.hinhxe.DsDiem_Xe.Clone();
            HienThongTin_Xe();
        }
        private void mt_Propertychange(object sender, PropertyChangedEventArgs eventArgs)
        {
            bientoancuc.mt.tia_clone = (Point[])bientoancuc.mt.Tia.Clone();
            HienThiThongTin_mt();
        }
        private void cxg_PropertyChange(object sender, PropertyChangedEventArgs e)
        {
            bientoancuc.cxg.dsPoint_CXG_Clone = (Point[])bientoancuc.cxg.DsPoint_CXG.Clone();
            HienThongTin_CXG();
        }


        public void  HaiiiiQuayXe(bool flag)
        {
            if (flag)
            {
                bientoancuc.hinhxe.doixung();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (click)
            {
                click = false;
                timer1.Start();
                timer1.Interval = 90;
                return;
            }
            if (!click) click = true;                  
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.PicB_2D.Refresh();
        }

        private void Xe_DoiXung_Ox_Click(object sender, EventArgs e)
        {
            bientoancuc.hinhxe.doixungOx();
        }

        private void Xe_Doixung_Oy_Click(object sender, EventArgs e)
        {
            bientoancuc.hinhxe.doixungOy();
        }

        private void Xe_Doixung_O_Click(object sender, EventArgs e)
        {
            bientoancuc.hinhxe.doixungO();

        }
        private Bitmap DrawCoordinate(Size size)
        {
            Bitmap bm = new Bitmap(size.Width, size.Height);

            DrawPixelGril(bm, new Pen(Color.Red, 1));

            return bm;
        }
        private void DrawPixelGril(Bitmap bm, Pen pen)
        {
            Graphics g = Graphics.FromImage(bm);
            int i = 0,
               width = ToaDo.kichthuoc/5*2 ,
               height = ToaDo.kichthuoc/5*2;

            if (cb_luoi.Checked)
            {
                // Vẽ toàn bộ đường dọc
                for (; i <= width; i++)
                {
                    if (i == width / 2)
                        continue;
                    g.DrawLine(new Pen(Color.Black), 5 * i, 0, 5 * i, PicB_2D.Height);
                }
                // Vẽ toàn bộ đường ngang
                for (i = 0; i <= height; i++)
                {
                    if (i == height / 2)
                        continue;
                    g.DrawLine(new Pen(Color.Black), 0, 5 * i, PicB_2D.Width, 5 * i);
                }
            }

            // Vẽ 2 đường biên Ox và Oy 
            g.DrawLine(pen, 5 * width / 2, 0, 5 * width / 2, PicB_2D.Height);
            g.DrawLine(pen, 0, 5 * height / 2, PicB_2D.Width, 5 * height / 2);
            g.DrawString("Y", new Font("Time New Roman", 10), Brushes.Red, ToaDo.toado2(new Point(1, 100)));
            g.DrawString("X", new Font("Time New Roman", 10), Brushes.Red, ToaDo.toado2(new Point(100, -1)));
        }

        private void cb_luoi_CheckedChanged(object sender, EventArgs e)
        {
            this.PicB_2D.BackgroundImage = DrawCoordinate(new Size(PicB_2D.Width, PicB_2D.Height));
        }

        private void rb_3D_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_3D.Checked== true)
            {
                PicB_3D.Visible = true;
                PicB_2D.Visible = false;
                //pnl_2D.Visible = false;
                tc_3D.Visible = true;
                bientoancuc.hinhhop = new _3DObject.HinhHopChuNhat(1000,1000, 1000, 10, 10, 10);             
            }
        }
        public void VeLuoi3D(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            // Vẽ trục tọa độ
            pen = new Pen(Color.Black);
            int x = PicB_3D.Width * 2 / 5,//,
               y = PicB_3D.Height / 2; //,

            g.DrawLine(pen, new Point(x, y), new Point(PicB_3D.Width, y));         // trục Ox
            g.DrawLine(pen, new Point(x, y), new Point(x, 0));                          // trục Oy
            g.DrawLine(pen, new Point(x, y), new Point(x - y, y + y));                      // trục Oz
            System.Console.WriteLine((x - y) + " " + (y));

            g.DrawString("Y", new Font("Time New Roman", 10), Brushes.Blue, new Point(450, 55));
            g.DrawString("X", new Font("Time New Roman", 10), Brushes.Blue, new Point(1150, 570));
            g.DrawString("Z", new Font("Time New Roman", 10), Brushes.Blue, new Point(60,950));
        }

        private void PicB_3D_Paint(object sender, PaintEventArgs e)
        {
            VeLuoi3D(e.Graphics);
            if(tc_3D.Name.Equals("tp_HinhHop"))
                 bientoancuc.hinhhop.veHinhHop(e.Graphics);
            if(tc_3D.Name.Equals("tp_HinhTru"))
                 bientoancuc.hinhtru.VeHinhTru(e.Graphics);
        }

        private void btn_veHinhHop_Click(object sender, EventArgs e)
        {
            try { 
            int X = Int16.Parse(txb_X.Text);
            int Y = Int16.Parse(txb_Y.Text);
            int Z = Int16.Parse(txb_Z.Text);

            int CD = Int16.Parse(txb_ChieuDai.Text);
            int CC = Int16.Parse(txb_ChieuCao.Text);
            int CR = Int16.Parse(txb_ChieuRong.Text);
            bientoancuc.hinhhop = new _3DObject.HinhHopChuNhat(X, Y, Z, CD, CR, CC);
            PicB_3D.Refresh();
            bientoancuc.hinhhop.veHinhHop(PicB_3D.CreateGraphics());
      
            lb_DiemA.Text = (bientoancuc.hinhhop.Dinh[0, 0], bientoancuc.hinhhop.Dinh[0, 1], bientoancuc.hinhhop.Dinh[0, 2]).ToString();
            lb_DiemB.Text = (bientoancuc.hinhhop.Dinh[1, 0], bientoancuc.hinhhop.Dinh[1, 1], bientoancuc.hinhhop.Dinh[1, 2]).ToString();
            lb_DiemC.Text = (bientoancuc.hinhhop.Dinh[2, 0], bientoancuc.hinhhop.Dinh[2, 1], bientoancuc.hinhhop.Dinh[2, 2]).ToString();
            lb_DiemD.Text = (bientoancuc.hinhhop.Dinh[3, 0], bientoancuc.hinhhop.Dinh[3, 1], bientoancuc.hinhhop.Dinh[3, 2]).ToString();
            lb_DiemE.Text = (bientoancuc.hinhhop.Dinh[4, 0], bientoancuc.hinhhop.Dinh[4, 1], bientoancuc.hinhhop.Dinh[4, 2]).ToString();
            lb_DiemF.Text = (bientoancuc.hinhhop.Dinh[5, 0], bientoancuc.hinhhop.Dinh[5, 1], bientoancuc.hinhhop.Dinh[5, 2]).ToString();
            lb_DiemG.Text = (bientoancuc.hinhhop.Dinh[6, 0], bientoancuc.hinhhop.Dinh[6, 1], bientoancuc.hinhhop.Dinh[6, 2]).ToString();
            lb_DiemH.Text = (bientoancuc.hinhhop.Dinh[7, 0], bientoancuc.hinhhop.Dinh[7, 1], bientoancuc.hinhhop.Dinh[7, 2]).ToString();
        } catch(Exception)
        {
            MessageBox.Show("Nhập định dạng sai!!");
        }

}

        private void rd_2D_CheckedChanged(object sender, EventArgs e)
        {
            if(rd_2D.Checked)
            {
                
                PicB_3D.Visible = false;
                tc_3D.Visible = false;
                PicB_2D.Visible = true;
                pnl_2D.Visible = true;
            }
        }

        private void btn_VeHinhTru_Click(object sender, EventArgs e)
        {
            try
            {
                int X = Int16.Parse(txb_ht_X.Text);
                int Y = Int16.Parse(txb_ht_Y.Text);
                int Z = Int16.Parse(txb_ht_Z.Text);

                int CD = Int16.Parse(txb_ht_chieudai.Text);
                int BKD = Int16.Parse(txb_ht_bankinhday.Text);
                bientoancuc.hinhtru = new _3DObject.HinhTru(X, Y, Z, CD, BKD);
                PicB_3D.Refresh();
                bientoancuc.hinhtru.VeHinhTru(PicB_3D.CreateGraphics());

                lb_HinhTru_A.Text = (bientoancuc.hinhtru.TamDay[0, 0], bientoancuc.hinhtru.TamDay[0, 1], bientoancuc.hinhtru.TamDay[0, 2]).ToString();
                lb_HinhTru_B.Text = (bientoancuc.hinhtru.TamDay[1, 0], bientoancuc.hinhtru.TamDay[1, 1], bientoancuc.hinhtru.TamDay[1, 2]).ToString();
                lb_HinhTru_C.Text = (bientoancuc.hinhtru.TamDay[2, 0], bientoancuc.hinhtru.TamDay[2, 1], bientoancuc.hinhtru.TamDay[2, 2]).ToString();
                lb_HinhTru_D.Text = (bientoancuc.hinhtru.TamDay[3, 0], bientoancuc.hinhtru.TamDay[3, 1], bientoancuc.hinhtru.TamDay[3, 2]).ToString();
                lb_HinhTru_E.Text = (bientoancuc.hinhtru.TamDay[4, 0], bientoancuc.hinhtru.TamDay[4, 1], bientoancuc.hinhtru.TamDay[4, 2]).ToString();
                lb_HinhTru_F.Text = (bientoancuc.hinhtru.TamDay[5, 0], bientoancuc.hinhtru.TamDay[5, 1], bientoancuc.hinhtru.TamDay[5, 2]).ToString();
            } catch(Exception)
            {
                MessageBox.Show("Nhập định dạng sai!!");
            }
            
        }

        private void tp_Hinhtru_Click(object sender, EventArgs e)
        {

        }
    }
}
