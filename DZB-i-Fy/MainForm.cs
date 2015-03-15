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
                // I store the result of Path.GetExtension(...) in a variable so that A) It's not called twice in the original if/if statement
                // and B) I can easily inspect it with the inspector, since the inspector won't call functions when you mouse over them.
                string fileExtension = Path.GetExtension(OpenFile.FileName);

                // If you're dealing with FileStreams, you'll want to use the "using" statement.
                // The long-form technical answer is here: @https://msdn.microsoft.com/en-us/library/yh598w02.aspx
                // but the short-form version is as follows:

                // Anything that implements the IDisposable interface is designed to deal with native objects (unmanaged resources such as file
                // handles and device contexts). When working with these native objects it's important that a program frees the resource, or 
                // returns the device context when finished. Now, if you weren't using the using statement and your program threw an exception
                // before calling the "Dispose" function of the IDisposable interface (which FileStream implements) then the program would never
                // free the resource and you'd leak memory and not release file lock handles which just becomes a pita for everything else.
                //
                //
                // The "using" statement is a workaround to this, where even if the program does throw an exception inside the using block,
                // it'll always ensure that Dispose() is called on the object, which frees the file handle locks, device contexts, etc.
                using (FileStream fileStream = new FileStream(OpenFile.FileName, FileMode.Open))
                {
                    EndianBinaryReader streamReader = new EndianBinaryReader(fileStream, Endian.Big);

                    if (string.Compare(fileExtension, ".dzb") == 0)
                    {
                        LoadedDZB = new DzbFile(streamReader);
                    }
                    else
                    {
                        Console.WriteLine("DZB-i-Fy: Opening .dae files isn't supported quite yet. Oops!");
                    }
                }
            }
        }
    }
}
