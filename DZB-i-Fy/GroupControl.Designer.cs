namespace DZBEditor
{
    partial class GroupControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TerrainTypeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ScaleX = new System.Windows.Forms.NumericUpDown();
            this.ScaleY = new System.Windows.Forms.NumericUpDown();
            this.ScaleZ = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RotX = new System.Windows.Forms.NumericUpDown();
            this.RotY = new System.Windows.Forms.NumericUpDown();
            this.RotZ = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TransX = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.TransY = new System.Windows.Forms.NumericUpDown();
            this.TransZ = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RoomNo = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleZ)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotZ)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransZ)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terrain Type:";
            // 
            // TerrainTypeBox
            // 
            this.TerrainTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TerrainTypeBox.FormattingEnabled = true;
            this.TerrainTypeBox.Items.AddRange(new object[] {
            "Land",
            "Water",
            "Lava"});
            this.TerrainTypeBox.Location = new System.Drawing.Point(79, 13);
            this.TerrainTypeBox.Name = "TerrainTypeBox";
            this.TerrainTypeBox.Size = new System.Drawing.Size(107, 21);
            this.TerrainTypeBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(47, 10);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(120, 20);
            this.NameBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ScaleZ);
            this.groupBox1.Controls.Add(this.ScaleY);
            this.groupBox1.Controls.Add(this.ScaleX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Z:";
            // 
            // ScaleX
            // 
            this.ScaleX.Location = new System.Drawing.Point(30, 18);
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.Size = new System.Drawing.Size(156, 20);
            this.ScaleX.TabIndex = 3;
            // 
            // ScaleY
            // 
            this.ScaleY.Location = new System.Drawing.Point(30, 45);
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.Size = new System.Drawing.Size(156, 20);
            this.ScaleY.TabIndex = 4;
            // 
            // ScaleZ
            // 
            this.ScaleZ.Location = new System.Drawing.Point(30, 73);
            this.ScaleZ.Name = "ScaleZ";
            this.ScaleZ.Size = new System.Drawing.Size(156, 20);
            this.ScaleZ.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RotZ);
            this.groupBox2.Controls.Add(this.RotY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.RotX);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(3, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Z:";
            // 
            // RotX
            // 
            this.RotX.Location = new System.Drawing.Point(30, 16);
            this.RotX.Name = "RotX";
            this.RotX.Size = new System.Drawing.Size(156, 20);
            this.RotX.TabIndex = 3;
            // 
            // RotY
            // 
            this.RotY.Location = new System.Drawing.Point(30, 43);
            this.RotY.Name = "RotY";
            this.RotY.Size = new System.Drawing.Size(156, 20);
            this.RotY.TabIndex = 4;
            // 
            // RotZ
            // 
            this.RotZ.Location = new System.Drawing.Point(30, 71);
            this.RotZ.Name = "RotZ";
            this.RotZ.Size = new System.Drawing.Size(156, 20);
            this.RotZ.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TransZ);
            this.groupBox3.Controls.Add(this.TransX);
            this.groupBox3.Controls.Add(this.TransY);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(3, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Translation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Z:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Y:";
            // 
            // TransX
            // 
            this.TransX.Location = new System.Drawing.Point(30, 17);
            this.TransX.Name = "TransX";
            this.TransX.Size = new System.Drawing.Size(156, 20);
            this.TransX.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "X:";
            // 
            // TransY
            // 
            this.TransY.Location = new System.Drawing.Point(30, 44);
            this.TransY.Name = "TransY";
            this.TransY.Size = new System.Drawing.Size(156, 20);
            this.TransY.TabIndex = 4;
            // 
            // TransZ
            // 
            this.TransZ.Location = new System.Drawing.Point(30, 72);
            this.TransZ.Name = "TransZ";
            this.TransZ.Size = new System.Drawing.Size(156, 20);
            this.TransZ.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RoomNo);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.TerrainTypeBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 363);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 70);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Room No.:";
            // 
            // RoomNo
            // 
            this.RoomNo.Location = new System.Drawing.Point(71, 42);
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.Size = new System.Drawing.Size(115, 20);
            this.RoomNo.TabIndex = 3;
            // 
            // GroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Name = "GroupControl";
            this.Size = new System.Drawing.Size(201, 626);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleZ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotZ)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransZ)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox TerrainTypeBox;
        public System.Windows.Forms.TextBox NameBox;
        public System.Windows.Forms.NumericUpDown ScaleZ;
        public System.Windows.Forms.NumericUpDown ScaleY;
        public System.Windows.Forms.NumericUpDown ScaleX;
        public System.Windows.Forms.NumericUpDown RotZ;
        public System.Windows.Forms.NumericUpDown RotY;
        public System.Windows.Forms.NumericUpDown RotX;
        public System.Windows.Forms.NumericUpDown TransZ;
        public System.Windows.Forms.NumericUpDown TransX;
        public System.Windows.Forms.NumericUpDown TransY;
        public System.Windows.Forms.NumericUpDown RoomNo;
    }
}
