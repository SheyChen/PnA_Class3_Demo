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
using Manipulators;

namespace _107327008_HW3
{
    public partial class Form1 : Form
    {
        Pen penRed, penBlue, penGreen, penGray, penMag, penYellow;
        Graphics myGraph;
        Rectangle rectCir = new Rectangle(0, 0, 100, 200);
        Point CenterPoint;
        Matrix3D MatrixAng = new Matrix3D();
        Matrix3D NewAxisVec = new Matrix3D();
        double Xang, Yang, Zang;
        double[] Arm1P, Arm2P;

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
            penMag = new Pen(Color.Magenta, 3);
            penYellow = new Pen(Color.Yellow, 2);
            myGraph = this.panel_Draw.CreateGraphics();
            CenterPoint = new Point(panel_Draw.Location.X + (panel_Draw.Width / 2), panel_Draw.Location.Y + (panel_Draw.Height / 2));
            Axis_X.Visible = Axis_Y.Visible = Axis_Z.Visible = false;                               //關閉坐標軸標示
            textBox_Cx.Text = textBox_Cy.Text = textBox_Cr.Text = "0";
            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";
            MatrixAng.Value[0] = new double[] { 1, 0, 0 };
            MatrixAng.Value[1] = new double[] { 0, 1, 0 };
            MatrixAng.Value[2] = new double[] { 0, 0, 1 };
            textBox_Arm1_X.Text = "0"; textBox_Arm1_Y.Text = "0"; textBox_Arm1_Z.Text = "100";
            textBox_Arm2_X.Text = "0"; textBox_Arm2_Y.Text = "100"; textBox_Arm2_Z.Text = "0";
            textBox_Arm3_X.Text = "100"; textBox_Arm3_Y.Text = "0"; textBox_Arm3_Z.Text = "0";
            Xang = Yang = Zang = 0.0;
            label_XAng.Text = "(X軸已旋轉" + Xang.ToString() + "度)";
            label_YAng.Text = "(Y軸已旋轉" + Yang.ToString() + "度)";
            label_ZAng.Text = "(Z軸已旋轉" + Zang.ToString() + "度)";
        }
        private void Button_PanelInitial_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                         //讓畫布觸發
            drawLine(penBlue, 0, 0, 200, 0);                                        //藍色的X軸
            drawLine(penGreen, 0, 0, 0, 200);                                       //綠色的Y軸
            drawCircle(penRed, 0, 0, 5);                                            //紅色的Z軸
            Axis_X.Visible = Axis_Y.Visible = true;                                 //開啟坐標軸標示
            Axis_X.Location = new Point(CenterPoint.X + 120, CenterPoint.Y - 10);   //給定標示座標
            Axis_Y.Location = new Point(CenterPoint.X, CenterPoint.Y - 120);
            /*-----初始化-----*/
            textBox_Cx.Text = textBox_Cy.Text = textBox_Cr.Text = "0";
            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";
            MatrixAng.Value[0] = new double[] { 1, 0, 0 };
            MatrixAng.Value[1] = new double[] { 0, 1, 0 };
            MatrixAng.Value[2] = new double[] { 0, 0, 1 };
            Xang = Yang = Zang = 0.0;
            label_XAng.Text = "(X軸已旋轉" + Xang.ToString() + "度)";
            label_YAng.Text = "(Y軸已旋轉" + Yang.ToString() + "度)";
            label_ZAng.Text = "(Z軸已旋轉" + Zang.ToString() + "度)";
        }
        private void Button_ChangeViewAngle_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                       //讓畫布觸發
            double deltXAng, deltYAng, deltZAng;
            double Deg2Rad = Math.PI / 180.0;

            Matrix3D AxisVec = new Matrix3D();
            AxisVec.Value[0] = new double[] { 200, 0, 0 };
            AxisVec.Value[1] = new double[] { 0, 200, 0 };
            AxisVec.Value[2] = new double[] { 0, 0, 200 };

            deltXAng = Convert.ToDouble(textBox_XAngle.Text) * Deg2Rad;
            deltYAng = Convert.ToDouble(textBox_YAngle.Text) * Deg2Rad;
            deltZAng = Convert.ToDouble(textBox_ZAngle.Text) * Deg2Rad;
            Matrix3D MatrixAngX = new Matrix3D();                                //宣告X軸的轉換矩陣
            MatrixAngX.Value[0] = new double[] { 1, 0, 0 };
            MatrixAngX.Value[1] = new double[] { 0, Math.Cos(deltXAng), -Math.Sin(deltXAng) };
            MatrixAngX.Value[2] = new double[] { 0, Math.Sin(deltXAng), Math.Cos(deltXAng) };

            Matrix3D MatrixAngY = new Matrix3D();                                //宣告Y軸的轉換矩陣
            MatrixAngY.Value[0] = new double[] { Math.Cos(deltYAng), 0, Math.Sin(deltYAng) };
            MatrixAngY.Value[1] = new double[] { 0, 1, 0 };
            MatrixAngY.Value[2] = new double[] { -Math.Sin(deltYAng), 0, Math.Cos(deltYAng) };

            Matrix3D MatrixAngZ = new Matrix3D();                                 //宣告Z軸的轉換矩陣        
            MatrixAngZ.Value[0] = new double[] { Math.Cos(deltZAng), -Math.Sin(deltZAng), 0 };
            MatrixAngZ.Value[1] = new double[] { Math.Sin(deltZAng), Math.Cos(deltZAng), 0 };
            MatrixAngZ.Value[2] = new double[] { 0, 0, 1 };

            Matrix3D MatrixAng2 = new Matrix3D();
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAngX,MatrixAngY);
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAng2,MatrixAngZ);        //把三個轉換矩陣乘起來
            MatrixAng = Matrix3D.MatrixMult(MatrixAng, MatrixAng2);

            //InvMat = Matrix3D.MatrixMult(InvMat, Matrix3D.InvMatrux(MatrixAng2));
            NewAxisVec = Matrix3D.MatrixMult(MatrixAng, AxisVec);
            drawLine(penBlue, 0, 0, NewAxisVec.Value[0][0], NewAxisVec.Value[1][0]);
            drawLine(penGreen, 0, 0, NewAxisVec.Value[0][1], NewAxisVec.Value[1][1]);
            drawLine(penYellow, 0, 0, NewAxisVec.Value[0][2], NewAxisVec.Value[1][2]);

            Xang = Xang + Convert.ToDouble(textBox_XAngle.Text);
            Yang = Yang + Convert.ToDouble(textBox_YAngle.Text);
            Zang = Zang + Convert.ToDouble(textBox_ZAngle.Text);
            label_XAng.Text = "(X軸已旋轉" + Xang.ToString() + "度)";
            label_YAng.Text = "(Y軸已旋轉" + Yang.ToString() + "度)";
            label_ZAng.Text = "(Z軸已旋轉" + Zang.ToString() + "度)";
            textBox_XAngle.Text = textBox_YAngle.Text = textBox_ZAngle.Text = "0";  //初始化
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
            Point3D Arm_start = new Point3D(0, 0, 0);
            Point3D Arm_end = new Point3D(Convert.ToDouble(textBox_ArmX.Text),
                                            Convert.ToDouble(textBox_ArmY.Text),
                                            Convert.ToDouble(textBox_ArmZ.Text));
            drawArmOnView(MatrixAng, Arm_start, Arm_end);
        }
        private void Button_ArmMove_Click(object sender, EventArgs e)
        {
            panel_draw_Paint(sender, null);                                       //讓畫布觸發
            Button_ChangeViewAngle_Click(sender, null);
            Point3D Arm_start = new Point3D(0, 0, 0);
            textBox_Arm2X.Text = (Convert.ToDouble(textBox_ArmX.Text) + Convert.ToDouble(textBox_MoveArmX.Text)).ToString();
            textBox_Arm2Y.Text = (Convert.ToDouble(textBox_ArmY.Text) + Convert.ToDouble(textBox_MoveArmY.Text)).ToString();
            textBox_Arm2Z.Text = (Convert.ToDouble(textBox_ArmZ.Text) + Convert.ToDouble(textBox_MoveArmZ.Text)).ToString();

            double deltXAng, deltYAng, deltZAng;
            double Deg2Rad = Math.PI / 180.0;
            Vector3D NewArm = new Vector3D();
            NewArm.X = Convert.ToDouble(textBox_Arm2X.Text);
            NewArm.Y = Convert.ToDouble(textBox_Arm2Y.Text);
            NewArm.Z = Convert.ToDouble(textBox_Arm2Z.Text);

            deltXAng = Convert.ToDouble(textBox_MoveArmXang.Text) * Deg2Rad;
            deltYAng = Convert.ToDouble(textBox_MoveArmYang.Text) * Deg2Rad;
            deltZAng = Convert.ToDouble(textBox_MoveArmZang.Text) * Deg2Rad;
            Matrix3D MatrixAngX = new Matrix3D();                                //宣告X軸的轉換矩陣
            MatrixAngX.Value[0] = new double[] { 1, 0, 0 };
            MatrixAngX.Value[1] = new double[] { 0, Math.Cos(deltXAng), -Math.Sin(deltXAng) };
            MatrixAngX.Value[2] = new double[] { 0, Math.Sin(deltXAng), Math.Cos(deltXAng) };

            Matrix3D MatrixAngY = new Matrix3D();                                //宣告Y軸的轉換矩陣
            MatrixAngY.Value[0] = new double[] { Math.Cos(deltYAng), 0, Math.Sin(deltYAng) };
            MatrixAngY.Value[1] = new double[] { 0, 1, 0 };
            MatrixAngY.Value[2] = new double[] { -Math.Sin(deltYAng), 0, Math.Cos(deltYAng) };

            Matrix3D MatrixAngZ = new Matrix3D();                                 //宣告Z軸的轉換矩陣        
            MatrixAngZ.Value[0] = new double[] { Math.Cos(deltZAng), -Math.Sin(deltZAng), 0 };
            MatrixAngZ.Value[1] = new double[] { Math.Sin(deltZAng), Math.Cos(deltZAng), 0 };
            MatrixAngZ.Value[2] = new double[] { 0, 0, 1 };

            Matrix3D MatrixAng2 = new Matrix3D();
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAngX, MatrixAngY);
            MatrixAng2 = Matrix3D.MatrixMult(MatrixAng2, MatrixAngZ);        //把三個轉換矩陣乘起來
            NewArm = Matrix3D.VectorMult(MatrixAng2, NewArm);
            textBox_Arm2X.Text = (Convert.ToInt32(NewArm.X)).ToString();
            textBox_Arm2Y.Text = (Convert.ToInt32(NewArm.Y)).ToString();
            textBox_Arm2Z.Text = (Convert.ToInt32(NewArm.Z)).ToString();
            Point3D Arm_end = new Point3D(NewArm.X, NewArm.Y, NewArm.Z);
            drawArmOnView(MatrixAng, Arm_start, Arm_end);
        }
        private void button_DrawScara_Click(object sender, EventArgs e)
        {
            Scara s_arm = new Scara();
            s_arm.Base_pt = new Point3D(0, 0, 0);
            s_arm.pt1 = new Point3D(Convert.ToDouble(textBox_Arm1_X.Text),
                                    Convert.ToDouble(textBox_Arm1_Y.Text),
                                    Convert.ToDouble(textBox_Arm1_Z.Text));
            s_arm.pt2 = new Point3D(s_arm.pt1.X + Convert.ToDouble(textBox_Arm2_X.Text),
                                    s_arm.pt1.Y + Convert.ToDouble(textBox_Arm2_Y.Text),
                                    s_arm.pt1.Z + Convert.ToDouble(textBox_Arm2_Z.Text));
            s_arm.pt3 = new Point3D(s_arm.pt2.X + Convert.ToDouble(textBox_Arm3_X.Text),
                                    s_arm.pt2.Y + Convert.ToDouble(textBox_Arm3_Y.Text),
                                    s_arm.pt2.Z + Convert.ToDouble(textBox_Arm3_Z.Text));
            s_arm.armb_1 = Coordinate3D.Point3D.Distance(s_arm.Base_pt, s_arm.pt1);
            s_arm.arm1_2 = Coordinate3D.Point3D.Distance(s_arm.pt1, s_arm.pt2);
            s_arm.arm2_3 = Coordinate3D.Point3D.Distance(s_arm.pt2, s_arm.pt3);
            if (Scara.IsScara(s_arm))
            {
                DrawScara_Paint(sender, null, s_arm);
            }
            else
            {
                MessageBox.Show( "Invalid Scara arm parameters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Arm1_X.Text = "0"; textBox_Arm1_Y.Text = "0"; textBox_Arm1_Z.Text = "100";
                textBox_Arm2_X.Text = "0"; textBox_Arm2_Y.Text = "100"; textBox_Arm2_Z.Text = "0";
                textBox_Arm3_X.Text = "100"; textBox_Arm3_Y.Text = "0"; textBox_Arm3_Z.Text = "0";
            }
        }            
        private void Button_YAdd_Click(object sender, EventArgs e)
        {
            textBox_YAngle.Text = (Convert.ToDouble(textBox_YAngle.Text) + 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
        }
        private void Button_YSub_Click(object sender, EventArgs e)
        {
            textBox_YAngle.Text = (Convert.ToDouble(textBox_YAngle.Text) - 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
        }
        private void Button_ZAdd_Click(object sender, EventArgs e)
        {
            textBox_ZAngle.Text = (Convert.ToDouble(textBox_ZAngle.Text) + 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
        }
        private void Button_ZSub_Click(object sender, EventArgs e)
        {
            textBox_ZAngle.Text = (Convert.ToDouble(textBox_ZAngle.Text) - 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
        }
        private void Button_XAdd_Click(object sender, EventArgs e)
        {
            textBox_XAngle.Text = (Convert.ToDouble(textBox_XAngle.Text) + 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
        }
        private void Button_XSub_Click(object sender, EventArgs e)
        {
            textBox_XAngle.Text = (Convert.ToDouble(textBox_XAngle.Text) - 1).ToString();
            Button_ChangeViewAngle_Click(sender, null);
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
        public void drawArmOnView(Matrix3D Matrix, Point3D pt_start, Point3D pt_end)
        {
            int rad = 6;
            double[] arm_start = new double[] { pt_start.X, pt_start.Y, pt_start.Z };
            double[] arm_end = new double[] { pt_end.X, pt_end.Y, pt_end.Z };
            double[] viewVec_start = transView(Matrix, arm_start);
            double[] viewVec_end = transView(Matrix, arm_end);
            drawLine(penMag, viewVec_start[0], viewVec_start[1], viewVec_end[0], viewVec_end[1]);
            drawCircle(penRed, viewVec_end[0], viewVec_end[1], rad);
        }
        private void DrawScara_Paint(object sender, EventArgs e, Scara s_arm)
        {
            panel_draw_Paint(sender, null);
            Button_ChangeViewAngle_Click(sender, null);
            //drawArmOnView(InvMat, s_arm.Base_pt, s_arm.pt1);
        }

    }
}
