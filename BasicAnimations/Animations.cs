using BasicAnimations.Animation_Classes;
using Rage;
using Rage.Native;
using System;
using static BasicAnimations.Systems.Helper;

namespace BasicAnimations
{
    internal class Animations
    {
        // Confusing spaghetti code :KEKW:
        internal static Rage.Object Box = new Rage.Object(new Model("prop_cs_cardbox_01"), Vector3.Zero, 0f);

        internal static Animation Sit = new Animation("anim@amb@business@bgen@bgen_no_work@", "sit_phone_phoneputdown_idle_nowork", String.Empty, String.Empty,  "get_up@sat_on_floor@to_stand", "getup_0", true);
        internal static Animation Pushup = new Animation("amb@world_human_push_ups@male@enter", "enter", "amb@world_human_push_ups@male@base", "base", "amb@world_human_push_ups@male@exit", "exit", true, true, 3500, AnimationStage.Start);
        internal static Animation Situp = new Animation("amb@world_human_sit_ups@male@enter", "enter", "amb@world_human_sit_ups@male@base", "base", "amb@world_human_sit_ups@male@exit", "exit", true, true, 3000, AnimationStage.Start);
        internal static Animation GrabBelt = new Animation("amb@world_human_cop_idles@male@idle_enter", "idle_intro", "amb@world_human_cop_idles@male@base", "base", String.Empty, String.Empty, true);
        internal static Animation GrabVest = new Animation("amb@world_human_hiker_standing@male@base", "base", String.Empty, String.Empty,  String.Empty, String.Empty, true);
        internal static Animation Salute = new Animation("mp_player_int_uppersalute", "mp_player_int_salute_enter", "mp_player_int_uppersalute", "mp_player_int_salute", "mp_player_int_uppersalute", "mp_player_int_salute_Exit", true, true, 2000, AnimationStage.Start);
        internal static Animation Mocking = new Animation("anim@mp_player_intcelebrationfemale@thumb_on_ears", "thumb_on_ears", String.Empty, String.Empty,  String.Empty, String.Empty, true);

        internal static Scenario Smoking = new Scenario("world_human_smoking");
        internal static Scenario Kneeling = new Scenario("code_human_medic_kneel");
        internal static Scenario Lean = new Scenario("world_human_leaning");
        internal static Scenario Yoga = new Scenario("world_human_yoga");
        internal static Scenario Binoculars = new Scenario("world_human_binoculars");
        internal static Scenario Camera = new Scenario("world_human_paparazzi");
        internal static Scenario Investigate = new Scenario("code_human_police_investigate");

        internal static void Suicide()
        {
            if (IsAnimationActive || !CheckRequirements()) { return; }
            MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("mp_suicide"), "pill", 5f, AnimationFlags.None);
            GameFiber.Wait(2500);
            MainPlayer.Kill();
            Game.LogTrivial("Played Suicide animation (Killed player most likely)");
            IsAnimationActive = false;
        }

        internal static void CarryBox()
        {
            // 0x6B9BBD38AB0796DF ATTACH_ENTITY_TO_ENTITY
            if (!IsAnimationActive && CheckRequirements())
            {
                try
                {
                    if (!Box.Exists())
                    {
                        Box = new Rage.Object(new Model("prop_cs_cardbox_01"), Vector3.Zero, 0f);
                    }
                    else if (Box.Exists())
                    {
                        MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("anim@heists@box_carry@"), "idle", 5f, AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop);
                        GameFiber.Wait(175);
                        int Handbone = NativeFunction.Natives.GET_PED_BONE_INDEX<int>(MainPlayer, (int)PedBoneId.RightPhHand);
                        NativeFunction.Natives.ATTACH_ENTITY_TO_ENTITY(Box, MainPlayer, Handbone, -0.0100f, -0.0300f, 0.0000f, 0f, 0f, 0f, true, true, false, true, 2, 1);
                        IsAnimationActive = true;
                    }
                }
                catch (Exception e)
                {
                    Systems.Logging.Logger.LogException("Animations.cs - CarryBox", e.ToString());
                }
            }
            else
            {
                MainPlayer.Tasks.Clear();
                Box.Detach();
                GameFiber.Wait(1);
                Box.Position = new Vector3(0f, 0f, 0f);
                IsAnimationActive = false;
            }
        }
    }
}