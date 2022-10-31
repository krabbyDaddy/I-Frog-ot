using System.Collections;
using UnityEngine;

public class Drawers : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private bool IsDrawer = true;
    [SerializeField]
    private float Speed = 2f;
    [Header("Sliding Configs")]
    [SerializeField]
    private Vector3 SlideDirection = Vector3.forward;
    [SerializeField]
    private float SlideAmount = 0.3f;

    private Vector3 StartPosition;

    private Coroutine AnimationCoroutine;

    [SerializeField] AudioSource drawerOpenSound;
    [SerializeField] AudioSource drawerCloseSound;

    private void Awake()
    {

        StartPosition = transform.position;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (IsDrawer)
            {
                AnimationCoroutine = StartCoroutine(DoSlidingOpen());
            }
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = StartPosition + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        IsOpen = true;
        drawerOpenSound.Play();

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public void Close()
    {
        if (IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (IsDrawer)
            {
                AnimationCoroutine = StartCoroutine(DoSlidingClose());
            }
        }
    }


    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = StartPosition;
        Vector3 startPosition = transform.position;
        float time = 0;

        IsOpen = false;
        drawerCloseSound.Play();

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}
