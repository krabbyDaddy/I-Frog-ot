using UnityEngine;
using TMPro;

public class ShowItemTextHorror : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro ItemText;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask ItemLayers;
    public DialogueUI dialogueScript;

    // Start is called before the first frame update
    private void Start()
    {
        ItemText.gameObject.SetActive(true);
        ItemText.SetText("");
    }

    public void LateUpdate()
    {

        //Looking at objects will show its label
        if (PickUpItemHorror.slotFull == false && dialogueScript.IsOpen == false)
        {
            if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, ItemLayers))
            {

                ItemText.transform.position = hit.point - (Vector3.Scale(((hit.point - Camera.position).normalized), new Vector3(0.1f, 0.4f, 0.1f)));
                ItemText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
                ItemText.SetText(hit.collider.gameObject.name);
            }
            else
            {
                ItemText.SetText("");
            }

        }
        else
        {
            ItemText.SetText("");
        }
    }
}