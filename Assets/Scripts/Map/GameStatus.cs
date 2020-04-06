using System.Collections.Generic;
using UnityEngine.Events;

// This class holds the status of the game that should be shared across scenes
// and the callback functions the manipulate the status.
public static class GameStatus
{
    private static Dictionary<string, bool> RegionInfectionStatus;
    private static Dictionary<string, bool> RegionEnableStatus;
    private static string LastInfectedRegion;

    // Which region's level the player is in
    private static string CurrentInGameRegion;

    private static int LevelTriedCount;
    private static int LevelSuccssCount;

    // Either one is called when level ends
    public static UnityAction OnLevelSuccess;
    public static UnityAction OnLevelFail;

    static GameStatus()
    {
        RegionInfectionStatus = new Dictionary<string, bool>
        {
            ["SE"] = false,
            ["NE"] = false,
            ["C"] = false,
            ["NW"] = false,
            ["SW"] = false
        };
        RegionEnableStatus = new Dictionary<string, bool>
        {
            ["SE"] = false,
            ["NE"] = false,
            ["C"] = true,
            ["NW"] = false,
            ["SW"] = true
        };
        LevelTriedCount = LevelTriedCount = 0;
    }

    // When starting a level, update current region name
    public static void LevelStart(string RegionName)
    {
        CurrentInGameRegion = RegionName;
    }

    // When level succeeded, render current region as infected and disabled;
    // increase the count of tried and succeeded levels
    public static void LevelSuccess()
    {
        RegionInfectionStatus[CurrentInGameRegion] = true;
        RegionEnableStatus[CurrentInGameRegion] = false;
        LastInfectedRegion = CurrentInGameRegion;
        CurrentInGameRegion = null;
        ++LevelTriedCount;
        ++LevelSuccssCount;
    }

    // When level failed, only disable current region and increase the count of tried level
    public static void LevelFail()
    {
        RegionEnableStatus[CurrentInGameRegion] = false;
        ++LevelTriedCount;
    }

    public static void EnableLevel(string RegionName)
    {
        RegionEnableStatus[RegionName] = true;
    }


    // Getters
    public static bool GetRegionInfectionStatus(string RegionName)
    {
        return RegionInfectionStatus[RegionName];
    }
    public static bool GetRegionEnableStatus(string RegionName)
    {
        return RegionEnableStatus[RegionName];
    }
    public static string GetCurrentInGameRegion()
    {
        return CurrentInGameRegion;
    }
    public static int GetLevelTriedCount()
    {
        return LevelSuccssCount;
    }
    public static int GetLevelSuccessCount()
    {
        return LevelSuccssCount;
    }
}
