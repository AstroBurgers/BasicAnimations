namespace BasicAnimations.Systems
{
    internal class Hotkeys
    {
        internal static void HotKeyHandler()
        {
            while (true)
            {
                if (!(EntryPoint.CheckModKey() && Helper.CheckRequirements())) { continue; }
            }
        }
    }
}
