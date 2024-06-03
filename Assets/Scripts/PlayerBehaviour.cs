using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _animator;

    void Start()
    {
        CannotMove();
    }

    public void Play()
    {
        CanMove();
    }

    public void Finish()
    {
        CannotMove();
        _animator.SetTrigger("Dance");
    }

    public void CanMove()
    {
        _playerController.enabled = true;
    }

    public void CannotMove()
    {
        _playerController.enabled = false;
    }
}
