using System;
using UnityEngine;

public class EventBus: MonoBehaviour
{
    public static event Action Bought;

    public static void OnBought()
    {
        Bought?.Invoke();
    }
}
