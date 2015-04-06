using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DZBEditor
{
    public partial class PropertyControl : UserControl
    {
        SurfaceProperty ActiveProp;

        EditorFace ActiveFace;

        GeoGroup ActiveGroup;

        public PropertyControl()
        {
            InitializeComponent();
        }

        public void UpdatePropUI(SurfaceProperty prop)
        {
            ActiveProp = prop;

            ActiveFace = null;

            ActiveGroup = null;

            PolyColorNum.Value = prop.Color;
            ExitIDNum.Value = prop.ExitID;
            SoundIDNum.Value = prop.SoundEffect;
            CamIDNum.Value = prop.CamID;

            LinkNoNum.Value = prop.LinkNo;
            WallIDNum.Value = prop.WallCode;
            SpecialIDNum.Value = prop.SpecialCode;
            AttribIDNum.Value = prop.AttributeCode;
            GroundIDNum.Value = prop.GroundCode;

            CamMoveBGNum.Value = prop.CamMoveBG;
            RoomCamIDNum.Value = prop.RoomCamID;
            RoomPathIDNum.Value = prop.RoomPathID;
            RoomPathPntNoNum.Value = prop.RoomPathPntNo;

            CamBehvNum.Value = prop.CameraType;
        }

        public void UpdatePropUI(SurfaceProperty prop, GeoGroup group)
        {
            ActiveProp = prop;

            ActiveFace = null;

            ActiveGroup = group;

            PolyColorNum.Value = prop.Color;
            ExitIDNum.Value = prop.ExitID;
            SoundIDNum.Value = prop.SoundEffect;
            CamIDNum.Value = prop.CamID;

            LinkNoNum.Value = prop.LinkNo;
            WallIDNum.Value = prop.WallCode;
            SpecialIDNum.Value = prop.SpecialCode;
            AttribIDNum.Value = prop.AttributeCode;
            GroundIDNum.Value = prop.GroundCode;

            CamMoveBGNum.Value = prop.CamMoveBG;
            RoomCamIDNum.Value = prop.RoomCamID;
            RoomPathIDNum.Value = prop.RoomPathID;
            RoomPathPntNoNum.Value = prop.RoomPathPntNo;

            CamBehvNum.Value = prop.CameraType;
        }

        public void UpdatePropUI(SurfaceProperty prop, EditorFace face)
        {
            ActiveProp = prop;

            ActiveFace = face;

            ActiveGroup = null;

            PolyColorNum.Value = prop.Color;
            ExitIDNum.Value = prop.ExitID;
            SoundIDNum.Value = prop.SoundEffect;
            CamIDNum.Value = prop.CamID;

            LinkNoNum.Value = prop.LinkNo;
            WallIDNum.Value = prop.WallCode;
            SpecialIDNum.Value = prop.SpecialCode;
            AttribIDNum.Value = prop.AttributeCode;
            GroundIDNum.Value = prop.GroundCode;

            CamMoveBGNum.Value = prop.CamMoveBG;
            RoomCamIDNum.Value = prop.RoomCamID;
            RoomPathIDNum.Value = prop.RoomPathID;
            RoomPathPntNoNum.Value = prop.RoomPathPntNo;

            CamBehvNum.Value = prop.CameraType;

            InheritBox.Checked = face.InheritsParentSurface;
        }

        public void UpdateProperty()
        {
            if (ActiveProp == null)
                return;

            SurfaceProperty newProp = new SurfaceProperty(this);

            if (!newProp.Compare(ActiveProp))
                return;

            if (newProp.CamID != ActiveProp.CamID)
                ActiveProp.CamID = newProp.CamID;

            if (newProp.Color != ActiveProp.Color)
                ActiveProp.Color = newProp.Color;

            if (newProp.ExitID != ActiveProp.ExitID)
                ActiveProp.ExitID = newProp.ExitID;

            if (newProp.LinkNo != ActiveProp.LinkNo)
                ActiveProp.LinkNo = newProp.LinkNo;

            if (newProp.WallCode != ActiveProp.WallCode)
                ActiveProp.WallCode = newProp.WallCode;

            if (newProp.SpecialCode != ActiveProp.SpecialCode)
                ActiveProp.SpecialCode = newProp.SpecialCode;

            if (newProp.AttributeCode != ActiveProp.AttributeCode)
                ActiveProp.AttributeCode = newProp.AttributeCode;

            if (newProp.GroundCode != ActiveProp.GroundCode)
                ActiveProp.GroundCode = newProp.GroundCode;

            if (newProp.CamMoveBG != ActiveProp.CamMoveBG)
                ActiveProp.CamMoveBG = newProp.CamMoveBG;

            if (newProp.RoomCamID != ActiveProp.RoomCamID)
                ActiveProp.RoomCamID = newProp.RoomCamID;

            if (newProp.RoomPathID != ActiveProp.RoomPathID)
                ActiveProp.RoomPathID = newProp.RoomPathID;

            if (newProp.RoomPathPntNo != ActiveProp.RoomPathPntNo)
                ActiveProp.RoomPathPntNo = newProp.RoomPathPntNo;

            if (newProp.CameraType != ActiveProp.CameraType)
                ActiveProp.CameraType = newProp.CameraType;
        }

        private void CheckSetNumericToZero(object sender, EventArgs e)
        {
            NumericUpDown numericSender = sender as NumericUpDown;

            if (numericSender.Text == "")
            {
                numericSender.Text = "0";
                numericSender.Value = 0;
            }
        }

        public void EnableFields()
        {
            CamIDNum.Enabled = true;
            ExitIDNum.Enabled = true;
            PolyColorNum.Enabled = true;
            SoundIDNum.Enabled = true;

            LinkNoNum.Enabled = true;
            WallIDNum.Enabled = true;
            SpecialIDNum.Enabled = true;
            GroundIDNum.Enabled = true;
            AttribIDNum.Enabled = true;

            CamMoveBGNum.Enabled = true;
            RoomCamIDNum.Enabled = true;
            RoomPathIDNum.Enabled = true;
            RoomPathPntNoNum.Enabled = true;

            CamBehvNum.Enabled = true;

            CopyPropButton.Enabled = true;
            PastePropButton.Enabled = true;

            AllInheritToggle.Enabled = true;
        }

        public void DisableFields()
        {
            CamIDNum.Enabled = false;
            ExitIDNum.Enabled = false;
            PolyColorNum.Enabled = false;
            SoundIDNum.Enabled = false;

            LinkNoNum.Enabled = false;
            WallIDNum.Enabled = false;
            SpecialIDNum.Enabled = false;
            GroundIDNum.Enabled = false;
            AttribIDNum.Enabled = false;

            CamMoveBGNum.Enabled = false;
            RoomCamIDNum.Enabled = false;
            RoomPathIDNum.Enabled = false;
            RoomPathPntNoNum.Enabled = false;

            CamBehvNum.Enabled = false;

            CopyPropButton.Enabled = false;
            PastePropButton.Enabled = false;

            AllInheritToggle.Enabled = false;
        }
        
        public void HideInheritCheckbox()
        {
            InheritBox.Hide();
        }

        public void ShowInheritCheckbox()
        {
            InheritBox.Show();
        }

        public void HideToggleAllInherit()
        {
            AllInheritToggle.Hide();
        }

        public void ShowToggleAllInherit()
        {
            AllInheritToggle.Show();
        }

        private void InheritBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveFace == null)
                return;

            CheckBox box = sender as CheckBox;

            if (box.Checked)
                ActiveFace.InheritsParentSurface = true;

            else
                ActiveFace.InheritsParentSurface = false;
        }

        private void CopyPropButton_Click(object sender, EventArgs e)
        {
            if (ActiveProp == null)
            {
                MessageBox.Show("There is no property data to copy.");
                return;
            }

            Clipboard.SetData("SurfaceProperty", ActiveProp.Copy());
        }

        private void PastePropButton_Click(object sender, EventArgs e)
        {
            PasteProp();
        }

        private void PasteProp()
        {
            if (!Clipboard.ContainsData("SurfaceProperty"))
            {
                MessageBox.Show("There is no property data to paste.");
                return;
            }

            SurfaceProperty actualProp = Clipboard.GetData("SurfaceProperty") as SurfaceProperty;

            if (actualProp == null)
                return;

            if (ActiveFace == null)
            {
                ActiveGroup.DefaultSurface = actualProp.Copy();

                UpdatePropUI(ActiveGroup.DefaultSurface, ActiveGroup);
            }

            if (ActiveGroup == null)
            {
                ActiveFace.FaceSurface = actualProp.Copy();

                UpdatePropUI(ActiveFace.FaceSurface, ActiveFace);
            }
        }

        private void AllInheritToggle_Click(object sender, EventArgs e)
        {
            foreach (EditorFace face in ActiveGroup.Faces)
            {
                face.InheritsParentSurface = true;
            }
        }
    }
}
