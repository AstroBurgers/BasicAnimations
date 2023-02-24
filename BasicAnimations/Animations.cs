using Rage.Native;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicAnimations
{
    internal class Animations
    {
        internal static bool IsActiveAnimation = false;
        internal static void SitOnGround() // Sitting Method start
        {
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

        } // Sitting Method end
        internal static void SmokingInPlace() // Smoking Method start
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
        } // Smoking Method end
        internal static void KneelingAnim() // Kneeling Method end
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
        } // Kneeling Method end
        internal static void PushupAnim() // Pushup Method start
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
        } // Pushup Method end
        internal static void SitupAnim() // Situp Method start
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
        } // Situp Method end
        internal static void LeanWall() // Leaning Method start
        {
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@enter"), "enter_back", 5f, AnimationFlags.None).WaitForCompletion();
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@idle_b"), "idle_e", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Started Leaning Animation");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_leaning@male@wall@back@hands_together@exit"), "exit_front", 5f, AnimationFlags.None).WaitForCompletion();
                EntryPoint.MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Stopped Leaning Animation");
            }
        } // Leaning Method end
        internal static void HandsOnBelt() // Hands on belt Method start
        {
            if (!IsActiveAnimation)
            {
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_cop_idles@male@idle_enter"), "idle_intro", 5f, AnimationFlags.None).WaitForCompletion();
                EntryPoint.MainPlayer.Tasks.PlayAnimation(new AnimationDictionary("amb@world_human_cop_idles@male@base"), "base", 5f, AnimationFlags.Loop);
                IsActiveAnimation = true;
                Game.LogTrivial("Putting hands on belt");
            }
            else
            {
                EntryPoint.MainPlayer.Tasks.Clear();
                IsActiveAnimation = false;
                Game.LogTrivial("Taking hands off belt");
            }
        } // Hands on belt Method end
    }
}