using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    //HUD

    public static bool isPaused = false;

    public const string WIN = "WIN";

    public const string LOSE = "LOSE";

    public const string COLLECTED = "COLLECTED";

    //Sentinelle
    public const string PLAYER_DETECTED = "PLAYER_DETECTED";
    public const string PLAYER_LOST = "PLAYER_LOST";

    //Cane
    public const string DETECTED_DOG = "DETECTED_DOG";
    public const string LOST_DOG = "LOST_DOG";

    public const string BOSS_FIGHT = "BOSS_FIGHT";
}
