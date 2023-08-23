using Rage;
using Rage.Native;
using System;
using static BasicAnimations.EntryPoint;
using static BasicAnimations.Animation_Classes.Animation;
using static BasicAnimations.Systems.Helper;
    
namespace BasicAnimations
{
    internal class Animations
    {
        // Confusing spaghetti code :KEKW:
        internal static bool IsActiveAnimation = false;
        internal static Rage.Object Box = new Rage.Object(new Model("prop_cs_cardbox_01"), Vector3.Zero, 0f);

        Animation_Classes.Animation Sit = new Animation_Classes.Animation(String.Empty, String.Empty, "anim@amb@business@bgen@bgen_no_work@", "sit_phone_phoneputdown_idle_nowork", "get_up@sat_on_floor@to_stand", "getup_0", true);

        internal static void SmokingInPlace() // Smoking Method start
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "world_human_smoking", 0, true); //start smoking anim
                IsActiveAnimation = true;
                Game.LogTrivial("Started smoking scenario");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.ClearImmediately(); //clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped smoking scenario");
            }
        } // Smoking Method end
        internal static void KneelingAnim() // Kneeling Method end
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                NativeFunction.Natives.x142A02425FF02BD9(MainPlayer, "code_human_medic_kneel", 0, true); // TASK_START_SCENARIO_IN_PLACE
                IsActiveAnimation = true;
                Game.LogTrivial("Started kneeling animation");
            }
            else
            {
                //NativeFunction.Natives.SET_PED_SHOULD_PLAY_IMMEDIATE_SCENARIO_EXIT(MainPlayer);
                MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped kneeling animation");
            }
        } // Kneeling Method end
        internal static void PushupAnim() // Pushup Method start
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@enter"), "enter", 5f, AnimationFlags.StayInEndFrame).WaitForStatus(TaskStatus.NoTask, 3500); //Starting task
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@base"), "base", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Pushup animation");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@exit"), "exit", 5f, AnimationFlags.None); //Clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Started stand up animation");
            }
        } // Pushup Method end
        internal static void SitupAnim() // Situp Method start
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@enter"), "enter", 5f, AnimationFlags.StayInEndFrame).WaitForStatus(TaskStatus.NoTask, 3000);
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@base"), "base", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Sit up animation");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@exit"), "exit", 5f, AnimationFlags.None);
                IsActiveAnimation = false;
                Game.LogTrivial("Ended sit up animation");
            }
        } // Situp Method end
        internal static void LeanWall() // Leaning Method start
        {
            if (!IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@enter"), "enter_back", 5f, AnimationFlags.StayInEndFrame).WaitForStatus(TaskStatus.NoTask, 5000);
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@idle_b"), "idle_e", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Leaning Animation");
            }
            else if (IsActiveAnimation && CheckRequirements())
            {
                MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@exit"), "exit_front", 5f, AnimationFlags.None).WaitForCompletion();
                MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Leaning Animation");
            }
        } // Leaning Method end
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