using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIevents", menuName = "ScriptableObjects/GameEvets", order = 4)]

public class GameEvents : ScriptableObject
{
    public delegate void UpdateUI();
    public UpdateUI EnemyCountUpdate = null;

    public delegate void UpdateGameStatus();
    public UpdateGameStatus updateGameStatusWin = null;

    public delegate void UpdateGameStatusLose();
    public UpdateGameStatusLose updateGameStatusLose = null;

    public delegate void UpdateShooterCount();
    public UpdateShooterCount updateShooterCount = null;

   

    [HideInInspector]
    public int CurrentScore = 0;

}
