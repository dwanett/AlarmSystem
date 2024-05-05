using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private readonly int OpenCloseTrigger = Animator.StringToHash("OpenCloseDoor");
    
    [SerializeField] private Animator _animator;
    
    public void OpenCloseDoor()
    {
        _animator.SetTrigger(OpenCloseTrigger);
    }
}
