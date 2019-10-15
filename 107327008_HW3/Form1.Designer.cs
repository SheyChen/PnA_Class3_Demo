namespace _107327008_HW3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_DrawCircle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Cr = new System.Windows.Forms.TextBox();
            this.textBox_Cy = new System.Windows.Forms.TextBox();
            this.textBox_Cx = new System.Windows.Forms.TextBox();
            this.panel_Draw = new System.Windows.Forms.Panel();
            this.Axis_Z = new System.Windows.Forms.Label();
            this.Axis_Y = new System.Windows.Forms.Label();
            this.Axis_X = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_ChangeViewAngle = new System.Windows.Forms.Button();
            this.textBox_ZAngle = new System.Windows.Forms.TextBox();
            this.textBox_YAngle = new System.Windows.Forms.TextBox();
            this.textBox_XAngle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_PanelInitial = new System.Windows.Forms.Button();
            this.button_Xup = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel_Draw.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_DrawCircle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Cr);
            this.groupBox1.Controls.Add(this.textBox_Cy);
            this.groupBox1.Controls.Add(this.textBox_Cx);
            this.groupBox1.Location = new System.Drawing.Point(907, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "畫圖測試用";
            // 
            // button_DrawCircle
            // 
            this.button_DrawCircle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_DrawCircle.Location = new System.Drawing.Point(36, 105);
            this.button_DrawCircle.Name = "button_DrawCircle";
            this.button_DrawCircle.Size = new System.Drawing.Size(136, 28);
            this.button_DrawCircle.TabIndex = 1;
            this.button_DrawCircle.Text = "繪圖";
            this.button_DrawCircle.UseVisualStyleBackColor = true;
            this.button_DrawCircle.Click += new System.EventHandler(this.Button_DrawCircle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(33, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "圓半徑 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "圓心Y座標 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "圓心X座標 : ";
            // 
            // textBox_Cr
            // 
            this.textBox_Cr.Location = new System.Drawing.Point(103, 77);
            this.textBox_Cr.Name = "textBox_Cr";
            this.textBox_Cr.Size = new System.Drawing.Size(100, 22);
            this.textBox_Cr.TabIndex = 3;
            // 
            // textBox_Cy
            // 
            this.textBox_Cy.Location = new System.Drawing.Point(103, 49);
            this.textBox_Cy.Name = "textBox_Cy";
            this.textBox_Cy.Size = new System.Drawing.Size(100, 22);
            this.textBox_Cy.TabIndex = 2;
            // 
            // textBox_Cx
            // 
            this.textBox_Cx.Location = new System.Drawing.Point(103, 21);
            this.textBox_Cx.Name = "textBox_Cx";
            this.textBox_Cx.Size = new System.Drawing.Size(100, 22);
            this.textBox_Cx.TabIndex = 1;
            // 
            // panel_Draw
            // 
            this.panel_Draw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Draw.Controls.Add(this.Axis_Z);
            this.panel_Draw.Controls.Add(this.Axis_Y);
            this.panel_Draw.Controls.Add(this.Axis_X);
            this.panel_Draw.Location = new System.Drawing.Point(12, 12);
            this.panel_Draw.Name = "panel_Draw";
            this.panel_Draw.Size = new System.Drawing.Size(877, 646);
            this.panel_Draw.TabIndex = 1;
            // 
            // Axis_Z
            // 
            this.Axis_Z.AutoSize = true;
            this.Axis_Z.Location = new System.Drawing.Point(236, 183);
            this.Axis_Z.Name = "Axis_Z";
            this.Axis_Z.Size = new System.Drawing.Size(12, 12);
            this.Axis_Z.TabIndex = 2;
            this.Axis_Z.Text = "Z";
            // 
            // Axis_Y
            // 
            this.Axis_Y.AutoSize = true;
            this.Axis_Y.Location = new System.Drawing.Point(187, 295);
            this.Axis_Y.Name = "Axis_Y";
            this.Axis_Y.Size = new System.Drawing.Size(13, 12);
            this.Axis_Y.TabIndex = 1;
            this.Axis_Y.Text = "Y";
            // 
            // Axis_X
            // 
            this.Axis_X.AutoSize = true;
            this.Axis_X.Location = new System.Drawing.Point(310, 264);
            this.Axis_X.Name = "Axis_X";
            this.Axis_X.Size = new System.Drawing.Size(13, 12);
            this.Axis_X.TabIndex = 0;
            this.Axis_X.Text = "X";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button_Xup);
            this.groupBox2.Controls.Add(this.button_ChangeViewAngle);
            this.groupBox2.Controls.Add(this.textBox_ZAngle);
            this.groupBox2.Controls.Add(this.textBox_YAngle);
            this.groupBox2.Controls.Add(this.textBox_XAngle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(907, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 214);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "旋轉視角";
            // 
            // button_ChangeViewAngle
            // 
            this.button_ChangeViewAngle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_ChangeViewAngle.Location = new System.Drawing.Point(36, 177);
            this.button_ChangeViewAngle.Name = "button_ChangeViewAngle";
            this.button_ChangeViewAngle.Size = new System.Drawing.Size(136, 31);
            this.button_ChangeViewAngle.TabIndex = 6;
            this.button_ChangeViewAngle.Text = "旋轉";
            this.button_ChangeViewAngle.UseVisualStyleBackColor = true;
            this.button_ChangeViewAngle.Click += new System.EventHandler(this.Button_ChangeViewAngle_Click);
            // 
            // textBox_ZAngle
            // 
            this.textBox_ZAngle.Location = new System.Drawing.Point(115, 117);
            this.textBox_ZAngle.Name = "textBox_ZAngle";
            this.textBox_ZAngle.Size = new System.Drawing.Size(88, 22);
            this.textBox_ZAngle.TabIndex = 10;
            // 
            // textBox_YAngle
            // 
            this.textBox_YAngle.Location = new System.Drawing.Point(115, 67);
            this.textBox_YAngle.Name = "textBox_YAngle";
            this.textBox_YAngle.Size = new System.Drawing.Size(88, 22);
            this.textBox_YAngle.TabIndex = 9;
            // 
            // textBox_XAngle
            // 
            this.textBox_XAngle.Location = new System.Drawing.Point(115, 18);
            this.textBox_XAngle.Name = "textBox_XAngle";
            this.textBox_XAngle.Size = new System.Drawing.Size(88, 22);
            this.textBox_XAngle.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(6, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Z軸旋轉角度 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Y軸旋轉角度 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "X軸旋轉角度 : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(907, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 213);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手臂位置";
            // 
            // button_PanelInitial
            // 
            this.button_PanelInitial.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_PanelInitial.Location = new System.Drawing.Point(916, 12);
            this.button_PanelInitial.Name = "button_PanelInitial";
            this.button_PanelInitial.Size = new System.Drawing.Size(194, 33);
            this.button_PanelInitial.TabIndex = 0;
            this.button_PanelInitial.Text = "畫布初始化";
            this.button_PanelInitial.UseVisualStyleBackColor = true;
            this.button_PanelInitial.Click += new System.EventHandler(this.Button_PanelInitial_Click);
            // 
            // button_Xup
            // 
            this.button_Xup.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Xup.Location = new System.Drawing.Point(115, 42);
            this.button_Xup.Name = "button_Xup";
            this.button_Xup.Size = new System.Drawing.Size(43, 19);
            this.button_Xup.TabIndex = 3;
            this.button_Xup.Text = "<";
            this.button_Xup.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(160, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 19);
            this.button2.TabIndex = 11;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 670);
            this.Controls.Add(this.button_PanelInitial);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_Draw);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_Draw.ResumeLayout(false);
            this.panel_Draw.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Cr;
        private System.Windows.Forms.TextBox textBox_Cy;
        private System.Windows.Forms.TextBox textBox_Cx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_DrawCircle;
        private System.Windows.Forms.Panel panel_Draw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_ChangeViewAngle;
        private System.Windows.Forms.TextBox textBox_ZAngle;
        private System.Windows.Forms.TextBox textBox_YAngle;
        private System.Windows.Forms.TextBox textBox_XAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_PanelInitial;
        private System.Windows.Forms.Label Axis_Z;
        private System.Windows.Forms.Label Axis_Y;
        private System.Windows.Forms.Label Axis_X;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_Xup;
    }
}

