using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrogDialogueActivator : MonoBehaviour
{

    [SerializeField] 
    private DialogueObject waitingForSweetDialogue;
    [SerializeField]
    private DialogueObject waitingForColdDialogue;
    [SerializeField]
    private DialogueObject waitingForElectronicDialogue;
    [SerializeField]
    private DialogueObject waitingForGreenDialogue;
    [SerializeField]
    private DialogueObject waitingForSharpDialogue;

    public FirstPersonController playerScript;
    public DialogueUI dialogueScript;
    public NEWAwake script;
    public waitingForSweetScript waiting;

    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask FrogLayer;

    public FontController fontController;
    public bool waitingForFirst;

    private void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame && dialogueScript.IsOpen == false)
        {
            if (Physics.Raycast(Camera.position, Camera.forward, MaxUseDistance, FrogLayer))
            {
                if (waiting.waitingForSweet == true)
                {
                    fontController.DiegoText();
                    dialogueScript.ShowDialogue(waitingForSweetDialogue);
                }

                if (ColdItemController.waitingForCold == true)
                {
                    fontController.DiegoText();
                    dialogueScript.ShowDialogue(waitingForColdDialogue);
                }

                if (ElectronicItemController.waitingForElectronic == true)
                {
                    fontController.DiegoText();
                    dialogueScript.ShowDialogue(waitingForElectronicDialogue);
                }

                if (GreenItemController.waitingForGreen == true)
                {
                    fontController.DiegoText();
                    dialogueScript.ShowDialogue(waitingForGreenDialogue);
                }

                if (SharpItemController.waitingForSharp == true)
                {
                    fontController.DiegoText();
                    dialogueScript.ShowDialogue(waitingForSharpDialogue);
                }
            }
        }
    }
}
