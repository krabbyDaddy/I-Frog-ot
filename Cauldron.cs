using UnityEngine.InputSystem;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public waitingForSweetScript sweetScript;
    public bool waitingForCold;
    public IsLookingAtCauldron script;

    private void OnTriggerEnter(Collider other)
    {
        if (sweetScript.waitingForSweet == true && script.LookingAtCauldron == true && PickUpItem.slotFull == true && (Keyboard.current.eKey.isPressed))
        {
            if (other.gameObject.name == "Cupcake :)" || other.gameObject.name == "Donut :)" || other.gameObject.name == "Slice of cake :)")
            {
                sweetScript.waitingForSweet = false;
                waitingForCold = true;

            }
        }
    }
}
