using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class NotesTwo : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask NoteLayer;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private GameObject note;
    private bool pauseNoteCheck;
    public GameObject cursor;
    public GameObject redCursor;
    private static float pauseTimer = 0f;
    [SerializeField]
    private AudioSource pickUpNote;
    [SerializeField]
    private AudioSource putDownNote;


    private void Start()
    {
        pauseNoteCheck = false;
    }
    void Update()
    {
        //Notes
        pauseTimer += Time.deltaTime;
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, NoteLayer)
            && pauseNoteCheck == false && Keyboard.current.eKey.wasPressedThisFrame && pauseTimer > 0.1f)
        {
            OpenNote();
        }

        if (pauseNoteCheck == true && Keyboard.current.escapeKey.wasPressedThisFrame && pauseTimer > 0.1f)
        {
            CloseNote();
        }

    }

    public void OpenNote()
    {
        pickUpNote.Play();
        note.SetActive(true);
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        pauseNoteCheck = true;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);
        redCursor.SetActive(false);
        pauseTimer = 0f;
    }

    public void CloseNote()
    {
        putDownNote.Play();
        note.SetActive(false);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        pauseNoteCheck = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        redCursor.SetActive(false);
        pauseTimer = 0f;
    }


}
