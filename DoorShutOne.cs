using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShutOne : MonoBehaviour
{ 
    [SerializeField]
    private Door doorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorScript.Close();
            Destroy(this.gameObject);
        }
    }
}
