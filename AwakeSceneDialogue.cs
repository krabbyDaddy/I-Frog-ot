using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeSceneDialogue : MonoBehaviour
{
    public DialogueUI dialogueScript;
    public FontController fontController;

    [SerializeField]
    private DialogueObject first;
    [SerializeField]
    private DialogueObject second;
    [SerializeField]
    private DialogueObject third;
    [SerializeField]
    private DialogueObject fourth;

    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject introCamera;
    public GameObject cursor;
    public CameraEffectsController goodMeterUpdate;

    public bool cutscenePlaying;

    private void Start()
    {
        introCamera.SetActive(true);
        mainCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        cutscenePlaying = true;
    }


    public void FirstDialogue()
    {
        fontController.SantiagoText();
        dialogueScript.ShowDialogue(first);
    }

    public void SecondDialogue()
    {
        dialogueScript.ShowDialogue(second);
    }

    public void ThirdDialogue()
    {
        dialogueScript.ShowDialogue(third);
    }

    public void FourthDialogue()
    {
        dialogueScript.ShowDialogue(fourth);
    }

    public void EndCutscene()
    {
        mainCamera.SetActive(true);
        introCamera.SetActive(false);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        cutscenePlaying = false;
        goodMeterUpdate.GoodMeterUpdate();
    }
}
