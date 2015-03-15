using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GameFormatReader.Common;

namespace DZBEditor
{
    public partial class MainForm : Form
    {
        DzbFile LoadedDZB;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Open()
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(OpenFile.FileName) == ".dzb")
                {
                    FileStream baseStream = new FileStream(OpenFile.FileName, FileMode.Open);

                    EndianBinaryReader stream = new EndianBinaryReader(baseStream, Endian.Big);

                    LoadedDZB = new DzbFile(stream);
                }

                if (Path.GetExtension(OpenFile.FileName) == ".dae")
                {

                }
            }
        }
    }
}
