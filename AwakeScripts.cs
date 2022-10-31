using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject flashlight;
    [SerializeField]
    private AudioSource flashlightClick;
    [SerializeField]
    private GameObject blackScreen;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private FirstPersonController playerScript;

    void Start()
    {
        StartCoroutine(AwakeScene());
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
    }

public IEnumerator AwakeScene()
    {
        yield return new WaitForSeconds(1);

        flashlightClick.Play();

        yield return new WaitForSeconds(0.2f);

        blackScreen.SetActive(false);
        flashlight.SetActive(true);
        cursor.SetActive(true);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
    }
}
