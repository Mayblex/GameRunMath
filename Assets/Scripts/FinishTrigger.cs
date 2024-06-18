using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            playerBehaviour.Finish();
            EventBus.OnLevelFinish();
        }
    }
}
