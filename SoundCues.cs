using UnityEngine;

public class SoundCues : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSound.Play();
            Destroy(this.gameObject);
        }
    }
}
