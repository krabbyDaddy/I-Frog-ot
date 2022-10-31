using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    private float timeCounter;

    private float speed;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0;
        speed = 0.2f;
        width = 1;
        height = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timeCounter += Time.deltaTime * speed;


        float x = (Mathf.Cos(timeCounter) * width) + 18f;
        float y = 0.2f;
        float z = (Mathf.Sin(timeCounter) * height) + 4f;


        transform.position = new Vector3(x, y, z);
        transform.LookAt(Target, Vector3.up);
    }
}
