using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject cameraRoot;
    [SerializeField]
    private GameObject introCamera;
    [SerializeField]
    private DialogueObject firstDialogue;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private DialogueUI dialogueScript;
    [SerializeField]
    private PlayableDirector introDirector;
    [SerializeField]
    private Transform frogTarget;

    [SerializeField]
    private waitingForSweetScript sweetScript;
    private Collider coll;
    public bool waitingForFirst;
    public bool finishedIntro;

    public GameObject cursor;

    public CharacterController cc;

    public FontController fontController;

    private void Start()
    {
        waitingForFirst = true;
        coll = GetComponent<Collider>();

    }

    public void Awake()
    {
        introDirector = GetComponent<PlayableDirector>();
        introDirector.played += Director_Played;
        introDirector.stopped += Director_Stopped;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && waitingForFirst == true)
        {
            {
                float horizontalVelocity = cc.velocity.magnitude;
                horizontalVelocity = 0f;
                cursor.SetActive(false);
                introDirector.Play();
                waitingForFirst = false;
                coll.enabled = false;
            }
        }

        if (other.CompareTag("Player") && (finishedIntro == true))
        {
            sweetScript.waitingForSweet = true;
            cameraRoot.transform.LookAt(frogTarget);
            fontController.DiegoText();
            dialogueScript.ShowDialogue(firstDialogue);
            playerScript.canCameraMove = false;
            playerScript.canPlayerMove = false;

            Destroy(this.gameObject.GetComponent<Collider>());
        }
    }

    public void Director_Played(PlayableDirector obj)
    {
        PlayerActions.cutscenePlaying = true;
        introCamera.SetActive(true);
        mainCamera.SetActive(false);
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
    }


    public void Director_Stopped(PlayableDirector obj)
    {
        PlayerActions.cutscenePlaying = false;
        mainCamera.SetActive(true);
        introCamera.SetActive(false);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        cursor.SetActive(true);
        finishedIntro = true;
        coll.enabled = true;
    }

}

