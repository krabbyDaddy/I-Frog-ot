using StarterAssets;
using UnityEngine;
using UnityEngine.Playables;

public class DisobedientScene : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sceneCamera;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private PlayableDirector sceneDirector;
    [SerializeField]
    private GlitchToMax glitchScript;
    public DialogueUI dialogueScript;
    public FontController fontController;
    [SerializeField]
    private DialogueObject first;
    [SerializeField]
    private DialogueObject second;
    [SerializeField]
    private DialogueObject third;
    [SerializeField]
    private AudioSource rawr;

    public void PlayDisobedientScene()
    {
        sceneCamera.SetActive(true);
        mainCamera.SetActive(false);
        sceneDirector.Play();
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        glitchScript.disobedientCutscene = true;

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
        fontController.HorrorText();
        dialogueScript.ShowDialogue(third);
        rawr.Play();
    }

}
