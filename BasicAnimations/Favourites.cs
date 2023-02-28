using System;
using System.Text.RegularExpressions;
using System.IO;
using Rage;
using Rage.Native;
using RAGENativeUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BasicAnimations
{
    internal class Favourites
    {
        static string FilePath = @"Plugins/BasicAnimations/Favorites.txt";
        internal static void SetFav()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
            else
            {
                ReadFile();
            }
        }
        internal static void ReadFile()
        {
            try
            {
                string[] Favs = File.ReadAllLines(FilePath);
                for (int i = 0; i < Favs.Length; i++)
                {
                    string[] FavsSplit = Favs[i].Split(','); // 0 is dict, 1 is name, 2 is Menu name.
                }
            }
            catch (Exception e)
            {
                Game.LogTrivial("And error occured " + e);
            }
        }
    }
}
