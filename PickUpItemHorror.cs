using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItemHorror : MonoBehaviour

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
    private PlayerActionsHorror doorScript;
    [SerializeField]
    private LayerMask ItemLayer;
    [SerializeField]
    private LayerMask CauldronLayer;
    [SerializeField]
    private DialogueUI dialogueScript;
    [SerializeField]
    private Rigidbody capsule;
    [SerializeField]
    private DestoryItem destory;
    [SerializeField]
    private ExitHorrorDoor music;


    public static float timer = 0f;
    private float pickUpRange = 2f;
    private float dropForwardForce = 5f;
    private float dropUpwardForce = 2f;
    private float MaxUseDistance = 2f;

    public bool equipped;
    public static bool slotFull;

    public static int count;

    public int xAxis;
    public int yAxis;
    public int zAxis;

    public void Start()
    {
        count = 0;

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
    }

    public void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;

        if (slotFull == true)
        {
            timer += Time.deltaTime;
        }

        //Looking at cauldron while holding object will show the destory item 
        if (script.LookingAtCauldron == true && slotFull == true && dialogueScript.IsOpen == false && Keyboard.current.eKey.wasPressedThisFrame)
        {
            destory.DestroyItem();
            count++;
            music.MusicCounter();
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
            if (doorScript.LookingAtDoor == false)
            {
                Drop();
                equipped = false;
                slotFull = false;
                timer = 0;
            }
        }


    }


    private void PickUp()
    {

        if (rb.isKinematic == false)
        {
            rb.isKinematic = true;
        }
        if (rb.useGravity == false)
        {
            rb.useGravity = true;
        }
        //Make item a child of the camera and move it to default position
        transform.SetParent(itemContainer);
        transform.localPosition = new Vector3 (xAxis, yAxis, zAxis);

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
        rb.velocity = capsule.velocity;

        //AddForce
        rb.AddForce(Camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(Camera.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }
}


