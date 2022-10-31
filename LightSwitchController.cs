using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitchController : MonoBehaviour
{
    [SerializeField] private bool isLightOn;
    [SerializeField] private UnityEvent lightsOnEvent;
    [SerializeField] private UnityEvent lightsOffEvent;


    public void InteractSwitch()
    {
        if (!isLightOn)
        {
            isLightOn = true;
            lightsOnEvent.Invoke();
        }
        else
        {
            isLightOn = false;
            lightsOffEvent.Invoke();
        }
    }
}
