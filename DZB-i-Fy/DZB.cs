using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using GameFormatReader.Common;
using grendgine_collada;

namespace DZBEditor
{
    class DzbFile
    {
        List<Vector3> Vertexes;
        List<Face> Faces;
        List<Group> Groups;
        List<SurfaceProperty> Properties;

        int VertexCount;
        int FaceCount;
        int PropertyCount;
        int GroupCount;

        int VertexStartOffset;
        int FaceStartOffset;
        int PropertyStartOffset;
        int GroupStartOffset;

        public DzbFile(EndianBinaryReader stream)
        {
            VertexCount = stream.ReadInt32();
            VertexStartOffset = stream.ReadInt32();

            FaceCount = stream.ReadInt32();
            FaceStartOffset = stream.ReadInt32();

            stream.BaseStream.Position = 0x20;

            GroupCount = stream.ReadInt32();
            GroupStartOffset = stream.ReadInt32();

            PropertyCount = stream.ReadInt32();
            PropertyStartOffset = stream.ReadInt32();

            Vertexes = new List<Vector3>();

            for (int i = 0; i < VertexCount; i++)
            {
                Vector3 tempVec = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());

                Vertexes.Add(tempVec);
            }

            Properties = new List<SurfaceProperty>();

            stream.BaseStream.Position = PropertyStartOffset;

            for (int i = 0; i < PropertyCount; i++)
            {
                SurfaceProperty tempProp = new SurfaceProperty(stream);

                Properties.Add(tempProp);
            }

            Faces = new List<Face>();

            stream.BaseStream.Position = FaceStartOffset;

            for (int i = 0; i < FaceCount; i++)
            {
                Face tempFace = new Face(GetVertex(stream.ReadInt16()), GetVertex(stream.ReadInt16()), 
                    GetVertex(stream.ReadInt16()), GetProperty(stream.ReadInt16()), (int)stream.ReadInt16());

                Faces.Add(tempFace);
            }

            stream.BaseStream.Position = GroupStartOffset;

            Groups = new List<Group>();

            for (int i = 0; i < GroupCount; i++)
            {
                Group tempGroup = new Group(stream, i);

                Groups.Add(tempGroup);
            }

            foreach (Face fac in Faces)
            {
                Groups[fac.GroupID].AddFace(fac);
            }
        }

        public Vector3 GetVertex(int index)
        {
            return Vertexes[index];
        }

        public SurfaceProperty GetProperty(int index)
        {
            return Properties[index];
        }
    }

    class Face
    {
        public Vector3[] Verts;

        public int GroupID;

        public SurfaceProperty FaceSurface;

        public bool InheritsParentGroupSurfaceProperty;

        public Face()
        {
            Verts = new Vector3[3] { Vector3.Zero, Vector3.Zero, Vector3.Zero };

            GroupID = 0;

            FaceSurface = new SurfaceProperty();

            InheritsParentGroupSurfaceProperty = true;
        }

        public Face(Vector3 vert1, Vector3 vert2, Vector3 vert3, int groupIndex)
        {
            Verts = new Vector3[3] { vert1, vert2, vert3 };

            GroupID = groupIndex;

            FaceSurface = new SurfaceProperty();

            InheritsParentGroupSurfaceProperty = true;
        }

        public Face(Vector3 vert1, Vector3 vert2, Vector3 vert3, SurfaceProperty property, int groupIndex)
        {
            Verts = new Vector3[3] { vert1, vert2, vert3 };

            GroupID = groupIndex;

            FaceSurface = property;

            InheritsParentGroupSurfaceProperty = true;
        }
    }

    class Group
    {
        public string Name;
        public Vector3 Scale;
        public short[] Rotation;
        public short Padding1;
        public Vector3 Translation;
        public short ParentIndex;
        public short SiblingIndex;
        public short ChildIndex;
        public short Padding2;
        public short StartingBoundingBoxVertsIndex;
        public short ReferenceTreeIndex;
        public short Unknown3;
        public byte SurfaceType;
        public byte RoomNumber;

        public List<Face> FaceList;

        public Group(EndianBinaryReader stream, int thisGroupIndex)
        {
            int streamStart = (int)stream.BaseStream.Position;

            stream.BaseStream.Position = stream.ReadInt32();

            char[] tempChars = Encoding.ASCII.GetChars(stream.ReadBytesUntil(0));

            Name = new string(tempChars);

            stream.BaseStream.Position = streamStart + 4;

            Scale.X = stream.ReadSingle();

            Scale.Y = stream.ReadSingle();

            Scale.Z = stream.ReadSingle();

            Rotation = new short[3] { stream.ReadInt16(), stream.ReadInt16(), stream.ReadInt16() };

            Padding1 = stream.ReadInt16();

            Translation.X = stream.ReadSingle();

            Translation.Y = stream.ReadSingle();

            Translation.Z = stream.ReadSingle();

            ParentIndex = stream.ReadInt16();

            SiblingIndex = stream.ReadInt16();

            ChildIndex = stream.ReadInt16();

            Padding2 = stream.ReadInt16();

            StartingBoundingBoxVertsIndex = stream.ReadInt16();

            ReferenceTreeIndex = stream.ReadInt16();

            Unknown3 = stream.ReadInt16();

            SurfaceType = stream.ReadByte();

            RoomNumber = stream.ReadByte();

            FaceList = new List<Face>();
        }

        public Group(Grendgine_Collada_Geometry geometry, int thisGroupIndex)
        {
            Name = geometry.Name;
            Scale = Vector3.Zero;
            Rotation = new short[] { 0, 0, 0 };
            Padding1 = 0;
            Translation = Vector3.Zero;
            ParentIndex = 0;
            SiblingIndex = (short)(thisGroupIndex + 1);
            ChildIndex = -1;
            Padding2 = 0;
            StartingBoundingBoxVertsIndex = 0;
            ReferenceTreeIndex = -1;
            Unknown3 = 0;
            SurfaceType = 0;
            RoomNumber = 0;

            FaceList = new List<Face>();

            float[] tempFloats = geometry.Mesh.Source[0].Float_Array.Value();

            int[] vertexIndexes = geometry.Mesh.Polylist[0].P.Value();

            List<Vector3> tempVecList = new List<Vector3>();

            for (int i = 0; i < tempFloats.Length; i+=3)
            {
                Vector3 tempVec = new Vector3(tempFloats[i], tempFloats[i + 1], tempFloats[1 + 2]);

                tempVecList.Add(tempVec);
            }

            int faceEntrySize = geometry.Mesh.Polylist[0].Input.Length * 3;

            int vertIndexOffset = geometry.Mesh.Polylist[0].Input.Length;

            for (int i = 0; i < geometry.Mesh.Polylist[0].Count; i++)
            {
                int faceOffset = i * faceEntrySize;

                Face tempFace = new Face(tempVecList[vertexIndexes[faceOffset]], tempVecList[vertexIndexes[faceOffset + vertIndexOffset]], tempVecList[vertexIndexes[faceOffset + (vertIndexOffset * 2)]], thisGroupIndex);

                FaceList.Add(tempFace);
            }
        }

        public void AddFace(Face addition)
        {
            FaceList.Add(addition);
        }
    }

    class SurfaceProperty
    {
        public byte CamID;
        public byte SoundEffect;
        public byte ExitID;
        public byte Color;

        public SurfaceProperty()
        {
            CamID = 0;
            SoundEffect = 0;
            ExitID = 0;
            Color = 0;
        }

        public SurfaceProperty(EndianBinaryReader stream)
        {
            CamID = (byte)((stream.PeekReadInt32() & 0xFF));
            SoundEffect = (byte)((stream.PeekReadInt32() & 0x1F00) >> 8);
            ExitID = (byte)((stream.PeekReadInt32() & 0x7E000) >> 0xD);
            Color = (byte)((stream.ReadInt32() & 0x7F80000) >> 0x13);

            stream.BaseStream.Position += 0xC;
        }
    }

    class ColladaFile
    {
        List<Group> Groups;

        public ColladaFile(Grendgine_Collada inputFile)
        {
            Groups = new List<Group>();

            for (int i = 0; i < inputFile.Library_Geometries.Geometry.Length; i++)
            {
                Group tempGroup = new Group(inputFile.Library_Geometries.Geometry[i], i);

                Groups.Add(tempGroup);
            }
        }
    }
}
