using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    public float transitionDuration = 2.5f;
    public Transform frogTarget;

    private void Update()
    {
        if (ColdItemController.waitingForCold == true)
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        float t = 0.0f;
        Quaternion startingRot = transform.localRotation;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);


            transform.localRotation = Quaternion.Lerp(startingRot, frogTarget.localRotation, t);
            yield return 0;
            break;

        }
    }
}
