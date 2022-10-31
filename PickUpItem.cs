using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour

{
    [SerializeField]
    private GameObject thisGameObject;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private MeshCollider coll;
    [SerializeField]
    private Transform player, itemContainer;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private IsLookingAtCauldron script;
    [SerializeField]
    private PlayerActions doorScript;
    [SerializeField]
    private LayerMask ItemLayer;
    [SerializeField]
    private LayerMask CauldronLayer;
    [SerializeField]
    private LayerMask FrogLayer;
    [SerializeField]
    private TextMeshPro CauldronText;
    [SerializeField]
    private DialogueUI dialogueScript;


    public static float timer = 0f;
    private float pickUpRange = 2f;
    private float dropForwardForce = 5f;
    private float dropUpwardForce = 2f;
    private float MaxUseDistance = 2f;
    private bool LookingAtFrog;

    public bool equipped;
    public static bool slotFull;


    public void Start()
    {

        //Setup
        if (!equipped)
        {

            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true; ;
        }

        CauldronText.gameObject.SetActive(false);
    }

    public void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;
        if (Physics.Raycast(Camera.position, Camera.forward, MaxUseDistance, FrogLayer))  
        {
            LookingAtFrog = true;
        }
        else
        {
            LookingAtFrog = false;
        }

        if (slotFull == true)
        {
            timer += Time.deltaTime;
        }

        //Check if player is in range and "E" is pressed
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, ItemLayer)
        && !equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull && hit.collider && Keyboard.current.eKey.wasPressedThisFrame)
            {
                {
                    PickUp();
                    equipped = true;
                    slotFull = true;
                }

            }
        


        //Drop if equipped and "E" is pressed
        if (equipped && (timer > 0.3f) && script.LookingAtCauldron == false && Keyboard.current.eKey.wasPressedThisFrame)
        {
            //As long as you arent also looking at a door/cabinet/drawer
            if (doorScript.LookingAtDoor == false && doorScript.LookingAtOtherDoor == false && doorScript.LookingAtDrawers == false && LookingAtFrog == false) 
            {
                Drop();
                equipped = false;
                slotFull = false;
                timer = 0;
            }
        }
        

        //Looking at cauldron while holding object will show the destory item label
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit newHit, MaxUseDistance, CauldronLayer) && slotFull == true && dialogueScript.IsOpen == false)
        {
            CauldronText.gameObject.SetActive(true);
            CauldronText.transform.position = newHit.point - (Vector3.Scale(((newHit.point - Camera.position).normalized), new Vector3(0.1f, 0.3f, 0.1f)));
            CauldronText.transform.rotation = Quaternion.LookRotation((newHit.point - Camera.position).normalized);
        }
        else
        {
            CauldronText.gameObject.SetActive(false);
        }
    }


    private void PickUp()
    {

        if (rb.isKinematic == false)
        {
            rb.isKinematic = true;
        }
        //Make item a child of the camera and move it to default position
        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;

        coll.isTrigger = true;
    }

    private void Drop()
    {


        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and MeshCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Item carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(Camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(Camera.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }
}


