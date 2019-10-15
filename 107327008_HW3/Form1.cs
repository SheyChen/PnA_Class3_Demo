using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manipulators;
using Coordinate3D;

namespace _107327008_HW3
{
    public partial class Form1 : Form
    {
        Pen penRed, penBlue, penGreen, penGray, penMag;
        Graphics myGraph;
        Rectangle rectCir = new Rectangle(0, 0, 100, 200);
        Point CenterPoint;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            penRed = new Pen(Color.Red, 2);
            penGreen = new Pen(Color.Green, 2);
            penBlue = new Pen(Color.Blue, 2);
            penGray = new Pen(Color.Gray, 1);
            penMag = new Pen(Color.Magenta);
            myGraph = this.panel_Draw.CreateGraphics();
            CenterPoint = new Point(panel_Draw.Location.X + (panel_Draw.Width / 2), panel_Draw.Location.Y + (panel_Draw.Height / 2));
            Axis_X.Visible = Axis_Y.Visible = Axis_Z.Visible = false;                               //關閉坐標軸標示
        }
        private void Button_PanelInitial_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                         //讓畫布觸發
            drawLine(penBlue, 0, 0, 100, 0);                                        //藍色的X軸
            drawLine(penGreen, 0, 0, 0, 100);                                       //綠色的Y軸
            drawCircle(penRed, 0, 0, 5);                                            //紅色的Z軸
            Axis_X.Visible = Axis_Y.Visible = true;                                 //開啟坐標軸標示
            Axis_X.Location = new Point(CenterPoint.X + 120, CenterPoint.Y - 10);   //給定標示座標
            Axis_Y.Location = new Point(CenterPoint.X, CenterPoint.Y - 120);

            textBox_Cx.Text = textBox_Cy.Text = textBox_Cr.Text = "0";
            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";            
        }
        private void Button_ChangeViewAngle_Click(object sender, EventArgs e)
        {
            
            panel_draw_Paint(sender, null);                                         //讓畫布觸發
            double deltXAng, deltYAng, deltZAng;
            double Deg2Rad = Math.PI / 180.0;

            deltXAng = Convert.ToDouble(textBox_XAngle.Text) * Deg2Rad;
            deltYAng = Convert.ToDouble(textBox_YAngle.Text) * Deg2Rad;
            deltZAng = Convert.ToDouble(textBox_ZAngle.Text) * Deg2Rad;


            //宣告X軸的轉換矩陣
            Matrix3D MatrixAngX = new Matrix3D();
            MatrixAngX.Value[0] = new double[] { 1, 0, 0 };
            MatrixAngX.Value[1] = new double[] { 0, Math.Cos(deltXAng), Math.Sin(deltXAng) };
            MatrixAngX.Value[2] = new double[] { 0, -Math.Sin(deltXAng), Math.Cos(deltXAng) };
            //宣告Y軸的轉換矩陣
            Matrix3D MatrixAngY = new Matrix3D();
            MatrixAngY.Value[0] = new double[] { Math.Cos(deltYAng), 0, -Math.Sin(deltYAng) };
            MatrixAngY.Value[1] = new double[] { 0, 1, 0 };
            MatrixAngY.Value[2] = new double[] { Math.Sin(deltYAng), 0, Math.Cos(deltYAng) };
            //宣告Z軸的轉換矩陣
            Matrix3D MatrixAngZ = new Matrix3D();
            MatrixAngZ.Value[0] = new double[] { Math.Cos(deltZAng), Math.Sin(deltZAng), 0 };
            MatrixAngZ.Value[1] = new double[] { -Math.Sin(deltZAng), Math.Cos(deltZAng), 0 };
            MatrixAngZ.Value[2] = new double[] { 0, 0, 1 };

            Matrix3D MatrixAng = new Matrix3D();
            MatrixAng = Matrix3D.MatrixMult(MatrixAngX, MatrixAngY);
            MatrixAng = Matrix3D.MatrixMult(MatrixAng, MatrixAngZ);               //把三個轉換矩陣乘起來

            double[] viewVectorX = transView(MatrixAng.Value, 100, 0, 0);          //轉換X軸
            drawLine(penBlue, 0, 0, viewVectorX[0], viewVectorX[1]);
            double[] viewVectorY = transView(MatrixAng.Value, 0, 100, 0);          //轉換Y軸
            drawLine(penGreen, 0, 0, viewVectorY[0], viewVectorY[1]);
            double[] viewVectorZ = transView(MatrixAng.Value, 0, 0, 100);          //轉換Z軸
            drawLine(penRed, 0, 0, viewVectorZ[0], viewVectorZ[1]);

        }

        private void Button_DrawCircle_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                         //讓畫布觸發
            drawLine(penBlue, 0, 0, 100, 0);                                        //藍色的X軸
            drawLine(penGreen, 0, 0, 0, 100);                                       //綠色的Y軸
            Axis_X.Visible = Axis_Y.Visible = true;                                 //開啟坐標軸標示
            Axis_X.Location = new Point(CenterPoint.X + 120, CenterPoint.Y - 10);   //給定標示座標
            Axis_Y.Location = new Point(CenterPoint.X, CenterPoint.Y - 120);
            try
            {
                double centerX = Convert.ToDouble(textBox_Cx.Text);
                double centerY = Convert.ToDouble(textBox_Cy.Text);
                double rad = Convert.ToDouble(textBox_Cr.Text);
                drawCircle(penRed, centerX, centerY, rad);
                drawLine(penBlue, centerX, centerY, 0, 0);
            }
            catch
            {
                MessageBox.Show("數值輸入錯誤", "Error ! !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        public void drawCircle(Pen penX, double centerX, double centerY, double rad)
        {
            int cx = (int)centerX + CenterPoint.X;
            int cy = CenterPoint.Y - (int)centerY;
            int radInt = (int)rad;
            rectCir.X = cx - radInt;
            rectCir.Y = cy - radInt;
            rectCir.Width = 2 * radInt;
            rectCir.Height = 2 * radInt;
            myGraph.DrawArc(penX, rectCir, 0, 360);
            return;
        }
        public void drawLine(Pen penX, double x1, double y1, double x2, double y2)
        {
            int cx = (int)x1 + CenterPoint.X;
            int cy = CenterPoint.Y - (int)y1;
            int dx = (int)x2 + CenterPoint.X;
            int dy = CenterPoint.Y - (int)y2;
            myGraph.DrawLine(penX, cx, cy, dx, dy);
            return;
        }
        private void panel_draw_Paint(object sender, PaintEventArgs e)
        {
            myGraph.Clear(this.BackColor);
            myGraph.DrawLine(penGray, CenterPoint.X, 0, CenterPoint.X, panel_Draw.Height);
            myGraph.DrawLine(penGray, 0, CenterPoint.Y, panel_Draw.Width, CenterPoint.Y);
        }

        public double[] transView(double[][] matA, double x, double y, double z)
        {
            double[] VectorOut = new double[2];
            double[] VectorNew = new double[3] { 0, 0, 0 };
            double[] Vector = new double[3] { x, y, z };
            for (int i = 0; i < VectorNew.Length; i++)
            {
                for (int j = 0; j < VectorNew.Length; j++)
                {
                    VectorNew[i] += matA[i][j] * Vector[j];
                }
            }
            VectorOut[0] = VectorNew[0];
            VectorOut[1] = VectorNew[1];
            return VectorOut;
        }
    }
}
