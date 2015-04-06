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
    public partial class GroupControl : UserControl
    {
        IGroup ActiveGroup;

        public GroupControl()
        {
            InitializeComponent();
        }

        public void UpdateGroupUI(IGroup group)
        {
            ActiveGroup = group;

            NameBox.Text = group.Name;

            ScaleX.Value = (decimal)group.Scale.X;
            ScaleY.Value = (decimal)group.Scale.Y;
            ScaleZ.Value = (decimal)group.Scale.Z;

            RotX.Value = (decimal)group.Rotation[0];
            RotZ.Value = (decimal)group.Rotation[1];
            RotY.Value = (decimal)group.Rotation[2];

            TransX.Value = (decimal)group.Translation.X;
            TransY.Value = (decimal)group.Translation.Y;
            TransZ.Value = (decimal)group.Translation.Z;

            TerrainTypeBox.SelectedIndex = group.SurfaceType;

            RoomNo.Value = group.RoomNumber;
        }

        public void UpdateGroup()
        {
            if (ActiveGroup == null)
                return;

            IGroup newGroup = ActiveGroup.LoadDataFromControl(this);

            if (newGroup.Compare(ActiveGroup))
                return;

            if (newGroup.Name != ActiveGroup.Name)
                ActiveGroup.Name = newGroup.Name;

            if (newGroup.SurfaceType != ActiveGroup.SurfaceType)
                ActiveGroup.SurfaceType = newGroup.SurfaceType;

            if (newGroup.RoomNumber != ActiveGroup.RoomNumber)
                ActiveGroup.RoomNumber = newGroup.RoomNumber;
        }

        public void EnableFields()
        {
            NameBox.Enabled = true;

            TerrainTypeBox.Enabled = true;

            RoomNo.Enabled = true;
        }

        public void DisableFields()
        {
            NameBox.Enabled = false;

            TerrainTypeBox.Enabled = false;

            RoomNo.Enabled = false;
        }
    }
}
