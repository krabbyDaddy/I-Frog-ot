using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;
using UnityEngine.Rendering.PostProcessing;

public class SweetItems : MonoBehaviour
{
    [SerializeField]
    private GameObject cauldronTrigger;
    [SerializeField]
    private GameObject cameraRoot;
    [SerializeField]
    private Transform frogTarget;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private DialogueUI dialogueScripts;
    [SerializeField]
    private IsLookingAtCauldron cauldronScript;
    [SerializeField]
    private waitingForSweetScript sweetScript;
    [SerializeField]
    private DestoryItem destroyItemScript;
    [SerializeField]
    private DialogueObject ColdDialogue;
    public CameraEffectsController goodMeter;


    public static int GoodMeter;
    private static bool inTrigger;

    public FontController fontController;

    public CameraEffectsController goodMeterUpdate;
    public CharacterController cc;

    private void Start()
    {
        inTrigger = false;
        GoodMeter = 0;
        goodMeterUpdate.GoodMeterUpdate();
    }

    private void Update()
    {

        if (inTrigger == true)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && PickUpItem.slotFull == true && cauldronScript.LookingAtCauldron == true && dialogueScripts.IsOpen == false && PickUpItem.timer > 0.3f)
            {
                //Go from Sweet to Cold
                if (sweetScript.waitingForSweet == true)
                {
                    destroyItemScript.DestroyItem();

                    GoodMeter++;
                    goodMeterUpdate.GoodMeterUpdate();

                    sweetScript.waitingForSweet = false;
                    ColdItemController.waitingForCold = true;
                    fontController.DiegoText();
                    dialogueScripts.ShowDialogue(ColdDialogue);
                    float horizontalVelocity = cc.velocity.magnitude;
                    horizontalVelocity = 0f;
                    playerScript.canCameraMove = false;
                    playerScript.canPlayerMove = false;
                    cameraRoot.transform.LookAt(frogTarget);
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == cauldronTrigger)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == cauldronTrigger)
        {
            inTrigger = false;
        }
    }
}
