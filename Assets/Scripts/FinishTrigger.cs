using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            playerBehaviour.Finish();
            FindObjectOfType<LevelSwitcher>().ShowFinishWindow();
        }
    }
}
