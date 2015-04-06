using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;
using GameFormatReader.Common;
using grendgine_collada;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace DZBEditor
{
    public partial class MainForm : Form
    {
        ParentGroup ModelRoot;

        Timer time;

        Camera cam;

        Vector2 lastMousePos;

        bool IsViewportLoaded;
        bool IsMouseOnViewport;
        bool ShouldCenterCamOnSelection;

        int _programID;

        int _uniformMVP;
        int _uniformColor;

        List<Keys> PressedKeyList;

        ObservableCollection<EditorFace> SelectedFaces;

        public enum ShaderAttributeIds
        {
            Position, Color,
            TexCoord
        }

        public MainForm()
        {
            InitializeComponent();

            MainForm Main = this;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModelRoot != null)
            {
                if (MessageBox.Show("Opening a new model will close the model you're currently working on. Would you like to continue?", 
                    "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                UnloadFile();
                Open(OpenFile.FileName);
                FillTreeView();
            }
        }

        private void Open(string filePath)
        {
            if (!File.Exists(filePath))
                throw new IOException(string.Format("Cannot open {0}. File/Path does not exist.", filePath));

            string fileExtension = Path.GetExtension(filePath);

            if (string.Compare(fileExtension, ".dzb") == 0)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    EndianBinaryReader reader = new EndianBinaryReader(fileStream, Endian.Big);

                    DzbFile dzb = new DzbFile(reader);

                    ModelRoot = dzb.Root;
                }
            }

            else if (string.Compare(fileExtension, ".dae") == 0)
            {
                ColladaFile collada = new ColladaFile(grendgine_collada.Grendgine_Collada.Grendgine_Load_File(OpenFile.FileName), OpenFile.SafeFileName);

                ModelRoot = collada.Root;
            }

            else
            {
                Console.WriteLine("Failed to open file {0} - Unknown file extension. Only .dzb and .dae types are supported.", filePath);
            }
        }

        private void CreateTimer()
        {
            time = new Timer();

            time.Interval = 16;

            time.Tick += (o, args) =>
                {
                    Draw();

                    CheckMouseOnViewport();

                    PropControl.UpdateProperty();

                    GroControl.UpdateGroup();
                };

            time.Enabled = true;
        }

        private void Draw()
        {
            if (!IsViewportLoaded)
                return;

            GL.ClearColor(Color.DeepSkyBlue);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Tell OpenGL which program to use (our Vert Shader (VS) and Frag Shader (FS))
            GL.UseProgram(_programID);

            //Enable depth-testing which keeps models from rendering inside out.
            GL.Enable(EnableCap.DepthTest);

            //Clear any previously bound buffer so we have no leftover data or anything.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            //Build a Model View Projection Matrix. This is where you would add camera movement (modifiying the View matrix), Perspective rendering (perspective matrix) and model position/scale/rotation (Model)
            Matrix4 viewMatrix = cam.GetViewMatrix();
            Matrix4 projMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(65), Viewport.Width / (float)Viewport.Height, 250f, 100000f);
            Matrix4 modelMatrix = Matrix4.Identity; //Identity = doesn't change anything when multiplied.

            if (ModelRoot != null)
            {
                foreach (IGroup parGroup in ModelRoot.ChildGroups)
                {
                    if (parGroup == null)
                        continue;

                    ParentGroup actualParGroup = parGroup as ParentGroup;

                    foreach (IGroup geomGroup in actualParGroup.ChildGroups)
                    {
                        if (geomGroup == null)
                            continue;

                        GeoGroup actualGeomGroup = geomGroup as GeoGroup;

                        if (actualGeomGroup.Faces == null)
                            continue;

                        Color faceCol = Color.FromArgb(200, 240, 216, 230);

                        GL.Disable(EnableCap.Texture2D);

                        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        GL.Enable(EnableCap.Blend);
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Back);
                        GL.FrontFace(FrontFaceDirection.Ccw);

                        GL.Enable(EnableCap.PolygonOffsetFill);
                        GL.PolygonOffset(1.0f, 1.0f);

                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

                        foreach (EditorFace face in actualGeomGroup.Faces)
                        {
                            face.Render(_uniformColor, _uniformMVP, modelMatrix, viewMatrix, projMatrix, faceCol);
                        }

                        GL.Disable(EnableCap.PolygonOffsetFill);

                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                        GL.Disable(EnableCap.Blend);

                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

                        Color lineCol = Color.FromArgb(255, 0, 0, 0);

                        foreach (EditorFace face in actualGeomGroup.Faces)
                        {
                            face.Render(_uniformColor, _uniformMVP, modelMatrix, viewMatrix, projMatrix, lineCol);
                        }
                    }
                }
            }

            if (IsMouseOnViewport)
            {
                MoveCameraAngle();

                MoveCamera();
            }

            Viewport.SwapBuffers();
        }

        private void FillTreeView()
        {
            for (int i = 0; i < ModelRoot.ChildGroups.Count; i++)
            {
                ParentGroup parGroup = ModelRoot.ChildGroups[i] as ParentGroup;

                TreeNode parNode = new TreeNode("[" + i + "] " + parGroup.Name);

                for (int j = 0; j < parGroup.ChildGroups.Count; j++)
                {
                    GeoGroup geoGroup = parGroup.ChildGroups[j] as GeoGroup;

                    TreeNode geoNode = new TreeNode("[" + j + "] " + geoGroup.Name);

                    for (int k = 0; k < geoGroup.Faces.Count; k++)
                    {
                        TreeNode faceNode = new TreeNode(geoGroup.Name + "_" + k);

                        geoNode.Nodes.Add(faceNode);
                    }

                    parNode.Nodes.Add(geoNode);
                }

                GroupView.Nodes.Add(parNode);
            }
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadFile();
        }

        private void UnloadFile()
        {
            ModelRoot = null;

            GroupView.Nodes.Clear();
        }

        private void GroupView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void UpdateUI(TreeNode updateNode)
        {

        }

        private void GroupView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateUI(e.Node);
        }

        private void Application_Idle(Object sender, EventArgs e)
        {

        }

        private void UpdateGroup(TreeNode updateNode)
        {
        }

        private void UpdateProperty(TreeNode updateNode)
        {
        }

        private void ChangeSelection()
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _programID = GL.CreateProgram();

            PropControl.DisableFields();

            GroControl.DisableFields();

            PressedKeyList = new List<Keys>();

            SelectedFaces = new ObservableCollection<EditorFace>();

            SelectedFaces.CollectionChanged += (o, args) =>
                {
                    if (args.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    {
                        SelectedFaces[args.NewStartingIndex].IsSelected = true;
                    }
                };

            lastMousePos = new Vector2();

            //Create the Vertex and Fragment shader from file using our helper function
            int vertShaderId, fragShaderId;
            LoadShader("vs.glsl", ShaderType.VertexShader, _programID, out vertShaderId);
            LoadShader("fs.glsl", ShaderType.FragmentShader, _programID, out fragShaderId);

            //Deincriment the reference count on the shaders so that they don't exist until the context is destroyed.
            //(Housekeeping really)
            GL.DeleteShader(vertShaderId);
            GL.DeleteShader(fragShaderId);

            //This specifically tells OpenGL that we want to be able to refer to the "vertexPos" variable inside of the vs.glsl 
            //This allows us to later refer to it by specicic number.
            GL.BindAttribLocation(_programID, (int)ShaderAttributeIds.Position, "vertexPos");

            //Linking the shader tells OpenGL to finish compiling it or something. It's required. :P
            GL.LinkProgram(_programID);

            //Now that the program is linked we can get the identifier/location of the uniforms (by id) within the shader.
            _uniformMVP = GL.GetUniformLocation(_programID, "modelview");
            _uniformColor = GL.GetUniformLocation(_programID, "outputColor");

            //More error checking
            if (GL.GetError() != ErrorCode.NoError)
                Console.WriteLine(GL.GetProgramInfoLog(_programID));

            CreateTimer();
        }

        private void Viewport_Load(object sender, EventArgs e)
        {
            IsViewportLoaded = true;

            cam = new Camera();
        }

        private void SetLastCursorPos()
        {
            //Cursor.Position = new Point((Viewport.Bounds.Left + Viewport.Bounds.Width) / 2, (Viewport.Bounds.Top + Viewport.Bounds.Height) / 2);
            lastMousePos = new Vector2(Cursor.Position.X, Cursor.Position.Y);
        }

        private void MoveCameraAngle()
        {
            if ((IsMouseOnViewport) && (MouseButtons == MouseButtons.Left))
            {
                Vector2 delta = lastMousePos - new Vector2(Cursor.Position.X, Cursor.Position.Y);

                cam.AddRotation(delta.X, delta.Y);
                SetLastCursorPos();
            }

            lastMousePos = new Vector2(Cursor.Position.X, Cursor.Position.Y);
        }

        protected void LoadShader(string fileName, ShaderType type, int program, out int address)
        {
            //Gets an id from OpenGL
            address = GL.CreateShader(type);
            using (var streamReader = new StreamReader(fileName))
            {
                GL.ShaderSource(address, streamReader.ReadToEnd());
            }
            //Compiles the shader code
            GL.CompileShader(address);
            //Tells OpenGL that this shader (be it vertex of fragment) belongs to the specified program
            GL.AttachShader(program, address);

            //Error checking.
            int compileSuccess;
            GL.GetShader(address, ShaderParameter.CompileStatus, out compileSuccess);

            if (compileSuccess == 0)
                Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        private void Viewport_KeyDown(object sender, KeyEventArgs e)
        {
            if (!PressedKeyList.Contains(e.KeyData))
            {
                if (e.KeyCode == Keys.Space)
                    PressedKeyList.Insert(0, e.KeyData);

                else
                    PressedKeyList.Add(e.KeyData);
            }
        }

        private void Viewport_KeyUp(object sender, KeyEventArgs e)
        {
            if (PressedKeyList.Contains(e.KeyData))
                PressedKeyList.Remove(e.KeyData);
        }

        private void MoveCamera()
        {
            cam.MoveSpeed = 50.0f;
            
            foreach (Keys key in PressedKeyList)
            {
                switch (key)
                {
                    case (Keys.W):
                        cam.Move(0f, 100000000000.0f, 0f);
                        break;
                    case (Keys.S):
                        cam.Move(0f, -100000000000.0f, 0f);
                        break;
                    case (Keys.A):
                        cam.Move(-100000000000.0f, 0f, 0f);
                        break;
                    case (Keys.D):
                        cam.Move(100000000000.0f, 0f, 0f);
                        break;
                    case (Keys.Q):
                        cam.Move(0f, 0f, 100000000000.0f);
                        break;
                    case (Keys.E):
                        cam.Move(0f, 0f, -100000000000.0f);
                        break;
                    case (Keys.Space):
                        cam.MoveSpeed = 500.0f;
                        break;
                }
            }
        }

        private void GroupView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void SelectNode(TreeNode node)
        {
            int faceNodeIndex;
            int geoNodeIndex;
            int parentNodeIndex;

            foreach (EditorFace face in SelectedFaces)
            {
                face.IsSelected = false;
            }

            SelectedFaces.Clear();

            PropControl.EnableFields();

            GroControl.EnableFields();

            if (node.Level == 2)
            {
                faceNodeIndex = node.Index;
                geoNodeIndex = node.Parent.Index;
                parentNodeIndex = node.Parent.Parent.Index;

                ParentGroup parent = ModelRoot.ChildGroups[parentNodeIndex] as ParentGroup;

                GeoGroup geom = parent.ChildGroups[geoNodeIndex] as GeoGroup;

                SelectedFaces.Add(geom.Faces[faceNodeIndex]);

                if (ShouldCenterCamOnSelection)
                {
                    cam.MoveCamToFace(geom.Faces[faceNodeIndex].AverageVerts());
                }

                PropControl.UpdatePropUI(geom.Faces[faceNodeIndex].FaceSurface, geom.Faces[faceNodeIndex]);

                PropControl.HideToggleAllInherit();

                PropControl.ShowInheritCheckbox();

                GroControl.DisableFields();
            }

            else if (node.Level == 1)
            {
                geoNodeIndex = node.Index;
                parentNodeIndex = node.Parent.Index;

                ParentGroup parent = ModelRoot.ChildGroups[parentNodeIndex] as ParentGroup;

                GeoGroup geom = parent.ChildGroups[geoNodeIndex] as GeoGroup;

                foreach (EditorFace face in geom.Faces)
                {
                    SelectedFaces.Add(face);
                }

                PropControl.UpdatePropUI(geom.DefaultSurface, geom);

                PropControl.HideInheritCheckbox();

                PropControl.ShowToggleAllInherit();

                GroControl.UpdateGroupUI(geom);
            }

            else if (node.Level == 0)
            {
                parentNodeIndex = node.Index;

                ParentGroup parent = ModelRoot.ChildGroups[parentNodeIndex] as ParentGroup;

                for (int i = 0; i < parent.ChildGroups.Count; i++)
                {
                    GeoGroup geom = parent.ChildGroups[i] as GeoGroup;

                    foreach (EditorFace face in geom.Faces)
                    {
                        SelectedFaces.Add(face);
                    }
                }

                PropControl.DisableFields();

                PropControl.HideInheritCheckbox();

                GroControl.UpdateGroupUI(parent);
            }
        }

        private void Viewport_Click(object sender, EventArgs e)
        {
        }

        private void Viewport_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void Viewport_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void Viewport_MouseEnter(object sender, EventArgs e)
        {
            //IsMouseOnViewport = true;
        }

        private void Viewport_MouseLeave(object sender, EventArgs e)
        {
            //IsMouseOnViewport = false;

            //PressedKeyList.Clear();
        }

        private void Viewport_Leave(object sender, EventArgs e)
        {
            PressedKeyList.Clear();
        }

        private void CheckMouseOnViewport()
        {
            if (Viewport.RectangleToScreen(Viewport.ClientRectangle).Contains(Cursor.Position))
                IsMouseOnViewport = true;

            else
            {
                IsMouseOnViewport = false;
                PressedKeyList.Clear();
            }
        }

        private void Viewport_Resize(object sender, EventArgs e)
        {
            GL.Viewport(Viewport.ClientRectangle);
        }

        private void moveCameraToSelectionToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem check = sender as ToolStripMenuItem;

            if (check.Checked)
                ShouldCenterCamOnSelection = true;

            else
                ShouldCenterCamOnSelection = false;
        }

        private void exportDZBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModelRoot == null)
                return;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                Exporter export = new Exporter(ModelRoot, SaveFile.FileName);

                if (File.Exists(SaveFile.FileName))
                    MessageBox.Show("Export successful.");
            }
        }
    }
}
