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
        internal static bool IsActiveAnimation = false;
        internal static Rage.Object Box = new Rage.Object(new Model("prop_cs_cardbox_01"), Vector3.Zero, 0f);

        Animation Sit = new Animation(String.Empty, String.Empty, "anim@amb@business@bgen@bgen_no_work@", "sit_phone_phoneputdown_idle_nowork", "get_up@sat_on_floor@to_stand", "getup_0", true, false, 0, AnimationStage.None);
        Animation Pushup = new Animation("amb@world_human_push_ups@male@enter", "enter", "amb@world_human_push_ups@male@base", "base", "amb@world_human_push_ups@male@exit", "exit", true, true, 3500, AnimationStage.Start);
        Animation Situp = new Animation("amb@world_human_sit_ups@male@enter", "enter", "amb@world_human_sit_ups@male@base", "base", "amb@world_human_sit_ups@male@exit", "exit", true, true, 3000, AnimationStage.Start);

        Scenario Smoking = new Scenario("world_human_smoking");
        Scenario Kneeling = new Scenario("code_human_medic_kneel");
        Scenario Leaning = new Scenario("world_human_leaning");
        internal static void HandsOnBelt() // Hands on belt Method start
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_cop_idles@male@idle_enter"), "idle_intro", 5f, AnimationFlags.None).WaitForCompletion();
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_cop_idles@male@base"), "base", 5f, AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Putting hands on belt");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Taking hands off belt");
            }
        } // Hands on belt Method end
        internal static void Suicide()
        {

            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("mp_suicide"), "pill", 5f, AnimationFlags.None);
                GameFiber.Wait(2500);
                MainPlayer.Kill();
                Game.LogTrivial("Played Suicide animation (Killed player most likely)");
                IsActiveAnimation = false;
            }
        }
        internal static void GrabVest()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_hiker_standing@male@base"), "base", 5f, AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started hands on vest animation");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped hands on vest animation");
            }
        }
        internal static void Saluting()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("mp_player_int_uppersalute"), "mp_player_int_salute_enter", 5f, AnimationFlags.StayInEndFrame).WaitForStatus(TaskStatus.NoTask, 2000);
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("mp_player_int_uppersalute"), "mp_player_int_salute", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started salute animation");
            }
            else
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("mp_player_int_uppersalute"), "mp_player_int_salute_Exit", 5f, AnimationFlags.None);
                Game.LogTrivial("Ended salute animation");
                IsActiveAnimation = false;
            }
        }
        internal static void Mocking()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("anim@mp_player_intcelebrationfemale@thumb_on_ears"), "thumb_on_ears", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started mocking animation");
            }
            else
            {
                MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped mocking animation");
            }
        }
        internal static void Lean2()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "world_human_leaning", 0, true);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Lean2 animation");
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Lean2 animation");
            }
        }
        internal static void CarryBox()
        {
            // 0x6B9BBD38AB0796DF ATTACH_ENTITY_TO_ENTITY
            if (!IsActiveAnimation && CheckRequirements())
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
                        IsActiveAnimation = true;
                    }
                }
                catch (Exception e)
                {
                    Game.LogTrivial("" + e);
                }
            }
            else
            {
                MainPlayer.Tasks.Clear();
                Box.Detach();
                GameFiber.Wait(1);
                Box.Position = new Vector3(0f, 0f, 0f);
                IsActiveAnimation = false;
            }
        }
        internal static void Yoga()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "world_human_yoga", 0, true);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Yoga animation");
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Yoga animation");
            }
        }
        internal static void Binoculars()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "world_human_binoculars", 0, true);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Binoculars animation");
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Binoculars animation");
            }
        }
        internal static void Camera()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "world_human_paparazzi", 0, true);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Camera animation");
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Camera animation");
            }
        }
        internal static void Investigate()
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "code_human_police_investigate", 0, true);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Investigate animation");
            }
            else
            {
                MainPlayer.Tasks.ClearImmediately();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Investigate animation");
            }
        }
    }
}