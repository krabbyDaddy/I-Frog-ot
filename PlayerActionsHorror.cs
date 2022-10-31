using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsHorror : MonoBehaviour
{
    //For all door related things
    [SerializeField]
    private LayerMask UseDoorLayers;
    public bool LookingAtDoor;

    //cursor bs
    public static bool LookingAtInteractable;
    public GameObject cursor;
    public GameObject redCursor;
    public timelineScript cutsceneScript;
    [SerializeField]
    private float MaxUseDistance = 2f;
    [SerializeField]
    private Transform Camera;


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

    private void Start()
    {
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
        if (pauseCheck == false && Keyboard.current.escapeKey.wasPressedThisFrame && pauseTimer > 0.1f && dialogueUI.IsOpen == false && TimelinePlaying.timelinePlaying == false)
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
        else if (pauseCheck == false && ResponseHandler.isThereButtons == false)
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
    }
}

