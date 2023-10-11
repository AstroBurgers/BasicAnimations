using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;
using Rage.Native;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Security.Cryptography;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;
using BasicAnimations.Systems;

namespace BasicAnimations.Menus
{
    internal class testing
    {
        internal enum IK_PART
        {
            IK_PART_INVALID = 0,
            IK_PART_HEAD,
            IK_PART_SPINE,
            IK_PART_ARM_LEFT,
            IK_PART_ARM_RIGHT,
            IK_PART_LEG_LEFT,
            IK_PART_LEG_RIGHT
        }
        internal enum IK_TARGET_FLAGS
        {
            ITF_DEFAULT = 0,
            ITF_ARM_TARGET_WRT_HANDBONE = 1,    // arm target relative to the handbone
            ITF_ARM_TARGET_WRT_POINTHELPER = 2, // arm target relative to the pointhelper
            ITF_ARM_TARGET_WRT_IKHELPER = 4,    // arm target relative to the ikhelper
            ITF_IK_TAG_MODE_NORMAL = 8, // use animation tags directly
            ITF_IK_TAG_MODE_ALLOW = 16, // use animation tags in ALLOW mode
            ITF_IK_TAG_MODE_BLOCK = 32, // use animation tags in BLOCK mode
            ITF_ARM_USE_ORIENTATION = 64    // solve for orientation in addition to position
        }

        internal static float ScrollSpeed = 0.001f;
        internal static float IK_Xoffset = 0.0f;
        internal static float IK_Yoffset = 0.0f;
        internal static float IK_Zoffset = 0.0f;
        internal static int IKPART = 0;
        internal static int IK_PedBoneID = 0;
        internal static int IKTargetFlags = 0;
        internal static readonly UIMenuItem IKMenuOption = new UIMenuItem("Inverse Kinematics");
        internal static readonly UIMenu IKMenu = new UIMenu("Inverse Kinematics", "");
        internal static readonly UIMenuListItem ScrollingSpeed = new UIMenuListItem("Scroll Speed", "", 0.001f, 0.01f, 0.1f, 1.0f, 10.0f);
        internal static UIMenuNumericScrollerItem<float> XOffset = new UIMenuNumericScrollerItem<float>("X Offset", "X offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static UIMenuNumericScrollerItem<float> YOffset = new UIMenuNumericScrollerItem<float>("Y Offset", "Y offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static UIMenuNumericScrollerItem<float> ZOffset = new UIMenuNumericScrollerItem<float>("Z Offset", "Z offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static readonly UIMenuListScrollerItem<IK_PART> IKPart = new UIMenuListScrollerItem<IK_PART>("IK Part", "The part of your body to use", Enum.GetValues(typeof(IK_PART)).Cast<IK_PART>());
        internal static readonly UIMenuListScrollerItem<PedBoneId> PedBoneID = new UIMenuListScrollerItem<PedBoneId>("PedBoneID", "The bone to target", Enum.GetValues(typeof(PedBoneId)).Cast<PedBoneId>());
        internal static readonly UIMenuListScrollerItem<IK_TARGET_FLAGS> IKFlags = new UIMenuListScrollerItem<IK_TARGET_FLAGS>("IK Target FLags", "", Enum.GetValues(typeof(IK_TARGET_FLAGS)).Cast<IK_TARGET_FLAGS>());
        internal static void TestingIK()
        {
            try
            {
                NativeFunction.Natives.SET_PED_CAN_ARM_IK(MainPlayer, true);
                NativeFunction.Natives.SET_PED_CAN_TORSO_IK(MainPlayer, true);
                Menu.DevMenu.AddItem(IKMenuOption);
                Menu.DevMenu.BindMenuToItem(IKMenu, IKMenuOption);
                Menu.MainMenuPool.Add(IKMenu);
                IKMenu.AllowCameraMovement = true;
                IKMenu.MouseControlsEnabled = false;

                IKMenu.AddItems(ScrollingSpeed, XOffset, YOffset, ZOffset, IKPart, PedBoneID, IKFlags);
                ScrollingSpeed.OnListChanged += ScrollingSpeed_OnListChanged;
                XOffset.IndexChanged += XOffset_IndexChanged;
                YOffset.IndexChanged += YOffset_IndexChanged;
                ZOffset.IndexChanged += ZOffset_IndexChanged;
                IKPart.IndexChanged += IKPart_IndexChanged;
                PedBoneID.IndexChanged += PedBoneID_IndexChanged;
                IKFlags.IndexChanged += IKFlags_IndexChanged;

                NativeFunction.Natives.SET_IK_TARGET(MainPlayer, IKPART, MainPlayer, IK_PedBoneID, new Vector3(IK_Xoffset, IK_Yoffset, IK_Zoffset), IKTargetFlags, -1, -1);
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception e)
            {
                Logger.Log(LogType.Error, e.ToString());
            }
        }

        private static void ScrollingSpeed_OnListChanged(UIMenuItem sender, int newIndex)
        {
            XOffset.Step = (float)ScrollingSpeed.SelectedValue;
            YOffset.Step = (float)ScrollingSpeed.SelectedValue;
            ZOffset.Step = (float)ScrollingSpeed.SelectedValue;
        }

        private static void ZOffset_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IK_Xoffset = XOffset.Value;
        }

        private static void YOffset_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IK_Yoffset = YOffset.Value;
        }

        private static void XOffset_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IK_Zoffset = ZOffset.Value;
        }
        private static void IKPart_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IKPART = (int)IKPart.SelectedItem;
        }
        private static void PedBoneID_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IK_PedBoneID = (int)PedBoneID.SelectedItem;
        }
        private static void IKFlags_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IKTargetFlags = (int)IKFlags.SelectedItem;
        }
    }
}