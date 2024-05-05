using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0f, 1f)] private float _maxVolume;
    [SerializeField, Range(0f, 1f)] private float _speedUpVolume;

    private bool isTriggerActive;
    
    private void OnEnable()
    {
        _trigger.activeTrigger += ActiveTrigger;
        _trigger.deactiveTrigger += DeactiveTrigger;
    }

    private void OnDisable()
    {
        _trigger.activeTrigger -= ActiveTrigger;
        _trigger.deactiveTrigger -= DeactiveTrigger;
    }

    private void Start()
    {
        _audioSource.volume = 0;
        _audioSource.Play();
    }

    private void Update()
    {
        if (isTriggerActive)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, Time.deltaTime * _speedUpVolume);
        else
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * _speedUpVolume);
    }

    private void ActiveTrigger()
    {
        isTriggerActive = true;
    }
    
    private void DeactiveTrigger()
    {
        isTriggerActive = false;
    }
}
