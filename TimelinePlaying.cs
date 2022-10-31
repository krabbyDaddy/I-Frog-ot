using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelinePlaying : MonoBehaviour
{
    public static bool timelinePlaying;
    void Start()
    {
        timelinePlaying = false;
    }
    public void IsPlaying()
    {
        timelinePlaying = true;
    }
    public void IsNotPlaying()
    {
        timelinePlaying = false;
    }
}
