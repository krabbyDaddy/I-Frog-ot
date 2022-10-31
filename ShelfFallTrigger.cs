using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfFallTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject one;
    [SerializeField]
    private GameObject two;
    [SerializeField]
    private GameObject three;
    [SerializeField]
    private GameObject four;
    [SerializeField]
    private GameObject five;
    [SerializeField]
    private GameObject six;
    [SerializeField]
    private GameObject seven;
    [SerializeField]
    private GameObject eight;
    [SerializeField]
    private GameObject shelf;
    [SerializeField]
    private AudioSource crash;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crash.Play();
            shelf.GetComponent<Rigidbody>().isKinematic = false;
            one.GetComponent<Rigidbody>().isKinematic = false;
            two.GetComponent<Rigidbody>().isKinematic = false;
            three.GetComponent<Rigidbody>().isKinematic = false;
            four.GetComponent<Rigidbody>().isKinematic = false;
            five.GetComponent<Rigidbody>().isKinematic = false;
            six.GetComponent<Rigidbody>().isKinematic = false;
            seven.GetComponent<Rigidbody>().isKinematic = false;
            eight.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(this.gameObject);
        }
    }
}
