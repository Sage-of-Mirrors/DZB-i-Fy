using System;
using System.Windows.Forms;
using System.IO;
using GameFormatReader.Common;
using grendgine_collada;

namespace DZBEditor
{
    public partial class MainForm : Form
    {
        DzbFile LoadedDZB;
        ColladaFile LoadedCollada;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Don't just have the UI toolstrip menu call a function that invokes a function named "Open". If I didn't read
            // the code, I would assume Open would take a string to the filepath (or a filestream) and would be very confused
            // when a non-ui looking function invoked UI as its first step.
            //
            // This means that you can change the UI later (ie: remove the open file dialog, switch to a non-winforms project, etc.)
            // and still use the same "Open" function without having to go modify that too. The more you can group UI related functions
            // together, and functions that operate on data/whatever (without knowing about the UI) the better.

            if (OpenFile.ShowDialog() == DialogResult.OK)
                Open(OpenFile.FileName);
        }

        private void Open(string filePath)
        {
            // Always worth getting into the habit of checking your incoming information.
            if (!File.Exists(filePath))
                throw new IOException(string.Format("Cannot open {0}. File/Path does not exist.", filePath));

            // I store the result of Path.GetExtension(...) in a variable so that A) It's not called twice in the original if/if statement
            // and B) I can easily inspect it with the inspector, since the inspector won't call functions when you mouse over them.
            string fileExtension = Path.GetExtension(filePath);

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
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                EndianBinaryReader streamReader = new EndianBinaryReader(fileStream, Endian.Big);

                if (string.Compare(fileExtension, ".dzb") == 0)
                {
                    LoadedDZB = new DzbFile(streamReader);
                }
                else
                {
                    Grendgine_Collada collada = Grendgine_Collada.Grendgine_Load_File(filePath);
                    LoadedCollada = new ColladaFile(collada);
                }
            }
        }
    }
}
