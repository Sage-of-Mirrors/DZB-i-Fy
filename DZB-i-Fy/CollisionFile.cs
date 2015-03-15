using GameFormatReader.Common;
using grendgine_collada;
using OpenTK;
using System.Collections.Generic;
using System.Text;

namespace DZBEditor
{
    /// <summary>
    /// The idea behind having a "generic" file type that describes a CollisionFile is as follows.
    /// If you only worked with DZB file structures, you'd either be required to make all additions
    /// and changes fit into the original DZB file structure organization. This could be quite complex
    /// and would make your code dreadful to work with because you'd basically be stuck putting it
    /// in and out of their format every time you wanted to make an operation on the file.
    /// 
    /// If you chose Collada as your structure organization, you'd have the same issue, plus you'd be
    /// tied to some third party propietary model format that probably isn't organized how you want it either.
    /// 
    /// Enter <see cref="CollisionFile"/>. You're now in control of how you want to organize the data in the editor.
    /// Think it's best to have a list of triangles for everything? Bam, stick that in CollisionFile. Couldn't really
    /// do that in either the DZB file or the DAE file now could you.
    /// </summary>
    public class CollisionFile
    {
        private List<Face> m_collisionFaces;
        private List<Group> m_collisionGroups;

        public void LoadFromDZBFile(EndianBinaryReader stream)
        {
            // We're going to read the information out of the DZB file, but we don't actually
            // store it in the CollisionFile itself, because once this information is extracted
            // and used to extract other data, we don't care about it anymore and it can be
            // reconstructed later.
            int vertexCount = stream.ReadInt32();
            int vertexStartOffset = stream.ReadInt32();

            int faceCount = stream.ReadInt32();
            int faceStartOffset = stream.ReadInt32();

            // Why are we skipping to 0x20 without warning? Is it skipping over padding on the
            // end of the header? A comment should probably outline the 'why' of skipping.
            stream.BaseStream.Position = 0x20;

            int groupCount = stream.ReadInt32();
            int groupStartOffset = stream.ReadInt32();

            int propertyCount = stream.ReadInt32();
            int propertyStartOffset = stream.ReadInt32();

            List<Vector3> vertexes = new List<Vector3>();

            for (int i = 0; i < vertexCount; i++)
            {
                Vector3 tempVec = new Vector3(stream.ReadSingle(), stream.ReadSingle(), stream.ReadSingle());
                vertexes.Add(tempVec);
            }

            List<SurfaceProperty> properties = new List<SurfaceProperty>();

            stream.BaseStream.Position = propertyStartOffset;

            for (int i = 0; i < propertyCount; i++)
            {
                SurfaceProperty tempProp = new SurfaceProperty(stream);

                properties.Add(tempProp);
            }

            m_collisionFaces = new List<Face>();
            stream.BaseStream.Position = faceStartOffset;

            for (int i = 0; i < faceCount; i++)
            {
                Face tempFace = new Face(vertexes[stream.ReadInt16()], vertexes[stream.ReadInt16()], vertexes[stream.ReadInt16()], properties[stream.ReadInt16()], (int)stream.ReadInt16());

                m_collisionFaces.Add(tempFace);
            }

            stream.BaseStream.Position = groupStartOffset;

            m_collisionGroups = new List<Group>();

            for (int i = 0; i < groupCount; i++)
            {
                Group tempGroup = new Group(stream, i);

                m_collisionGroups.Add(tempGroup);
            }

            foreach (Face fac in m_collisionFaces)
            {
                m_collisionGroups[fac.GroupID].AddFace(fac);
            }
        }

        public void LoadFromCollada(string filePath)
        {
            Grendgine_Collada collada = Grendgine_Collada.Grendgine_Load_File(filePath);
            m_collisionGroups = new List<Group>();

            for (int i = 0; i < collada.Library_Geometries.Geometry.Length; i++)
            {
                Group tempGroup = new Group(collada.Library_Geometries.Geometry[i], i);

                m_collisionGroups.Add(tempGroup);
            }
        }
    }
}
