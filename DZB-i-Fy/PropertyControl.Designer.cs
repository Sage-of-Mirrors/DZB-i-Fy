namespace DZBEditor
{
    partial class PropertyControl
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
            this.PolyColorNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ExitIDNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SoundIDNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CamIDNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GroundIDNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.AttribIDNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.SpecialIDNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.WallIDNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.LinkNoNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RoomPathPntNoNum = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.RoomPathIDNum = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.RoomCamIDNum = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.CamMoveBGNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CamBehvNum = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.CopyPropButton = new System.Windows.Forms.Button();
            this.PastePropButton = new System.Windows.Forms.Button();
            this.InheritBox = new System.Windows.Forms.CheckBox();
            this.AllInheritToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PolyColorNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroundIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttribIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkNoNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPathPntNoNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPathIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomCamIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamMoveBGNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamBehvNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PolyColor:";
            // 
            // PolyColorNum
            // 
            this.PolyColorNum.Location = new System.Drawing.Point(66, 14);
            this.PolyColorNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.PolyColorNum.Name = "PolyColorNum";
            this.PolyColorNum.Size = new System.Drawing.Size(123, 20);
            this.PolyColorNum.TabIndex = 1;
            this.PolyColorNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Exit ID:";
            // 
            // ExitIDNum
            // 
            this.ExitIDNum.Location = new System.Drawing.Point(50, 41);
            this.ExitIDNum.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.ExitIDNum.Name = "ExitIDNum";
            this.ExitIDNum.Size = new System.Drawing.Size(139, 20);
            this.ExitIDNum.TabIndex = 3;
            this.ExitIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sound ID:";
            // 
            // SoundIDNum
            // 
            this.SoundIDNum.Location = new System.Drawing.Point(66, 67);
            this.SoundIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SoundIDNum.Name = "SoundIDNum";
            this.SoundIDNum.Size = new System.Drawing.Size(123, 20);
            this.SoundIDNum.TabIndex = 5;
            this.SoundIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cam ID:";
            // 
            // CamIDNum
            // 
            this.CamIDNum.Location = new System.Drawing.Point(57, 93);
            this.CamIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CamIDNum.Name = "CamIDNum";
            this.CamIDNum.Size = new System.Drawing.Size(132, 20);
            this.CamIDNum.TabIndex = 7;
            this.CamIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CamIDNum);
            this.groupBox1.Controls.Add(this.PolyColorNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SoundIDNum);
            this.groupBox1.Controls.Add(this.ExitIDNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 120);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GroundIDNum);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.AttribIDNum);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.SpecialIDNum);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.WallIDNum);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LinkNoNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(3, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 149);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // GroundIDNum
            // 
            this.GroundIDNum.Location = new System.Drawing.Point(71, 121);
            this.GroundIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GroundIDNum.Name = "GroundIDNum";
            this.GroundIDNum.Size = new System.Drawing.Size(118, 20);
            this.GroundIDNum.TabIndex = 9;
            this.GroundIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ground ID:";
            // 
            // AttribIDNum
            // 
            this.AttribIDNum.Location = new System.Drawing.Point(63, 93);
            this.AttribIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AttribIDNum.Name = "AttribIDNum";
            this.AttribIDNum.Size = new System.Drawing.Size(126, 20);
            this.AttribIDNum.TabIndex = 7;
            this.AttribIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Attrib. ID:";
            // 
            // SpecialIDNum
            // 
            this.SpecialIDNum.Location = new System.Drawing.Point(71, 66);
            this.SpecialIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SpecialIDNum.Name = "SpecialIDNum";
            this.SpecialIDNum.Size = new System.Drawing.Size(118, 20);
            this.SpecialIDNum.TabIndex = 5;
            this.SpecialIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Special ID:";
            // 
            // WallIDNum
            // 
            this.WallIDNum.Location = new System.Drawing.Point(57, 40);
            this.WallIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.WallIDNum.Name = "WallIDNum";
            this.WallIDNum.Size = new System.Drawing.Size(132, 20);
            this.WallIDNum.TabIndex = 3;
            this.WallIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Wall ID:";
            // 
            // LinkNoNum
            // 
            this.LinkNoNum.Location = new System.Drawing.Point(62, 14);
            this.LinkNoNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LinkNoNum.Name = "LinkNoNum";
            this.LinkNoNum.Size = new System.Drawing.Size(127, 20);
            this.LinkNoNum.TabIndex = 1;
            this.LinkNoNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Link No.:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RoomPathPntNoNum);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.RoomPathIDNum);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.RoomCamIDNum);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.CamMoveBGNum);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(3, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 124);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // RoomPathPntNoNum
            // 
            this.RoomPathPntNoNum.Location = new System.Drawing.Point(105, 94);
            this.RoomPathPntNoNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RoomPathPntNoNum.Name = "RoomPathPntNoNum";
            this.RoomPathPntNoNum.Size = new System.Drawing.Size(84, 20);
            this.RoomPathPntNoNum.TabIndex = 7;
            this.RoomPathPntNoNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "RoomPathPntNo.:";
            // 
            // RoomPathIDNum
            // 
            this.RoomPathIDNum.Location = new System.Drawing.Point(83, 68);
            this.RoomPathIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RoomPathIDNum.Name = "RoomPathIDNum";
            this.RoomPathIDNum.Size = new System.Drawing.Size(106, 20);
            this.RoomPathIDNum.TabIndex = 5;
            this.RoomPathIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "RoomPathID:";
            // 
            // RoomCamIDNum
            // 
            this.RoomCamIDNum.Location = new System.Drawing.Point(82, 41);
            this.RoomCamIDNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RoomCamIDNum.Name = "RoomCamIDNum";
            this.RoomCamIDNum.Size = new System.Drawing.Size(107, 20);
            this.RoomCamIDNum.TabIndex = 3;
            this.RoomCamIDNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "RoomCamID:";
            // 
            // CamMoveBGNum
            // 
            this.CamMoveBGNum.Location = new System.Drawing.Point(85, 14);
            this.CamMoveBGNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CamMoveBGNum.Name = "CamMoveBGNum";
            this.CamMoveBGNum.Size = new System.Drawing.Size(104, 20);
            this.CamMoveBGNum.TabIndex = 1;
            this.CamMoveBGNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "CamMoveBG:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CamBehvNum);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(3, 411);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 41);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // CamBehvNum
            // 
            this.CamBehvNum.Location = new System.Drawing.Point(103, 14);
            this.CamBehvNum.Name = "CamBehvNum";
            this.CamBehvNum.Size = new System.Drawing.Size(86, 20);
            this.CamBehvNum.TabIndex = 1;
            this.CamBehvNum.Leave += new System.EventHandler(this.CheckSetNumericToZero);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Camera Behavior:";
            // 
            // CopyPropButton
            // 
            this.CopyPropButton.Location = new System.Drawing.Point(3, 503);
            this.CopyPropButton.Name = "CopyPropButton";
            this.CopyPropButton.Size = new System.Drawing.Size(92, 23);
            this.CopyPropButton.TabIndex = 12;
            this.CopyPropButton.Text = "Copy Property";
            this.CopyPropButton.UseVisualStyleBackColor = true;
            this.CopyPropButton.Click += new System.EventHandler(this.CopyPropButton_Click);
            // 
            // PastePropButton
            // 
            this.PastePropButton.Location = new System.Drawing.Point(106, 503);
            this.PastePropButton.Name = "PastePropButton";
            this.PastePropButton.Size = new System.Drawing.Size(92, 23);
            this.PastePropButton.TabIndex = 13;
            this.PastePropButton.Text = "Paste Property";
            this.PastePropButton.UseVisualStyleBackColor = true;
            this.PastePropButton.Click += new System.EventHandler(this.PastePropButton_Click);
            // 
            // InheritBox
            // 
            this.InheritBox.AutoSize = true;
            this.InheritBox.Location = new System.Drawing.Point(3, 470);
            this.InheritBox.Name = "InheritBox";
            this.InheritBox.Size = new System.Drawing.Size(197, 17);
            this.InheritBox.TabIndex = 14;
            this.InheritBox.Text = "Face inherits parent group\'s property";
            this.InheritBox.UseVisualStyleBackColor = true;
            this.InheritBox.CheckedChanged += new System.EventHandler(this.InheritBox_CheckedChanged);
            // 
            // AllInheritToggle
            // 
            this.AllInheritToggle.Location = new System.Drawing.Point(3, 466);
            this.AllInheritToggle.Name = "AllInheritToggle";
            this.AllInheritToggle.Size = new System.Drawing.Size(195, 23);
            this.AllInheritToggle.TabIndex = 15;
            this.AllInheritToggle.Text = "Make All Faces Inherit Group Property";
            this.AllInheritToggle.UseVisualStyleBackColor = true;
            this.AllInheritToggle.Click += new System.EventHandler(this.AllInheritToggle_Click);
            // 
            // PropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.AllInheritToggle);
            this.Controls.Add(this.InheritBox);
            this.Controls.Add(this.PastePropButton);
            this.Controls.Add(this.CopyPropButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(201, 626);
            ((System.ComponentModel.ISupportInitialize)(this.PolyColorNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroundIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttribIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkNoNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPathPntNoNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPathIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomCamIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamMoveBGNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamBehvNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button CopyPropButton;
        private System.Windows.Forms.Button PastePropButton;
        public System.Windows.Forms.NumericUpDown ExitIDNum;
        public System.Windows.Forms.NumericUpDown SoundIDNum;
        public System.Windows.Forms.NumericUpDown CamIDNum;
        public System.Windows.Forms.NumericUpDown GroundIDNum;
        public System.Windows.Forms.NumericUpDown AttribIDNum;
        public System.Windows.Forms.NumericUpDown SpecialIDNum;
        public System.Windows.Forms.NumericUpDown WallIDNum;
        public System.Windows.Forms.NumericUpDown LinkNoNum;
        public System.Windows.Forms.NumericUpDown RoomPathPntNoNum;
        public System.Windows.Forms.NumericUpDown RoomPathIDNum;
        public System.Windows.Forms.NumericUpDown RoomCamIDNum;
        public System.Windows.Forms.NumericUpDown CamMoveBGNum;
        public System.Windows.Forms.NumericUpDown CamBehvNum;
        public System.Windows.Forms.NumericUpDown PolyColorNum;
        private System.Windows.Forms.CheckBox InheritBox;
        private System.Windows.Forms.Button AllInheritToggle;
    }
}
