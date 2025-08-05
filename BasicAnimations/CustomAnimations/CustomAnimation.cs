#nullable enable
using System;
using System.IO;
using Newtonsoft.Json;
using BasicAnimations.Systems;

namespace BasicAnimations.CustomAnimations;

public static class CustomAnimationsLoader
{
    private const string FilePath = @"plugins\BasicAnimations\CustomAnimations.json";

    public static CustomAnimationsModel? LoadedData { get; private set; }

    public static void Load()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                Logging.Logger.Log(Logging.LogType.Error, $"Custom animation JSON not found: {FilePath}");
                return;
            }

            var json = File.ReadAllText(FilePath);
            LoadedData = JsonConvert.DeserializeObject<CustomAnimationsModel>(json);

            Logging.Logger.Log(Logging.LogType.Normal,
                $"Loaded {LoadedData?.Animations?.Count ?? 0} animations and {LoadedData?.Scenarios?.Count ?? 0} scenarios.");
        }
        catch (Exception ex)
        {
            Logging.Logger.Log(Logging.LogType.Error, $"Error loading animation JSON: {ex.Message}");
        }
    }

}