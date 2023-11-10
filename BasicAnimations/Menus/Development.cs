/*using System;
using System.Linq;
using Rage;
using Rage.Native;
using RAGENativeUI;
using RAGENativeUI.Elements;
using static BasicAnimations.Systems.Helper;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.Menus
{
    internal class Testing
    {
        private enum IkPart
        {
            IkPartInvalid = 0,
            IkPartHead = 1,
            IkPartSpine = 2,
            IkPartArmLeft = 3,
            IkPartArmRight = 4,
            IkPartLegLeft = 5,
            IkPartLegRight = 6
        }

        private enum IkTargetFlags
        {
            ItfDefault = 0,
            ItfArmTargetWrtHandbone = 1,    // arm target relative to the handbone
            ItfArmTargetWrtPointhelper = 2, // arm target relative to the pointhelper
            ItfArmTargetWrtIkhelper = 4,    // arm target relative to the ikhelper
            ItfIkTagModeNormal = 8, // use animation tags directly
            ItfIkTagModeAllow = 16, // use animation tags in ALLOW mode
            ItfIkTagModeBlock = 32, // use animation tags in BLOCK mode
            ItfArmUseOrientation = 64    // solve for orientation in addition to position
        }

        internal static float ScrollSpeed = 0.001f;
        internal static float IkXoffset = 0.0f;
        internal static float IkYoffset = 0.0f;
        internal static float IkZoffset = 0.0f;
        internal static int Ikpart = 0;
        internal static int IkPedBoneId = 0;
        internal static int IkTargetFlags = 0;
        internal static readonly UIMenuItem IkMenuOption = new UIMenuItem("Inverse Kinematics");
        internal static readonly UIMenu IkMenu = new UIMenu("Inverse Kinematics", "");
        internal static readonly UIMenuListItem ScrollingSpeed = new UIMenuListItem("Scroll Speed", "", 0.001f, 0.01f, 0.1f, 1.0f, 10.0f);
        internal static UIMenuNumericScrollerItem<float> XOffset = new UIMenuNumericScrollerItem<float>("X Offset", "X offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static UIMenuNumericScrollerItem<float> YOffset = new UIMenuNumericScrollerItem<float>("Y Offset", "Y offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static UIMenuNumericScrollerItem<float> ZOffset = new UIMenuNumericScrollerItem<float>("Z Offset", "Z offset for the IK target", -10.0f, 10.0f, ScrollSpeed);
        internal static readonly UIMenuListScrollerItem<IkPart> IkPart = new UIMenuListScrollerItem<IkPart>("IK Part", "The part of your body to use", Enum.GetValues(typeof(IkPart)).Cast<IkPart>());
        internal static readonly UIMenuListScrollerItem<PedBoneId> PedBoneId = new UIMenuListScrollerItem<PedBoneId>("PedBoneID", "The bone to target", Enum.GetValues(typeof(PedBoneId)).Cast<PedBoneId>());
        internal static readonly UIMenuListScrollerItem<IkTargetFlags> IkFlags = new UIMenuListScrollerItem<IkTargetFlags>("IK Target FLags", "", Enum.GetValues(typeof(IkTargetFlags)).Cast<IkTargetFlags>());
        internal static void TestingIk()
        {
            try
            {
                NativeFunction.Natives.SET_PED_CAN_ARM_IK(MainPlayer, true);
                NativeFunction.Natives.SET_PED_CAN_TORSO_IK(MainPlayer, true);
                Menu.DevMenu.AddItem(IkMenuOption);
                Menu.DevMenu.BindMenuToItem(IkMenu, IkMenuOption);
                Menu.MainMenuPool.Add(IkMenu);
                IkMenu.AllowCameraMovement = true;
                IkMenu.MouseControlsEnabled = false;

                IkMenu.AddItems(ScrollingSpeed, XOffset, YOffset, ZOffset, IKPart, PedBoneId, IkFlags);
                ScrollingSpeed.OnListChanged += ScrollingSpeed_OnListChanged;
                XOffset.IndexChanged += XOffset_IndexChanged;
                YOffset.IndexChanged += YOffset_IndexChanged;
                ZOffset.IndexChanged += ZOffset_IndexChanged;
                IKPart.IndexChanged += IKPart_IndexChanged;
                PedBoneId.IndexChanged += PedBoneID_IndexChanged;
                IkFlags.IndexChanged += IKFlags_IndexChanged;

                NativeFunction.Natives.SET_IK_TARGET(MainPlayer, Ikpart, MainPlayer, IkPedBoneId, new Vector3(IkXoffset, IkYoffset, IkZoffset), IKTargetFlags, -1, -1);
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
            IkXoffset = XOffset.Value;
        }

        private static void YOffset_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IkYoffset = YOffset.Value;
        }

        private static void XOffset_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IkZoffset = ZOffset.Value;
        }
        private static void IKPart_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            Ikpart = (int)IKPart.SelectedItem;
        }
        private static void PedBoneID_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IkPedBoneId = (int)PedBoneId.SelectedItem;
        }
        private static void IKFlags_IndexChanged(UIMenuScrollerItem sender, int oldIndex, int newIndex)
        {
            IKTargetFlags = (int)IkFlags.SelectedItem;
        }
    }
}*/