using UnityEngine;
using UnityEngine.InputSystem;

public class IsLookingAtCauldron : MonoBehaviour
{

    public LayerMask cauldron;
    public bool LookingAtCauldron;

    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, 3f, cauldron))
        {
            LookingAtCauldron = true;
        }
        else
        {
            LookingAtCauldron = false;
        }
    }

    
}
