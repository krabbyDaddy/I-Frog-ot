using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class NeutralScene : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sceneCamera;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private PlayableDirector sceneDirector;
    public DialogueUI dialogueScript;
    public FontController fontController;
    [SerializeField]
    private DialogueObject first;
    [SerializeField]
    private DialogueObject second;
    [SerializeField]
    private DialogueObject third;
    [SerializeField] 
    Image speechbubble;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    Sprite spriteTwo;

    public void PlayNeutralScene()
    {
        sceneCamera.SetActive(true);
        mainCamera.SetActive(false);
        sceneDirector.Play();
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;

    }
    public void FlipSpeechBubble()
    {
        speechbubble.sprite = sprite;
    }
    public void FlipSpeechBubbleBacl()
    {
        speechbubble.sprite = spriteTwo;
    }

    public void FirstDialogue()
    {
        fontController.DiegoText();
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
    public void Ending()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
