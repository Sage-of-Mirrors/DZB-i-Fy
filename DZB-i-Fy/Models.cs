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
        public ParentGroup Root;

        List<Vector3> Vertexes;
        List<EditorFace> Faces;
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

            stream.BaseStream.Position = 0x34;

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

            Faces = new List<EditorFace>();

            stream.BaseStream.Position = FaceStartOffset;

            for (int i = 0; i < FaceCount; i++)
            {
                EditorFace face = new EditorFace(Vertexes[stream.ReadInt16()], Vertexes[stream.ReadInt16()], Vertexes[stream.ReadInt16()]);

                face.FaceSurface = Properties[stream.ReadInt16()].Copy();

                face.GroupIndex = stream.ReadInt16();

                Faces.Add(face);
            }

            stream.BaseStream.Position = GroupStartOffset;

            Root = new ParentGroup(stream);

            for (int i = 1; i < GroupCount; i++)
            {
                int groupStartPos = (int)stream.BaseStream.Position;

                stream.BaseStream.Position += 0x24;

                short parentTest = stream.ReadInt16();

                stream.BaseStream.Position += 0x8;
                
                short geomTest = stream.ReadInt16();

                stream.BaseStream.Position = groupStartPos;

                if (geomTest >= 0)
                {
                    GeoGroup geo = new GeoGroup(stream);

                    foreach (EditorFace face in Faces)
                    {
                        if (face.GroupIndex == i)
                        {
                            geo.Faces.Add(face);
                        }
                    }

                    ParentGroup tempheh = Root.ChildGroups[geo.ParentIndex - 1] as ParentGroup;

                    tempheh.ChildGroups.Add(geo);
                }

                else if (geomTest == -1)
                {
                    if (parentTest == 0)
                    {
                        ParentGroup par = new ParentGroup(stream);

                        Root.ChildGroups.Add(par);
                    }

                    else
                    {
                        GeoGroup geo = new GeoGroup(stream);

                        foreach (EditorFace face in Faces)
                        {
                            if (face.GroupIndex == i)
                            {
                                geo.Faces.Add(face);
                            }
                        }

                        ParentGroup tempheh = Root.ChildGroups[geo.ParentIndex - 1] as ParentGroup;

                        tempheh.ChildGroups.Add(geo);
                    }
                }
            }
        }
    }

    class ColladaFile
    {
        public ParentGroup Root;

        public ColladaFile(Grendgine_Collada inputFile, string fileName)
        {
            Root = new ParentGroup();

            Root.Name = fileName;

            for (int i = 0; i < inputFile.Library_Geometries.Geometry.Length; i++)
            {
                ParentGroup parentGroup = new ParentGroup();

                parentGroup.Name = inputFile.Library_Geometries.Geometry[i].Name + "_parent";

                List<Vector3> verts = GetVerts(inputFile.Library_Geometries.Geometry[i]);

                int skipValue = CalcSkipValue(inputFile.Library_Geometries.Geometry[i]);

                GeoGroup geo = new GeoGroup();

                geo.Name = inputFile.Library_Geometries.Geometry[i].Name;

                int[] pList = inputFile.Library_Geometries.Geometry[i].Mesh.Polylist[0].P.Value();

                List<int> vertIndexes = GetVertIndexes(pList, skipValue);

                for (int j = 0; j < vertIndexes.Count; j += 3)
                {
                    EditorFace face = new EditorFace(verts[vertIndexes[j]], verts[vertIndexes[j + 1]], verts[vertIndexes[j + 2]]);

                    geo.Faces.Add(face);
                }

                parentGroup.ChildGroups.Add(geo);

                Root.ChildGroups.Add(parentGroup);
            }
        }

        private List<Vector3> GetVerts(Grendgine_Collada_Geometry source)
        {
            float[] positions = source.Mesh.Source[0].Float_Array.Value();

            List<Vector3> verts = new List<Vector3>();

            for (int i = 0; i < positions.Length; i += 3)
            {
                Vector3 tempVec = new Vector3(positions[i], positions[i + 1], positions[i + 2]);

                //Blender's axes are different from what they are in OpenGL. This is a hardcoded fix for that, but it will probably have
                //to get changed since the user might want to use a model exported from a program with the correct axes.aaxxa
                float y = tempVec.Y;

                float z = tempVec.Z;

                tempVec.Y = z;

                tempVec.Z = -y;

                verts.Add(tempVec);
            }

            return verts;
        }

        private List<int> GetVertIndexes(int[] pList, int skip)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < pList.Length / skip; i++)
            {
                indexes.Add(pList[i * skip]);
            }

            return indexes;
        }

        private int CalcSkipValue(Grendgine_Collada_Geometry source)
        {
            int skipVal = 0;

            for (int i = 0; i < source.Mesh.Polylist[0].Input.Length; i++)
            {
                switch (source.Mesh.Polylist[0].Input[i].Semantic)
                {
                    case Grendgine_Collada_Input_Semantic.VERTEX:
                        skipVal += 1;
                        break;
                    case Grendgine_Collada_Input_Semantic.NORMAL:
                        skipVal += 1;
                        break;
                    case Grendgine_Collada_Input_Semantic.TEXCOORD:
                        skipVal += 1;
                        break;
                }
            }

            return skipVal;
        }
    }
}
