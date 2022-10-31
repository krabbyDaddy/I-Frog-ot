using StarterAssets;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class ObedientScene : MonoBehaviour
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
    public AudioMixer audioMixer;
    public const string Mixer_Cutoff = "CutoffFreq";
    public const string Mixer_Res = "Resonance";
    public const string Mixer_Depth = "Depth";

    public void PlayObedientScene()
    {
        sceneCamera.SetActive(true);
        mainCamera.SetActive(false);
        sceneDirector.Play();
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
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
    public void FixSounds()
    {
        audioMixer.SetFloat(Mixer_Cutoff, 6000);
        audioMixer.SetFloat(Mixer_Res, 1);
        audioMixer.SetFloat(Mixer_Depth, 0);
    }

    public void Ending()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
