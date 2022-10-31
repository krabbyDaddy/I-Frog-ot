using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOscillatorTwo : MonoBehaviour
{

    private float timeCounter;

    private float speed;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0;
        speed = 0.4f;
        width = 4;
        height = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;


        float x = (Mathf.Cos(timeCounter) * width) -18f;
        float y = 2f;
        float z = (Mathf.Sin(timeCounter) * height) -35f;


        transform.position = new Vector3(x, y, z);
    }
}
