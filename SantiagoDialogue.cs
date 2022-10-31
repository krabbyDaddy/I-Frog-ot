using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class SantiagoDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueObject waitingForFirstDialogue;
    [SerializeField]
    private DialogueObject waitingForSweetDialogue;
    [SerializeField]
    private DialogueObject waitingForColdDialogue;
    [SerializeField]
    private DialogueObject waitingForElectronicDialogue;
    [SerializeField]
    private DialogueObject waitingForSharpDialogue;

    public FirstPersonController playerScript;
    public DialogueUI dialogueScript;
    public waitingForSweetScript script;
    public DialogueActivator dialogueActivatorScript;

    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask SantiagoLayer;

    public FontController fontController;


    public bool waitingForFirst;
    // Update is called once per frame

    private void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame && dialogueScript.IsOpen == false)
        {
            if (Physics.Raycast(Camera.position, Camera.forward, MaxUseDistance, SantiagoLayer))
            {

                if (dialogueActivatorScript.waitingForFirst == true)
                {
                    fontController.SantiagoText();
                    dialogueScript.ShowDialogue(waitingForFirstDialogue);
                }

                if (script.waitingForSweet == true)
                {
                    fontController.SantiagoText();
                    dialogueScript.ShowDialogue(waitingForSweetDialogue);
                }

                if (ColdItemController.waitingForCold == true)
                {
                    fontController.SantiagoText();
                    dialogueScript.ShowDialogue(waitingForColdDialogue);
                }

                if (ElectronicItemController.waitingForElectronic == true)
                {
                    fontController.SantiagoText();
                    dialogueScript.ShowDialogue(waitingForElectronicDialogue);
                }

                if (SharpItemController.waitingForSharp == true)
                {
                    fontController.SantiagoText();
                    dialogueScript.ShowDialogue(waitingForSharpDialogue);
                }
            }
        }
    }


}
