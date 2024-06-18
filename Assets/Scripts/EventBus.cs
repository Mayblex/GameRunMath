using System;
using UnityEngine;

public class EventBus: MonoBehaviour
{
    public static event Action Bought;

    public static event Action LevelFinished;
    public static event Action LevelStarted;

    public static void OnBought()
    {
        Bought?.Invoke();
    }

    public static void OnLevelFinish()
    {
        LevelFinished?.Invoke();
    }

    public static void OnLevelStarted()
    {
        LevelStarted?.Invoke();
    }
}