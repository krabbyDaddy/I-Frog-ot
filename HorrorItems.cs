using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorItems : MonoBehaviour
{
    public GameObject regularObject;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localEulerAngles = new Vector3(regularObject.transform.rotation.x, regularObject.transform.rotation.y, regularObject.transform.rotation.z);
        this.gameObject.transform.position = new Vector3(regularObject.transform.position.x, regularObject.transform.position.y, regularObject.transform.position.z);
    }
}
