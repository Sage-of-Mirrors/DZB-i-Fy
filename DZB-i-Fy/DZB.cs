using System.Collections.Generic;
using System.Text;
using OpenTK;
using GameFormatReader.Common;
using grendgine_collada;
using System;

namespace DZBEditor
{
    class DzbFile
    {
        List<Vector3> Vertexes;
        List<Face> Faces;
        List<Group> Groups;
        List<SurfaceProperty> Properties;

        [Obsolete("Information can be determined by Vertexes.Count")]
        int VertexCount;
        [Obsolete("Information can be determined by Faces.Count")]
        int FaceCount;
        [Obsolete("Information can be determined by Properties.Count")]
        int PropertyCount;
        [Obsolete("Information can be determined by Groups.Count")]
        int GroupCount;

        int VertexStartOffset;
        int FaceStartOffset;
        int PropertyStartOffset;
        int GroupStartOffset;

        public Vector3 GetVertex(int index)
        {
            return Vertexes[index];
        }

        public SurfaceProperty GetProperty(int index)
        {
            return Properties[index];
        }
    }

    /// <summary>
    /// This is a prime canidate for having a "CollisionFace" style file (as part of CollisionFile)
    /// which stores this information. That way the "DZB" class/file only contains fields actually
    /// relevent to the DZB file itself.
    /// </summary>
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
            // Leave comments when you do things like this. :p
            //
            // "The first 4 bytes of the Group are a pointer to the string table
            // so we store the position in the stream, go and read that string
            // and then jump back to the Group file to continue reading it."

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
            // A comment would be nice here too. I only understand it cause we had
            // the discussion today, but I could look at this tomorrow and go "wtf"
            CamID = (byte)((stream.PeekReadInt32() & 0xFF));
            SoundEffect = (byte)((stream.PeekReadInt32() & 0x1F00) >> 8);
            ExitID = (byte)((stream.PeekReadInt32() & 0x7E000) >> 0xD);
            Color = (byte)((stream.ReadInt32() & 0x7F80000) >> 0x13);

            stream.BaseStream.Position += 0xC;
        }
    }
}
