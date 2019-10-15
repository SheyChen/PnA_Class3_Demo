﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coordinate3D;

namespace _107327008_HW3
{
    public partial class Form1 : Form
    {
        Pen penRed, penBlue, penGreen, penGray, penMag, penYellow;
        Graphics myGraph;
        Rectangle rectCir = new Rectangle(0, 0, 100, 200);
        Point CenterPoint;
        AxisVector axisVector = new AxisVector();
        Matrix3D MatrixAng = new Matrix3D();
        double[] Arm1P, Arm2P;

        public class AxisVector
        {
            public double[] Xvector;
            public double[] Yvector;
            public double[] Zvector;

            public AxisVector()
            {
                Xvector = new double[] { 100, 0, 0 };
                Yvector = new double[] { 0, 100, 0 };
                Zvector = new double[] { 0, 0, 100 };
            }

        }   //存放坐標軸的Class
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
            penYellow = new Pen(Color.Yellow, 2);
            myGraph = this.panel_Draw.CreateGraphics();
            CenterPoint = new Point(panel_Draw.Location.X + (panel_Draw.Width / 2), panel_Draw.Location.Y + (panel_Draw.Height / 2));
            Axis_X.Visible = Axis_Y.Visible = Axis_Z.Visible = false;                               //關閉坐標軸標示
            textBox_Cx.Text = textBox_Cy.Text = textBox_Cr.Text = "0";
            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";
            MatrixAng.Value[0] = new double[] { 1, 0, 0 };
            MatrixAng.Value[1] = new double[] { 0, 1, 0 };
            MatrixAng.Value[2] = new double[] { 0, 0, 1 };
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

            axisVector = new AxisVector();
            MatrixAng.Value[0] = new double[] { 1, 0, 0 };
            MatrixAng.Value[1] = new double[] { 0, 1, 0 };
            MatrixAng.Value[2] = new double[] { 0, 0, 1 };
        }
        private void Button_ChangeViewAngle_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                       //讓畫布觸發
            double deltXAng, deltYAng, deltZAng;
            double Deg2Rad = Math.PI / 180.0;

            deltXAng = Convert.ToDouble(textBox_XAngle.Text) * Deg2Rad;
            deltYAng = Convert.ToDouble(textBox_YAngle.Text) * Deg2Rad;
            deltZAng = Convert.ToDouble(textBox_ZAngle.Text) * Deg2Rad;
            Matrix3D MatrixAngX = new Matrix3D();                                //宣告X軸的轉換矩陣
            MatrixAngX.Value[0] = new double[] { 1, 0, 0 };
            MatrixAngX.Value[1] = new double[] { 0, Math.Cos(deltXAng), Math.Sin(deltXAng) };
            MatrixAngX.Value[2] = new double[] { 0, -Math.Sin(deltXAng), Math.Cos(deltXAng) };

            Matrix3D MatrixAngY = new Matrix3D();                                //宣告Y軸的轉換矩陣
            MatrixAngY.Value[0] = new double[] { Math.Cos(deltYAng), 0, -Math.Sin(deltYAng) };
            MatrixAngY.Value[1] = new double[] { 0, 1, 0 };
            MatrixAngY.Value[2] = new double[] { Math.Sin(deltYAng), 0, Math.Cos(deltYAng) };

            Matrix3D MatrixAngZ = new Matrix3D();                                 //宣告Z軸的轉換矩陣        
            MatrixAngZ.Value[0] = new double[] { Math.Cos(deltZAng), Math.Sin(deltZAng), 0 };
            MatrixAngZ.Value[1] = new double[] { -Math.Sin(deltZAng), Math.Cos(deltZAng), 0 };
            MatrixAngZ.Value[2] = new double[] { 0, 0, 1 };

            Matrix3D MatrixAng2 = new Matrix3D();
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAngY,MatrixAngZ);
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAngX,MatrixAng2);        //把三個轉換矩陣乘起來
            MatrixAng = Matrix3D.MatrixMult(MatrixAng, MatrixAng2);
            axisVector.Xvector = transView(MatrixAng2, axisVector.Xvector);    //轉換X軸
            drawLine(penBlue, 0, 0, axisVector.Xvector[0], axisVector.Xvector[1]);
            axisVector.Yvector = transView(MatrixAng2, axisVector.Yvector);    //轉換Y軸
            drawLine(penGreen, 0, 0, axisVector.Yvector[0], axisVector.Yvector[1]);
            axisVector.Zvector = transView(MatrixAng2, axisVector.Zvector);    //轉換Z軸
            drawLine(penYellow, 0, 0, axisVector.Zvector[0], axisVector.Zvector[1]);

            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";
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
        private void Button_DrawArm_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                       //讓畫布觸發
            Button_ChangeViewAngle_Click(sender, null);
            Point3D Arm1 = new Point3D();
            Arm1.X = Convert.ToDouble(textBox_ArmX.Text);
            Arm1.Y = Convert.ToDouble(textBox_ArmY.Text);
            Arm1.Z = Convert.ToDouble(textBox_ArmZ.Text);
            Arm1P = drawArmOnView(MatrixAng,Arm1);
        }

        private void Button_DrawArm2_Click(object sender, EventArgs e)
        {
            Point3D Arm2 = new Point3D();
            Arm2.X = Convert.ToDouble(textBox_Arm2X.Text);
            Arm2.Y = Convert.ToDouble(textBox_Arm2Y.Text);
            Arm2.Z = Convert.ToDouble(textBox_Arm2Z.Text);
            Arm2P =  drawArmOnView(MatrixAng, Arm2);
            drawLine(penMag,Arm1P[0], Arm1P[1], Arm2P[0], Arm2P[1]);
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
        /*private double[][] MatrixMult(double[][] matrix1, double[][] matrix2)
        {
            int m = matrix1.Length, n = matrix2.Length, p = matrix2[0].Length;
            double[][] result = new double[m][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[p];
            }            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        result[i][j] += (matrix1[i][k] * matrix2[k][j]);
                    }
                }
            }
            return result;
        }  */
        public double[] transView(Matrix3D matA, double[] vectA)
        {
            double[] VectorOut = new double[3];
            double[] VectorNew = new double[3] { 0, 0, 0 };
            for (int i = 0; i < VectorNew.Length; i++)
            {
                for (int j = 0; j < VectorNew.Length; j++)
                {
                    VectorNew[i] += matA.Value[i][j] * vectA[j];
                }
            }
            return VectorNew;
        }
        public double[] drawArmOnView(Matrix3D matA, Point3D ArmP)
        {
            int rad = 6;
            double[] Armvec = new double[] { ArmP.X, ArmP.Y, ArmP.Z };
            double[] viewVec1 = transView(matA, Armvec);
            
            drawLine(penBlue, 0, 0, viewVec1[0], viewVec1[1]);
            drawCircle(penRed, viewVec1[0], viewVec1[1], rad);
            return viewVec1;
        }
    }
}
