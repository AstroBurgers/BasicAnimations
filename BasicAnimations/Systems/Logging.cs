using Rage;

namespace BasicAnimations.Systems
{
    internal class Logging
    {
        internal enum LogType
        {
            Normal,
            Warning,
            Error,
            Menu,
            Settings,
        }
        internal class Logger
        {
            internal static void Log(LogType type, string logging)
            {
                switch (type)
                {
                    case LogType.Normal:
                        Game.LogTrivial($"Basic Animations: {logging}");
                        break;
                    case LogType.Warning:
                        Game.LogTrivial($"Basic Animations [WARNING]: {logging}");
                        break;
                    case LogType.Error:
                        Game.LogTrivial($"Basic Animations [ERROR]: {logging}");
                        break;
                    case LogType.Menu:
                        Game.LogTrivial($"Basic Animations [MENU]: {logging}");
                        break;
                    case LogType.Settings:
                        Game.LogTrivial($"Basic Animations [SETTINGS]: {logging}");
                        break;
                }
            }

            internal static void LogException(string location, string error)
            {
                Game.LogTrivial($"Basic Animations [ERROR]: At '{location}' - {error}");
            }
        }
    }
}
