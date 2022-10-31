using UnityEngine;
using UnityEngine.Playables;

public class FootstepTriggers : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepAudioOne;
    [SerializeField]
    private DialogueObject FootstepsDialogueOne;
    public FontController fontController;
    [SerializeField]
    private DialogueUI dialogueScripts;
    [SerializeField]
    private PlayableDirector footstepMover;



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && PickUpItemHorror.count == 1)
        {
            footstepMover.Play();
            fontController.HorrorText();
            dialogueScripts.ShowDialogue(FootstepsDialogueOne);
            Destroy(this.gameObject);
        }
    }
}