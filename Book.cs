using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    private float MaxUseDistance = 2f;
    [SerializeField]
    private LayerMask BookLayer;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private GameObject note;
    [SerializeField]
    private GameObject note2;
    [SerializeField]
    private GameObject note3;
    private bool pauseBookCheck;
    public GameObject cursor;
    public GameObject redCursor;
    private static float pauseTimer = 0f;
    [SerializeField]
    private AudioSource pickUpBook;
    [SerializeField]
    private AudioSource putDownBook;

    private void Start()
    {
        pauseBookCheck = false;
    }
    private void Update()
    {
        //Book
        pauseTimer += Time.deltaTime;
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, BookLayer)
    && pauseBookCheck == false && Keyboard.current.eKey.wasPressedThisFrame && pauseTimer > 0.1f)
        {
            OpenBook();
        }

        if (pauseBookCheck == true && Keyboard.current.escapeKey.wasPressedThisFrame && pauseTimer > 0.1f)
        {
            CloseBook();
        }
    }
    public void OpenBook()
    {
        pickUpBook.Play();
        note.SetActive(true);
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
        pauseBookCheck = true;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);
        redCursor.SetActive(false);
        pauseTimer = 0f;
    }
    public void CloseBook()
    {
        putDownBook.Play();
        note.SetActive(false);
        note2.SetActive(false);
        note3.SetActive(false);
        playerScript.canCameraMove = true;
        playerScript.canPlayerMove = true;
        pauseBookCheck = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        redCursor.SetActive(false);
        pauseTimer = 0f;
    }
}
