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
using System.Windows.Markup;

namespace BasicAnimations
{
    internal class CustomAnimations
    {
        internal static string CSharpFilePath = @"Plugins\BasicAnimations\CustomAnimations.txt";
        internal static string CSharpFileDirectory = @"Plugins\BasicAnimations\";
        internal static List<string> Animations = new List<string>();

        internal static void ReadFile()
        {
            ValidateFile();
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
                Game.LogTrivial("Parsing lines...");
                Game.LogTrivial($"Items at line {i + 1} : {values[0]}, {values[1]}, {values[2]}, {values[3]}, {values[4]}, {values[5]}, {values[6]}");
                Game.LogTrivial($"Creating UIMenuItem with name {values[6]} under SubMenu CustomAnimations");
                UIMenuItem Custom = new UIMenuItem(values[6]);
                Menu.CustomAnims.AddItem(Custom);
            }
        }

        internal static void ValidateFile()
        {
            if (!File.Exists(CSharpFilePath))
            {
                Game.LogTrivial($"File {CSharpFilePath} does not exsist, creating");
                File.Create(CSharpFilePath);
            }
            if (!File.Exists(CSharpFileDirectory))
            {
                Game.LogTrivial($"File {CSharpFileDirectory} does not exsist, creating");
                File.Create(CSharpFileDirectory);
            }
        }
    }
}
