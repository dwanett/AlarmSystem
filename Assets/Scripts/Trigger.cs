using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event Action activeTrigger;
    public event Action deactiveTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        activeTrigger.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        deactiveTrigger.Invoke();
    }
}
