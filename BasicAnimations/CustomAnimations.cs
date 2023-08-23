/*using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System;
using System.Collections.Generic;
using System.IO;

namespace BasicAnimations
{
    internal class CustomAnimations
    {
        internal static string CSharpFilePath = @"Plugins\BasicAnimations\CustomAnimations.txt";
        internal static string CSharpFileDirectory = @"Plugins\BasicAnimations\";
        internal static List<string> Animations = new List<string>();
        internal static List<Animation> AnimList = new List<Animation>();

        internal static void ReadFile()
        {
            ValidateFile();
            SelectionHandler();
            using (FileStream fileStream = new FileStream(CSharpFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // Read the file content
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    // Loop through the lines and split each line into an array
                    while (!reader.EndOfStream)
                    {
                        Animations.Add(reader.ReadLine());
                    }
                }
            }

            for (int i = 0; i < Animations.Count; i++)
            {
                if (Animations[i].Equals(""))
                {
                    Game.LogTrivial($"Line Number {i + 1} was invalid. Skipping line.");
                    continue;
                }
                try
                {
                    string[] values = (Animations[i].Trim()).Split(',');
                    SetToNull(values);
                    Game.LogTrivial("Parsing lines...");
                    Game.LogTrivial($"Current Line: {i}");
                    Game.LogTrivial($"Items at line {i + 1} : {values[0]}, {values[1]}, {values[2]}, {values[3]}, {values[4]}, {values[5]}, {values[6]}");
                    Game.LogTrivial($"Creating UIMenuItem with name {values[6]}");
                    UIMenuItem Custom = new UIMenuItem(values[6]);
                    Game.LogTrivial($"Adding Menu item {values[6]}");
                    Menu.CustomAnims.AddItems(Custom);
                    Animation Anim = new Animation(values[0], values[1], values[2], values[3], values[4], values[5]);
                    AnimList.Add(Anim);
                    Game.LogTrivial($"Added Menu item {values[6]}");
                }
                catch (Exception e)
                {
                    string Error = e.ToString();
                    Game.LogTrivial($"Error line {i + 1} Does not contain All parameters");
                    Game.LogTrivial(Error);
                }
            }
        }

        internal static void ValidateFile()
        {
            if (!File.Exists(CSharpFilePath))
            {
                Game.LogTrivial($"File {CSharpFilePath} does not exsist, creating");
                File.Create(CSharpFilePath);
            }
            if (!Directory.Exists(CSharpFileDirectory))
            {
                Game.LogTrivial($"File {CSharpFileDirectory} does not exsist, creating");
                Directory.CreateDirectory(CSharpFileDirectory);
            }
        }

        internal static void SetToNull(string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == "null")
                {
                    values[i] = null;
                }
            }
        }

        internal static void SelectionHandler()
        {
            Menu.CustomAnims.OnItemSelect += CustomAnims_OnItemSelect;
        }

        private static void CustomAnims_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            AnimList[index].PlayIntroAnim();
            AnimList[index].PlayMainAnimation();
        }
    }
}
*/