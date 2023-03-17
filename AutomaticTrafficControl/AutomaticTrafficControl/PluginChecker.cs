/*using System.IO;
using Rage;

namespace PluginChecker
{
    internal class PluginChecker
    {
        internal static string currUserDirectory = Directory.GetCurrentDirectory();

        // example fileName: RAGENativeUI.dll
        //have to have .dll in there
        internal static bool IsPluginInstalled(string fileName)
        {
            var exist = File.Exists($"{fileName}");
            if (!exist)
            {
                Game.LogTrivial($"File {fileName} is not installed in user's directory");
                return false;
            }
            Game.LogTrivial($"File {fileName} installed in user's directory");
            return true;
        }
    }
}*/