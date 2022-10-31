using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NEWAwake : MonoBehaviour
{
    public DialogueUI dialogueScript;
    public FontController fontController;

    [SerializeField]
    private DialogueObject first;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject cameraRoot;
    public CameraEffectsController goodMeterUpdate;
    public CharacterController cc;
    [SerializeField]
    private Transform frogTarget;
    [SerializeField]
    private AudioSource music;
    public waitingForSweetScript waitingforSweet;
    public bool waitingForFirst;
    [SerializeField]
    private GameObject cursor;

    public bool hasStarted;
    public bool check;

    public void Awake()
    {
        waitingForFirst = false;
        hasStarted = false;
        check = false;
    }

    public void Beginning()
    {
        waitingForFirst = false;
        float horizontalVelocity = cc.velocity.magnitude;
        horizontalVelocity = 0f;
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        cameraRoot.transform.LookAt(frogTarget);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerActions.cutscenePlaying = true;

    }


    public void FirstDialogue()
    {
        fontController.DiegoText();
        dialogueScript.ShowDialogue(first);
        hasStarted = true;
    }

    public void PlayMusic()
    {
        music.Play();
    }

    private void Update()
    {
        if (hasStarted == true && dialogueScript.IsOpen == false && check == false)
        {
            CutsceneEnded();
        }
    }

    public void CutsceneEnded()
    {
        PlayerActions.cutscenePlaying = false;
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        waitingforSweet.waitingForSweet = true;
        cursor.SetActive(true);
        check = true;

    }
}
