using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _animator;

    void Start()
    {
        DoNotMove();
        EventBus.LevelStarted += OnLevelStarted;
    }

    private void OnLevelStarted()
    {
        Move();
    }

    public void Finish()
    {
        DoNotMove();
        _animator.SetTrigger("Dance");
    }

    public void Move()
    {
        _playerController.enabled = true;
    }

    public void DoNotMove()
    {
        _playerController.enabled = false;
    }

    private void OnDestroy()
    {
        EventBus.LevelStarted -= OnLevelStarted;
    }
}
