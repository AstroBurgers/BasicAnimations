using Rage.Native;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnimations
{
    internal class Animations
    {
        internal static bool IsActiveAnimation = false;
        internal static void SitOnGround()
        {
            //MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("anim@amb@business@bgen@bgen_no_work@"), "sit_phone_phonepickup_nowork", 5f, AnimationFlags.Loop);
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("anim@amb@business@bgen@bgen_no_work@"), "sit_phone_phoneputdown_idle_nowork", 5f, AnimationFlags.Loop); //Starting task
                IsActiveAnimation = true;
                Game.LogTrivial("Started ground sit animation");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("get_up@sat_on_floor@to_stand"), "getup_0", 5f, AnimationFlags.None); //Clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Started stand up animation");
            }

        }
        internal static void SmokingInPlace()
        {
            if (!IsActiveAnimation)
            {
                NativeFunction.Natives.x142A02425FF02BD9(EntryPoint.MainPlayer, "world_human_smoking", 0, true); //start smoking anim
                IsActiveAnimation = true;
                Game.LogTrivial("Started smoking scenario");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.Clear(); //clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped smoking scenario");
            }
        }
        internal static void KneelingAnim()
        {
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@medic@standing@kneel@enter"), "enter", 5f, AnimationFlags.None).WaitForCompletion();
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@medic@standing@kneel@base"), "base", 5f, AnimationFlags.Loop); //Starting task
                IsActiveAnimation = true;
                Game.LogTrivial("Started kneel animation");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@medic@standing@kneel@exit"), "exit", 5f, AnimationFlags.None); //Clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Started stand up animation");
            }
        }
        internal static void PushupAnim()
        {
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@enter"), "enter", 5f, AnimationFlags.None).WaitForCompletion(); //Starting task
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@base"), "base", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Pushup animation");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_push_ups@male@exit"), "exit", 5f, AnimationFlags.None); //Clearing task
                IsActiveAnimation = false;
                Game.LogTrivial("Started stand up animation");
            }
        }
        internal static void SitupAnim()
        {
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@enter"), "enter", 5f, AnimationFlags.None).WaitForCompletion();
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@base"), "base", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Sit up animation");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_sit_ups@male@exit"), "exit", 5f, AnimationFlags.None);
                IsActiveAnimation = false;
                Game.LogTrivial("Ended sit up animation");
            }
        }
    }
}