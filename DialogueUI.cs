using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using StarterAssets;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;
    public bool isThereDialogue;

    [SerializeField]
    private FirstPersonController playerScript;



    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        isThereDialogue = false;
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        isThereDialogue = true;
        StartCoroutine(StepThroughDialogue(dialogueObject));

    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitForSeconds(1f);
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }

    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        isThereDialogue = false;
    }
}
