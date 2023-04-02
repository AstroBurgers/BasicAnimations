using Rage.Native;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BasicAnimations.EntryPoint;
using static BasicAnimations.Animations;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Drawing;
using System.Security.Policy;

namespace BasicAnimations
{
    internal class Animations
    {
        // Confusing spaghetti code :KEKW:
        internal static bool IsActiveAnimationPlaying = false;
        internal static Action ActiveAnimation = null;
        internal static Rage.Object Box = new Rage.Object(new Model("prop_cs_cardbox_01"), Vector3.Zero, 0f);

        internal static void PlayAction(AnimationSequence animationSequence) //Animations
        {
            if (CheckRequirements())
            {
                EndAction(ActiveAnimation);
                animationSequence.Play();
                IsActiveAnimation = true;
                ActiveAnimation = animationSequence;
                Game.LogTrivial($"Started {animationSequence.MenuName}");
            }
        }
        
        internal static void PlayAction(Action action) // Scenarios
        {
            if(CheckRequirements())
            {
                EndAction(ActiveAnimation);
                action.Play();
                IsActiveAnimation = true;
                ActiveAnimation = action;
                Game.LogTrivial($"Started {action.MenuName}");
            }

        }


        internal static void EndAction(Action action)
        {
            if (CheckRequirements() && (ActiveAnimation != null))
            {
                action.PlayEndAnimation(); 
                IsActiveAnimation = false;
                ActiveAnimation = null;
                Game.LogTrivial($"Stopped {action.MenuName}");
            }
        }
        
        

        internal static List<Action> actions = new List<Action>()
        {
            new Scenario(MainPlayer, "world_human_yoga", 0, true, "Yoga", "STREEETCH"), // Yoga
            new Scenario(MainPlayer, "world_human_smoking", 0, true, "Smoking", "Plays smoking animation"), // Smoking
            new Scenario(MainPlayer, "code_human_medic_kneel", 0, true, "Kneel", "Plays kneeling animation"), // Kneeling
            new Scenario(MainPlayer, "world_human_leaning", 0, true, "Leaning", "Plays leaning animation"),
            new Scenario(MainPlayer, "world_human_binoculars", 0, true, "Binoculars", "Pull out some binoculars"),
            new Scenario(MainPlayer, "world_human_paparazzi", 0, true, "Camera", "Pull out a camera"),

            new AnimationSequence(
                new Animation(new AnimationDictionary("amb@world_human_push_ups@male@enter"), "enter", 5f,
                    AnimationFlags.StayInEndFrame, false, true, 3500, "Pushups", "Plays pushup animation"),

                new Animation(new AnimationDictionary("amb@world_human_push_ups@male@base"), "base", 5f,
                    AnimationFlags.Loop, false, false, 0, "MenuName", "MenuDescription"),

                new Animation(new AnimationDictionary("amb@world_human_push_ups@male@exit"), "exit", 5f,
                    AnimationFlags.None, false, false, 0, "MenuName", "MenuDescription")
                ),


            new AnimationSequence(
                    new Animation(new AnimationDictionary("amb@world_human_sit_ups@male@enter"), "enter", 5f,
                        AnimationFlags.StayInEndFrame, false, true, 3000, "Situps", "Plays the situp animation"),

                    new Animation(new AnimationDictionary("amb@world_human_sit_ups@male@base"), "base", 5f,
                        AnimationFlags.Loop, false, false, 0, "MenuName", "MenuDescription"),

                    new Animation(new AnimationDictionary("amb@world_human_sit_ups@male@exit"), "exit", 5f,
                        AnimationFlags.None,false, false, 0, "MenuName", "MenuDescription")
                    ),
                
            new AnimationSequence(
                    new Animation(new AnimationDictionary("anim@amb@business@bgen@bgen_no_work@"), "sit_phone_phoneputdown_idle_nowork", 5f,
                        AnimationFlags.Loop, true, false, 0, "Sit", "Plays sitting animation"),
                    null,
                    new Animation(new AnimationDictionary("get_up@sat_on_floor@to_stand"), "getup_0", 5f,
                    AnimationFlags.None, false, false, 0, "MenuName", "MenuDescription")
                    ),
            
            new AnimationSequence(
                    new Animation(new AnimationDictionary("amb@world_human_cop_idles@male@idle_enter"), "idle_intro", 5f,
                        AnimationFlags.None, true, false, 0, "Hands On Belt", "Puts your hands on your belt"),
                    null,
                    new Animation(new AnimationDictionary("amb@world_human_cop_idles@male@base"), "base", 5f,
                        AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop, false, false, 0, "MenuName", "MenuDescription")
                    ),
            
            new AnimationSequence(
                    new Animation(new AnimationDictionary("amb@world_human_hiker_standing@male@base"), "base", 5f,
                    AnimationFlags.Unknown65536 | AnimationFlags.UpperBodyOnly | AnimationFlags.SecondaryTask | AnimationFlags.Loop, false, false, 0, "Grab Vest", "Puts your hands on your vest"),
                    null,
                    null
                ),
            
            new AnimationSequence(
                    new Animation(new AnimationDictionary("mp_player_int_uppersalute"), "mp_player_int_salute_enter", 5f,
                        AnimationFlags.StayInEndFrame, false, true, 2000, "Salute", "Plays Saluting animation"),
                    new Animation(new AnimationDictionary("mp_player_int_uppersalute"), "mp_player_int_salute", 5f,
                        AnimationFlags.Loop, false, false, 0, "MenuName", "MenuDescription"),
                    null
                ),
            
            new AnimationSequence(
                    new Animation(new AnimationDictionary("anim@mp_player_intcelebrationfemale@thumb_on_ears"), "thumb_on_ears", 5f,
                        AnimationFlags.Loop, false, false, 0, "Mocking", "Plays Mocking animation"),
                    null,
                    null
                ),
        };
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
        internal static void KeybindPlayAnimation(string menuName)
        {
            PlayAction(actions.Where(i => i.MenuName.Equals(menuName)).ToList()[0]);
        }
    }
}