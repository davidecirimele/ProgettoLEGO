using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    //Boss
    public const string DETECTED = "DETECTED";
    public const string BOSS_ROBOT_KILLED = "BOSS_ROBOT_KILLED";
    public const string BOSS_ALIEN_KILLED = "BOSS_ALIEN_KILLED";

    //Sentinelle
    public const string PLAYER_DETECTED = "PLAYER_DETECTED";
    public const string PLAYER_LOST = "PLAYER_LOST";

    //Cane
    public const string DETECTED_DOG = "DETECTED_DOG";
    public const string LOST_DOG = "LOST_DOG";
}
