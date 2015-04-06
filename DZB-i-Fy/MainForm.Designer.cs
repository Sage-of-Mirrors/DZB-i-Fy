namespace DZBEditor
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDZBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveCameraToSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupView = new System.Windows.Forms.TreeView();
            this.Viewport = new OpenTK.GLControl();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PropertiesTab = new System.Windows.Forms.TabPage();
            this.PropControl = new DZBEditor.PropertyControl();
            this.GroupsTab = new System.Windows.Forms.TabPage();
            this.GroControl = new DZBEditor.GroupControl();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.MenuBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.PropertiesTab.SuspendLayout();
            this.GroupsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1064, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportDZBToolStripMenuItem,
            this.closeFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "File...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportDZBToolStripMenuItem
            // 
            this.exportDZBToolStripMenuItem.Name = "exportDZBToolStripMenuItem";
            this.exportDZBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportDZBToolStripMenuItem.Text = "Export DZB";
            this.exportDZBToolStripMenuItem.Click += new System.EventHandler(this.exportDZBToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeFileToolStripMenuItem.Text = "Close File";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveCameraToSelectionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // moveCameraToSelectionToolStripMenuItem
            // 
            this.moveCameraToSelectionToolStripMenuItem.CheckOnClick = true;
            this.moveCameraToSelectionToolStripMenuItem.Name = "moveCameraToSelectionToolStripMenuItem";
            this.moveCameraToSelectionToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.moveCameraToSelectionToolStripMenuItem.Text = "Move Camera to Selection";
            this.moveCameraToSelectionToolStripMenuItem.CheckedChanged += new System.EventHandler(this.moveCameraToSelectionToolStripMenuItem_CheckedChanged);
            // 
            // GroupView
            // 
            this.GroupView.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupView.Location = new System.Drawing.Point(0, 24);
            this.GroupView.Name = "GroupView";
            this.GroupView.Size = new System.Drawing.Size(193, 658);
            this.GroupView.TabIndex = 1;
            this.GroupView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.GroupView_BeforeSelect);
            this.GroupView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GroupView_AfterSelect);
            this.GroupView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.GroupView_NodeMouseClick);
            // 
            // Viewport
            // 
            this.Viewport.BackColor = System.Drawing.Color.Black;
            this.Viewport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewport.Location = new System.Drawing.Point(193, 24);
            this.Viewport.Name = "Viewport";
            this.Viewport.Size = new System.Drawing.Size(656, 658);
            this.Viewport.TabIndex = 2;
            this.Viewport.VSync = false;
            this.Viewport.Load += new System.EventHandler(this.Viewport_Load);
            this.Viewport.Click += new System.EventHandler(this.Viewport_Click);
            this.Viewport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Viewport_KeyDown);
            this.Viewport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Viewport_KeyUp);
            this.Viewport.Leave += new System.EventHandler(this.Viewport_Leave);
            this.Viewport.MouseEnter += new System.EventHandler(this.Viewport_MouseEnter);
            this.Viewport.MouseLeave += new System.EventHandler(this.Viewport_MouseLeave);
            this.Viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseMove);
            this.Viewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Viewport_MouseUp);
            this.Viewport.Resize += new System.EventHandler(this.Viewport_Resize);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            this.OpenFile.Filter = "DAE files|*.dae|DZB files|*.dzb";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PropertiesTab);
            this.tabControl1.Controls.Add(this.GroupsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(849, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(215, 658);
            this.tabControl1.TabIndex = 3;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Controls.Add(this.PropControl);
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(207, 632);
            this.PropertiesTab.TabIndex = 1;
            this.PropertiesTab.Text = "Properties";
            this.PropertiesTab.UseVisualStyleBackColor = true;
            // 
            // PropControl
            // 
            this.PropControl.BackColor = System.Drawing.SystemColors.Control;
            this.PropControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropControl.Location = new System.Drawing.Point(3, 3);
            this.PropControl.Name = "PropControl";
            this.PropControl.Size = new System.Drawing.Size(201, 626);
            this.PropControl.TabIndex = 0;
            // 
            // GroupsTab
            // 
            this.GroupsTab.Controls.Add(this.GroControl);
            this.GroupsTab.Location = new System.Drawing.Point(4, 22);
            this.GroupsTab.Name = "GroupsTab";
            this.GroupsTab.Padding = new System.Windows.Forms.Padding(3);
            this.GroupsTab.Size = new System.Drawing.Size(207, 632);
            this.GroupsTab.TabIndex = 0;
            this.GroupsTab.Text = "Groups";
            this.GroupsTab.UseVisualStyleBackColor = true;
            // 
            // GroControl
            // 
            this.GroControl.BackColor = System.Drawing.SystemColors.Control;
            this.GroControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroControl.Location = new System.Drawing.Point(3, 3);
            this.GroControl.Name = "GroControl";
            this.GroControl.Size = new System.Drawing.Size(201, 626);
            this.GroControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 682);
            this.Controls.Add(this.Viewport);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.GroupView);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "DZB-i-Fy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.PropertiesTab.ResumeLayout(false);
            this.GroupsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TreeView GroupView;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ToolStripMenuItem exportDZBToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GroupsTab;
        private System.Windows.Forms.TabPage PropertiesTab;
        private OpenTK.GLControl Viewport;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private GroupControl GroControl;
        private PropertyControl PropControl;
        private System.Windows.Forms.ToolStripMenuItem moveCameraToSelectionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFile;
    }
}

