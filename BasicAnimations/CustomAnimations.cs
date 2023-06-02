using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using RAGENativeUI;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RAGENativeUI.Elements;

namespace BasicAnimations
{
    internal class CustomAnimations
    {
        internal static string CSharpFilePath = @"Plugins\BasicAnimations\CustomAnimations.txt";
        internal static string CSharpFileDirectory = @"Plugins\BasicAnimations\";
        internal static List<string> Animations = new List<string>();

        internal static void ReadFile()
        {
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
                string[] values = (Animations[i].Trim()).Split(',');

                UIMenuItem Custom = new UIMenuItem(values[7]);
            }
        }
    }
}
