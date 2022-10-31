using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitHorrorDoor : MonoBehaviour
{
    private bool doorIsLocked;
    [SerializeField]
    private Transform Camera;
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask ExitDoorLayer;
    [SerializeField]
    private AudioSource lockedDoor;
    [SerializeField]
    private AudioSource unlockedDoor;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private AudioSource growl;
    [SerializeField]
    private EndingScene endingScene;
    [SerializeField]
    private GameObject itemLabels;
    [SerializeField]
    private GameObject capsule;
    [SerializeField]
    private AudioSource musicOne;
    [SerializeField]
    private AudioSource musicTwo;
    [SerializeField]
    private AudioSource musicThree;
    [SerializeField]
    private AudioSource roar;
    [SerializeField]
    private DialogueObject Angry;
    [SerializeField]
    private DialogueUI dialogueScripts;



    void Start()
    {
        doorIsLocked = true;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            OnUse();
        }


    }


    private void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out _, MaxUseDistance, ExitDoorLayer))
        {
            if (doorIsLocked == true)
            {
                lockedDoor.Play();
            }

            else if (doorIsLocked == false)
            {
                StartCoroutine(TriggerEnding());
            }
        }
    }

    public IEnumerator TriggerEnding()
    {
        itemLabels.SetActive(false);
        capsule.SetActive(false);
        lockedDoor.Play();
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        growl.Play();

        yield return new WaitForSeconds(3);

        endingScene.PlayEndingScene();

    }

    public void MusicCounter()
    {
        if (PickUpItemHorror.count == 2)
        {
            musicOne.Play();
        }
        if (PickUpItemHorror.count == 3)
        {
            musicOne.Stop();
            musicTwo.Play();
        }
        if (PickUpItemHorror.count == 4)
        {
            doorIsLocked = false;
            musicTwo.Stop();
            musicThree.Play();
            StartCoroutine(EndDialogue());
        }
    }
    public IEnumerator EndDialogue()
    {
        yield return new WaitForSeconds(0.5f);
        unlockedDoor.Play();
        yield return new WaitForSeconds(1.5f);
        roar.Play();
        dialogueScripts.ShowDialogue(Angry);
        
    }
}
