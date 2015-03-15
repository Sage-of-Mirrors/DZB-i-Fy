using System;
using System.Windows.Forms;
using System.IO;
using GameFormatReader.Common;

namespace DZBEditor
{
    public partial class MainForm : Form
    {
        // So this confuses me. The idea behind most editors (and probably should be for this one too)
        // is that they accept a variety of input files and transform the data into one common file format.
        // By placing them into a single, common, file format, the rest of the editor only has to care about
        // a single format, and it never has to care about a specific source format once loaded.
        //
        //
        // So it doesn't make sense to store a reference to both, knowing that one will be null. At every possible
        // interaction moment, you'd have to check if one, or both, are null, and handle each one separately.
        //
        // Now, we just have one type of collision file we care about. It doesn't matter whether it came from a 
        // DAE file or a DZB file, all editor tools can assume it's a CollisionFile type and work with that.
        private CollisionFile currentCollisionFile = null;

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

            // We can check if they've already got a file open here and warn them about losing changes if we want.
            if (currentCollisionFile != null)
            {
                // Create a pop-up dialog here that asks them if they want to save changes before leaving or something.
                // If they don't want to leave (ie: hit the cancel button) then just return from this function and skip
                // opening the openFileDialog and all that jazz.
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                Open(openFileDialog.FileName);
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

                // We use string.Compare(string, string, bool) here to compare them case insensitive.
                // sometimes things get funny and people end up with weird extension capitalization,
                // like .DAE which would have failed to load a perfectly good dae file under your
                // original code. :)
                if (string.Compare(fileExtension, ".dzb", true) == 0)
                {
                    currentCollisionFile = new CollisionFile();
                    currentCollisionFile.LoadFromDZBFile(streamReader);
                    Console.WriteLine("Loaded new dzb from existng dzb file {0}.", filePath);
                }
                else if (string.Compare(fileExtension, ".dae", true) == 0)
                {
                    currentCollisionFile = new CollisionFile();
                    currentCollisionFile.LoadFromCollada(filePath);
                    Console.WriteLine("Loaded new dzb from dae file {0}.", filePath);
                }
                else
                {
                    // You can only get to this else assuming you called Open from outside of the UI, which is now possible to do
                    // thanks to our refactor of how the Open file worked.
                    Console.WriteLine("Failed to open file {0} - Unknown file extension. Only .dzb and .dae types are supported.", filePath);
                }
            }
        }
    }
}
