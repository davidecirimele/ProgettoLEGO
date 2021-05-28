using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    //BOSS
    public const string DETECTED = "DETECTED";
    public const string BOSS_ROBOT_KILLED = "BOSS_ROBOT_KILLED";
    public const string BOSS_ALIEN_KILLED = "BOSS_ALIEN_KILLED";

    //HUD
    public static bool isPaused = false;
    public const string WIN = "WIN";
    public const string LOSE = "LOSE";
}
