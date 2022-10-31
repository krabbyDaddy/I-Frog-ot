using UnityEngine;
using UnityEngine.InputSystem;

public class CamSwitchPrototype : MonoBehaviour
{
    public Camera mainCam;
    public Camera horrorCam;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            mainCam.targetDisplay = 1;
            horrorCam.targetDisplay = 0;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            mainCam.targetDisplay = 0;
            horrorCam.targetDisplay = 1;
        }
    }
}
