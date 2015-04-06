using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using GameFormatReader.Common;

namespace DZBEditor
{
    public struct ExportFace
    {
        public short[] VertIndexes;
        public short PropIndex, GroupIndex;
    }

    public struct ExportProperty
    {
        public int ColorExitSoundCamBitfield, GroundAttributeSpecialLinkBitfield,
            amMoveCamIDPathIDPathPntBitfield, CameraBehavior;
    }

    public interface IGroup
    {
        #region Properties

        string Name
        {
            get;
            set;
        }

        Vector3 Scale
        {
            get;
            set;
        }

        short[] Rotation
        {
            get;
            set;
        }

        short Padding1
        {
            get;
            set;
        }

        Vector3 Translation
        {
            get;
            set;
        }

        short ParentIndex
        {
            get;
            set;
        }

        short SiblingIndex
        {
            get;
            set;
        }

        short ChildIndex
        {
            get;
            set;
        }

        short Padding2
        {
            get;
            set;
        }

        short StartingBoundingBoxVertsIndex
        {
            get;
            set;
        }

        short ReferenceTreeIndex
        {
            get;
            set;
        }

        short Unknown3
        {
            get;
            set;
        }

        byte SurfaceType
        {
            get;
            set;
        }

        byte RoomNumber
        {
            get;
            set;
        }

        #endregion

        void LoadDataFromStream(EndianBinaryReader stream);

        IGroup LoadDataFromControl(GroupControl control);

        IGroup Copy();

        bool Compare(IGroup comparison);
    }

    public class GeoGroup : IGroup
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public Vector3 Scale
        {
            get;
            set;
        }

        public short[] Rotation
        {
            get;
            set;
        }

        public short Padding1
        {
            get;
            set;
        }

        public Vector3 Translation
        {
            get;
            set;
        }

        public short ParentIndex
        {
            get;
            set;
        }

        public short SiblingIndex
        {
            get;
            set;
        }

        public short ChildIndex
        {
            get;
            set;
        }

        public short Padding2
        {
            get;
            set;
        }

        public short StartingBoundingBoxVertsIndex
        {
            get;
            set;
        }

        public short ReferenceTreeIndex
        {
            get;
            set;
        }

        public short Unknown3
        {
            get;
            set;
        }

        public byte SurfaceType
        {
            get;
            set;
        }

        public byte RoomNumber
        {
            get;
            set;
        }

        public List<EditorFace> Faces
        {
            get;
            set;
        }

        public SurfaceProperty DefaultSurface
        {
            get;
            set;
        }

        #endregion

        public GeoGroup()
        {
            Faces = new List<EditorFace>();

            DefaultSurface = new SurfaceProperty();
        }

        public GeoGroup(EndianBinaryReader stream)
        {
            Faces = new List<EditorFace>();

            DefaultSurface = new SurfaceProperty();

            LoadDataFromStream(stream);
        }

        public void LoadDataFromStream(EndianBinaryReader stream)
        {
            int streamStart = (int)stream.BaseStream.Position;

            stream.BaseStream.Position = stream.ReadInt32();

            char[] tempChars = Encoding.ASCII.GetChars(stream.ReadBytesUntil(0));

            Name = new string(tempChars);

            stream.BaseStream.Position = streamStart + 4;

            Vector3 tempScale = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());

            Scale = tempScale;

            Rotation = new short[3] { stream.ReadInt16(), stream.ReadInt16(), stream.ReadInt16() };

            Padding1 = stream.ReadInt16();

            Vector3 tempTrans = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());

            Translation = tempTrans;

            ParentIndex = stream.ReadInt16();

            SiblingIndex = stream.ReadInt16();

            ChildIndex = stream.ReadInt16();

            Padding2 = stream.ReadInt16();

            StartingBoundingBoxVertsIndex = stream.ReadInt16();

            ReferenceTreeIndex = stream.ReadInt16();

            Unknown3 = stream.ReadInt16();

            SurfaceType = stream.ReadByte();

            RoomNumber = stream.ReadByte();
        }

        public IGroup LoadDataFromControl(GroupControl control)
        {
            IGroup temp = new GeoGroup();

            temp.Name = control.NameBox.Text;

            temp.SurfaceType = (byte)control.TerrainTypeBox.SelectedIndex;

            temp.RoomNumber = (byte)control.RoomNo.Value;

            return temp;
        }

        public IGroup Copy()
        {
            GeoGroup newGroup = new GeoGroup();

            newGroup.Name = Name;
            newGroup.Scale = Scale;
            newGroup.Rotation = Rotation;
            newGroup.Padding1 = Padding1;
            newGroup.Translation = Translation;
            newGroup.ParentIndex = ParentIndex;
            newGroup.SiblingIndex = SiblingIndex;
            newGroup.ChildIndex = ChildIndex;
            newGroup.Padding2 = Padding2;
            newGroup.StartingBoundingBoxVertsIndex = StartingBoundingBoxVertsIndex;
            newGroup.Unknown3 = Unknown3;
            newGroup.SurfaceType = SurfaceType;
            newGroup.RoomNumber = RoomNumber;

            newGroup.Faces = CopyFaces();

            newGroup.DefaultSurface = DefaultSurface.Copy();

            return newGroup;
        }

        private List<EditorFace> CopyFaces()
        {
            List<EditorFace> newFaceList = new List<EditorFace>();

            foreach (EditorFace face in Faces)
            {
                EditorFace tempFace = face.Copy();

                newFaceList.Add(tempFace);
            }

            return newFaceList;
        }

        public bool Compare(IGroup comparison)
        {
            if (comparison == null)
                return false;

            if (ReferenceEquals(this, comparison))
                return true;

            if ((Name == comparison.Name) && /*(Scale.Equals(comparison.Scale)) && (Rotation == comparison.Rotation) && (Padding1 == comparison.Padding1)
                && (Translation.Equals(comparison.Translation)) && (ParentIndex == comparison.ParentIndex) && (SiblingIndex == comparison.SiblingIndex)
                && (ChildIndex == comparison.ChildIndex) && (Padding2 == comparison.Padding2) && (StartingBoundingBoxVertsIndex == comparison.StartingBoundingBoxVertsIndex)
                && (ReferenceTreeIndex == comparison.ReferenceTreeIndex) && (Unknown3 == comparison.Unknown3) &&*/ (SurfaceType == comparison.SurfaceType)
                && (RoomNumber == comparison.RoomNumber))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }

    public class ParentGroup : IGroup
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public Vector3 Scale
        {
            get;
            set;
        }

        public short[] Rotation
        {
            get;
            set;
        }

        public short Padding1
        {
            get;
            set;
        }

        public Vector3 Translation
        {
            get;
            set;
        }

        public short ParentIndex
        {
            get;
            set;
        }

        public short SiblingIndex
        {
            get;
            set;
        }

        public short ChildIndex
        {
            get;
            set;
        }

        public short Padding2
        {
            get;
            set;
        }

        public short StartingBoundingBoxVertsIndex
        {
            get;
            set;
        }

        public short ReferenceTreeIndex
        {
            get;
            set;
        }

        public short Unknown3
        {
            get;
            set;
        }

        public byte SurfaceType
        {
            get;
            set;
        }

        public byte RoomNumber
        {
            get;
            set;
        }

        public List<IGroup> ChildGroups
        {
            get;
            set;
        }

        #endregion

        public ParentGroup()
        {
            ChildGroups = new List<IGroup>();
        }

        public ParentGroup(EndianBinaryReader stream)
        {
            ChildGroups = new List<IGroup>();

            LoadDataFromStream(stream);
        }

        public void LoadDataFromStream(EndianBinaryReader stream)
        {
            int streamStart = (int)stream.BaseStream.Position;

            stream.BaseStream.Position = stream.ReadInt32();

            char[] tempChars = Encoding.ASCII.GetChars(stream.ReadBytesUntil(0));

            Name = new string(tempChars);

            stream.BaseStream.Position = streamStart + 4;

            Vector3 tempScale = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());

            Scale = tempScale;

            Rotation = new short[3] { stream.ReadInt16(), stream.ReadInt16(), stream.ReadInt16() };

            Padding1 = stream.ReadInt16();

            Vector3 tempTrans = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());

            Translation = tempTrans;

            ParentIndex = stream.ReadInt16();

            SiblingIndex = stream.ReadInt16();

            ChildIndex = stream.ReadInt16();

            Padding2 = stream.ReadInt16();

            StartingBoundingBoxVertsIndex = stream.ReadInt16();

            ReferenceTreeIndex = stream.ReadInt16();

            Unknown3 = stream.ReadInt16();

            SurfaceType = stream.ReadByte();

            RoomNumber = stream.ReadByte();
        }

        public IGroup LoadDataFromControl(GroupControl control)
        {
            IGroup temp = new ParentGroup();

            temp.Name = control.NameBox.Text;

            temp.SurfaceType = (byte)control.TerrainTypeBox.SelectedIndex;

            temp.RoomNumber = (byte)control.RoomNo.Value;

            return temp;
        }

        public IGroup Copy()
        {
            ParentGroup newGroup = new ParentGroup();

            newGroup.Name = Name;
            newGroup.Scale = Scale;
            newGroup.Rotation = Rotation;
            newGroup.Padding1 = Padding1;
            newGroup.Translation = Translation;
            newGroup.ParentIndex = ParentIndex;
            newGroup.SiblingIndex = SiblingIndex;
            newGroup.ChildIndex = ChildIndex;
            newGroup.Padding2 = Padding2;
            newGroup.StartingBoundingBoxVertsIndex = StartingBoundingBoxVertsIndex;
            newGroup.Unknown3 = Unknown3;
            newGroup.SurfaceType = SurfaceType;
            newGroup.RoomNumber = RoomNumber;

            newGroup.ChildGroups = CopyChildGroups();

            return newGroup;
        }

        private List<IGroup> CopyChildGroups()
        {
            List<IGroup> copiedList = new List<IGroup>();

            foreach (IGroup group in ChildGroups)
            {
                IGroup tempGroup = group.Copy();

                copiedList.Add(tempGroup);
            }

            return copiedList;
        }

        public bool Compare(IGroup comparison)
        {
            if (comparison == null)
                return false;

            if (ReferenceEquals(this, comparison))
                return true;

            if ((Name == comparison.Name) && (Scale.Equals(comparison.Scale)) && (Rotation == comparison.Rotation) && (Padding1 == comparison.Padding1)
                && (Translation.Equals(comparison.Translation)) && (ParentIndex == comparison.ParentIndex) && (SiblingIndex == comparison.SiblingIndex)
                && (ChildIndex == comparison.ChildIndex) && (Padding2 == comparison.Padding2) && (StartingBoundingBoxVertsIndex == comparison.StartingBoundingBoxVertsIndex)
                && (ReferenceTreeIndex == comparison.ReferenceTreeIndex) && (Unknown3 == comparison.Unknown3) && (SurfaceType == comparison.SurfaceType)
                && (RoomNumber == comparison.RoomNumber))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }

    public class EditorFace
    {
        public enum ShaderAttributeIds
        {
            Position, Color,
            TexCoord
        }

        public Vector3[] Vertexes;

        private int _glVbo;

        private int _glEbo;

        public SurfaceProperty FaceSurface;

        public bool IsSelected
        {
            get;
            set;
        }

        public bool InheritsParentSurface
        {
            get;
            set;
        }

        public int GroupIndex
        {
            get;
            set;
        }

        public EditorFace()
        {
            Vertexes = new Vector3[3];

            FaceSurface = new SurfaceProperty();
        }

        public EditorFace(Vector3 vert1, Vector3 vert2, Vector3 vert3)
        {
            Vertexes = new Vector3[] { vert1, vert2, vert3 };

            FaceSurface = new SurfaceProperty();

            GenBuffers();
        }

        private void GenBuffers()
        {
            int[] meshIndexes = { 0, 1, 2 };

            GL.GenBuffers(1, out _glVbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _glVbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vertexes.Length * Vector3.SizeInBytes), Vertexes, BufferUsageHint.StaticDraw);

            GL.GenBuffers(1, out _glEbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _glEbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(meshIndexes.Length * 4), meshIndexes, BufferUsageHint.StaticDraw);
        }

        public EditorFace Copy()
        {
            EditorFace newFace = new EditorFace();

            newFace.Vertexes = new Vector3[3];

            newFace.Vertexes[0] = Vertexes[0];
            newFace.Vertexes[1] = Vertexes[1];
            newFace.Vertexes[2] = Vertexes[2];

            newFace.IsSelected = IsSelected;
            newFace.InheritsParentSurface = InheritsParentSurface;

            newFace._glVbo = _glVbo;
            newFace._glEbo = _glEbo;

            newFace.FaceSurface = FaceSurface.Copy();

            newFace.GenBuffers();

            return newFace;
        }

        public Vector3 AverageVerts()
        {
            float averageX = (Vertexes[0].X + Vertexes[1].X + Vertexes[2].X) / 3;

            float averageY = (Vertexes[0].Y + Vertexes[1].Y + Vertexes[2].Y) / 3;

            float averageZ = (Vertexes[0].Z + Vertexes[1].Z + Vertexes[2].Z) / 3;

            Vector3 averagedCoords = new Vector3(averageX, averageY, averageZ);

            return averagedCoords;
        }

        public void Render(int _uniformColor, int _uniformMVP, Matrix4 modelMatrix, Matrix4 viewMatrix, Matrix4 projMatrix, Color normCol)
        {
            Color selectCol = Color.FromArgb(200, 255, 0, 0);

            GL.Uniform4(_uniformColor, normCol);

            if (IsSelected)
                GL.Uniform4(_uniformColor, selectCol);

            //Bind the buffers that have the data you want to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, _glVbo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _glEbo);

            //Then, you have to tell the GPU what the contents of the Array buffer look like. Ie: Is each entry just a position, or does it have a position, color, normal, etc.
            GL.EnableVertexAttribArray((int)ShaderAttributeIds.Position);
            GL.VertexAttribPointer((int)ShaderAttributeIds.Position, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes, 0);

            //Upload the WVP to the GPU
            Matrix4 finalMatrix = modelMatrix * viewMatrix * projMatrix;
            GL.UniformMatrix4(_uniformMVP, false, ref finalMatrix);

            //Now we tell the GPU to actually draw the data we have
            GL.DrawElements(BeginMode.Triangles, 3, DrawElementsType.UnsignedInt, 0);

            //This is cleanup to undo the changes to the OpenGL state we did to draw this model.
            GL.DisableVertexAttribArray((int)ShaderAttributeIds.Position);
        }
    }

    [Serializable]
    public class SurfaceProperty
    {
        public byte CamID;
        public byte SoundEffect;
        public byte ExitID;
        public byte Color;

        public byte LinkNo;
        public byte WallCode;
        public byte SpecialCode;
        public byte AttributeCode;
        public byte GroundCode;

        public byte CamMoveBG;
        public byte RoomCamID;
        public byte RoomPathID;
        public byte RoomPathPntNo;

        public int CameraType;

        public SurfaceProperty()
        {
            CamMoveBG = 255;
            RoomCamID = 255;
            RoomPathID = 255;
            RoomPathPntNo = 255;
        }

        public SurfaceProperty(EndianBinaryReader stream)
        {
            CamID = (byte)((stream.PeekReadInt32() & 0xFF));
            SoundEffect = (byte)((stream.PeekReadInt32() & 0x1F00) >> 8);
            ExitID = (byte)((stream.PeekReadInt32() & 0x7E000) >> 0xD);
            Color = (byte)((stream.ReadInt32() & 0x7F80000) >> 0x13);

            LinkNo = (byte)((stream.PeekReadInt32() & 0xFF));
            WallCode = (byte)((stream.PeekReadInt32() & 0xF00) >> 0x8);
            SpecialCode = (byte)((stream.PeekReadInt32() & 0xF000) >> 0xC);
            AttributeCode = (byte)((stream.PeekReadInt32() & 0x1F0000) >> 0x10);
            GroundCode = (byte)((stream.ReadInt32() & 0x3E00000) >> 0x15);

            CamMoveBG = (byte)((stream.PeekReadInt32() & 0xFF));
            RoomCamID = (byte)((stream.PeekReadInt32() & 0xFF00) >> 0x8);
            RoomPathID = (byte)((stream.PeekReadInt32() & 0xFF0000) >> 0x10);
            RoomPathPntNo = (byte)((stream.ReadInt32() & 0xFF000000) >> 0x18);

            CameraType = stream.ReadInt32();
        }

        public SurfaceProperty(PropertyControl control)
        {
            CamID = (byte)control.CamIDNum.Value;
            SoundEffect = (byte)control.SoundIDNum.Value;
            ExitID = (byte)control.ExitIDNum.Value;
            Color = (byte)control.PolyColorNum.Value;

            LinkNo = (byte)control.LinkNoNum.Value;
            WallCode = (byte)control.WallIDNum.Value;
            SpecialCode = (byte)control.SpecialIDNum.Value;
            AttributeCode = (byte)control.AttribIDNum.Value;
            GroundCode = (byte)control.GroundIDNum.Value;

            CamMoveBG = (byte)control.CamMoveBGNum.Value;
            RoomCamID = (byte)control.RoomCamIDNum.Value;
            RoomPathID = (byte)control.RoomPathIDNum.Value;
            RoomPathPntNo = (byte)control.RoomPathPntNoNum.Value;

            CameraType = (int)control.CamBehvNum.Value;
        }

        public SurfaceProperty Copy()
        {
            SurfaceProperty newProp = new SurfaceProperty();

            newProp.CamID = CamID;
            newProp.SoundEffect = SoundEffect;
            newProp.ExitID = ExitID;
            newProp.Color = Color;

            newProp.LinkNo = LinkNo;
            newProp.WallCode = WallCode;
            newProp.SpecialCode = SpecialCode;
            newProp.AttributeCode = AttributeCode;
            newProp.GroundCode = GroundCode;

            newProp.CamMoveBG = CamMoveBG;
            newProp.RoomCamID = RoomCamID;
            newProp.RoomPathID = RoomPathID;
            newProp.RoomPathPntNo = RoomPathPntNo;

            newProp.CameraType = CameraType;

            return newProp;
        }

        public bool Compare(SurfaceProperty comparison)
        {
            if (comparison == null)
                return true;

            if (ReferenceEquals(this, comparison))
                return true;

            if ((CamID == comparison.CamID) && (SoundEffect == comparison.SoundEffect) && (ExitID == comparison.ExitID) && (Color == comparison.Color)
                && (LinkNo == comparison.LinkNo) && (WallCode == comparison.WallCode) && (SpecialCode == comparison.SpecialCode) && (AttributeCode == comparison.AttributeCode)
                && (GroundCode == comparison.GroundCode) && (CamMoveBG == comparison.CamMoveBG) && (RoomCamID == comparison.RoomCamID) && (RoomPathID == comparison.RoomPathID)
                && (RoomPathPntNo == comparison.RoomPathPntNo) && (CameraType == comparison.CameraType))
                return false;

            else
                return true;
        }

        public ExportProperty MakeExportProperty()
        {
            ExportProperty prop = new ExportProperty();

            prop.ColorExitSoundCamBitfield = (CamID) | (SoundEffect << 8) | (ExitID << 0xD) | (Color << 0x13);

            prop.GroundAttributeSpecialLinkBitfield = (LinkNo) | (WallCode << 8) | (SpecialCode << 0x0C) | (AttributeCode << 0x10) | (GroundCode << 0x15);

            prop.amMoveCamIDPathIDPathPntBitfield = (CamMoveBG) | (RoomCamID << 0x8) | (RoomPathID << 0x10) | (RoomPathPntNo << 0x18);

            prop.CameraBehavior = CameraType;

            return prop;
        }
    }

    public class Exporter
    {
        ParentGroup ExportRoot;

        List<Vector3> ExportVerts;
        List<ExportFace> ExportFaces;
        List<ExportProperty> ExportProperties;
        List<IGroup> ExportGroups;

        public Exporter(ParentGroup root, string fileName)
        {
            ExportRoot = root;

            ExportVerts = new List<Vector3>();
            ExportFaces = new List<ExportFace>();
            ExportProperties = new List<ExportProperty>();
            ExportGroups = new List<IGroup>();

            PopulateGroupList();

            PopulateExportLists();
        }

        private void PopulateGroupList()
        {
            ExportGroups.Add(ExportRoot);

            foreach (IGroup group in ExportRoot.ChildGroups)
            {
                ExportGroups.Add(group);
            }

            int numNonGeomGroups = ExportGroups.Count;

            for (int i = 1; i < numNonGeomGroups; i++)
            {
                ParentGroup par = ExportGroups[i] as ParentGroup;

                foreach (IGroup geo in par.ChildGroups)
                {
                    ExportGroups.Add(geo);
                }
            }
        }

        private void PopulateExportLists()
        {
            for (int i = 1; i < ExportGroups.Count; i++)
            {
                if (ExportGroups[i].GetType() != typeof(GeoGroup))
                    continue;

                GeoGroup geo = ExportGroups[i] as GeoGroup;

                foreach (EditorFace face in geo.Faces)
                {
                    ExportFace exFace = new ExportFace();

                    exFace.GroupIndex = (short)i;

                    exFace.VertIndexes = new short[3];

                    for (int j = 0; j < 3; j++)
                    {
                        if (ExportVerts.Contains(face.Vertexes[j]))
                        {
                            exFace.VertIndexes[j] = (short)ExportVerts.IndexOf(face.Vertexes[j]);
                            continue;
                        }

                        ExportVerts.Add(face.Vertexes[j]);

                        exFace.VertIndexes[j] = (short)(ExportVerts.Count - 1);
                    }

                    if (face.InheritsParentSurface)
                    {
                        ExportProperty prop = geo.DefaultSurface.MakeExportProperty();

                        if (ExportProperties.Contains(prop))
                        {
                            exFace.PropIndex = (short)ExportProperties.IndexOf(prop);
                            ExportFaces.Add(exFace);
                            continue;
                        }

                        ExportProperties.Add(prop);

                        exFace.PropIndex = (short)(ExportProperties.Count - 1);

                        ExportFaces.Add(exFace);
                    }

                    else
                    {
                        ExportProperty prop = face.FaceSurface.MakeExportProperty();

                        if (ExportProperties.Contains(prop))
                        {
                            exFace.PropIndex = (short)ExportProperties.IndexOf(prop);
                            ExportFaces.Add(exFace);
                            continue;
                        }

                        ExportProperties.Add(prop);

                        exFace.PropIndex = (short)(ExportProperties.Count - 1);

                        ExportFaces.Add(exFace);
                    }
                }
            }
        }
    }
}
