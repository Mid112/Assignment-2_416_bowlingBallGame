using UnityEngine;
using System;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent OnPinFall = new ();
    public bool isFallen = false;
    private void OnTriggerEnter(Collider triggerObject)
    {
        if(triggerObject.CompareTag("Ground") && !isFallen)
        {
            isFallen = true;
        OnPinFall?.Invoke();
        }
        
    }

}
