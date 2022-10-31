using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActionsRESTART : MonoBehaviour
{

    [SerializeField]
    private float MaxUseDistance = 2f;

    //For all door related things
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private LayerMask UseDoorLayers;
    [SerializeField]
    private LayerMask UseOtherDoorLayers;
    [SerializeField]
    private LayerMask UseDrawersLayers;
    public bool LookingAtDoor;
    public bool LookingAtOtherDoor;
    public bool LookingAtDrawers;


    //cursor bs
    public static bool LookingAtInteractable;
    public GameObject cursor;
    public GameObject redCursor;
    public NEWAwake cutsceneScript;


    //PauseMenuBS
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionMenu;
    private bool pauseCheck;
    [SerializeField]
    private FirstPersonController playerScript;
    private static float pauseTimer = 0f;


    //For all dialogue related things
    [SerializeField]
    private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    public CapsuleCollider playerCollider;
    public bool waitingForFirst;

    private void Start()
    {
        waitingForFirst = true;
        pauseCheck = false;
        cursor.SetActive(true);
        redCursor.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        //Changes crosshair when looking at objects 
        if (ResponseHandler.isThereButtons == false)
        {
            if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance)
            && hit.collider.CompareTag("Interactable"))
            {
                CrosshairChange(true);
                LookingAtInteractable = true;
            }
            else
            {
                CrosshairChange(false);
                LookingAtInteractable = false;
            }
        }

        //Dialogue stuff
        if (dialogueUI.IsOpen) return;

        //Handles Pause Menu
        if (pauseCheck == false && Keyboard.current.escapeKey.wasPressedThisFrame && pauseTimer > 0.1f && dialogueUI.IsOpen == false && PlayerActions.cutscenePlaying == false && TimelinePlaying.timelinePlaying == false)
        {
            OpenPauseMenu();
        }

        if (pauseCheck == true && Keyboard.current.escapeKey.wasPressedThisFrame && pauseTimer > 0.1f)
        {
            ClosePauseMenu();
        }

        pauseTimer += Time.deltaTime;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        pauseCheck = true;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);
        redCursor.SetActive(false);
        pauseTimer = 0f;

    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        pauseCheck = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        redCursor.SetActive(false);
        pauseTimer = 0f;
    }

    void CrosshairChange(bool on)
    {
        if (on)
        {
            cursor.SetActive(false);
            redCursor.SetActive(true);
        }
        else if (pauseCheck == false && ResponseHandler.isThereButtons == false && PlayerActions.cutscenePlaying == false)
        {
            cursor.SetActive(true);
            redCursor.SetActive(false);
        }
    }


    private void OnUse()
    {
        //Opens Door
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit doorHit, MaxUseDistance, UseDoorLayers)
            && (doorHit.collider.TryGetComponent<Door>(out Door door)))
        {
            LookingAtDoor = true;
            if (door.IsOpen)
            {
                door.Close();

            }
            else
            {
                door.Open(transform.position);

            }
        }
        else
        {
            LookingAtDoor = false;
        }

        //Opens cabinets and other outward doors
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit otherDoorHit, MaxUseDistance, UseOtherDoorLayers)
        && (otherDoorHit.collider.TryGetComponent<OtherDoor>(out OtherDoor otherDoor)))
        {
            LookingAtOtherDoor = true;
            if (otherDoor.IsOpen)
            {
                otherDoor.Close();

            }
            else
            {
                otherDoor.Open(transform.position);

            }
        }
        else
        {
            LookingAtOtherDoor = false;
        }

        //Opens cabinets and other outward doors
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit drawerHit, MaxUseDistance, UseDrawersLayers)
        && (drawerHit.collider.TryGetComponent<Drawers>(out Drawers drawers)))
        {
            LookingAtDrawers = true;
            if (drawers.IsOpen)
            {
                drawers.Close();

            }
            else
            {
                drawers.Open(transform.position);

            }
        }
        else
        {
            LookingAtDrawers = false;
        }

    }
}

