using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour
{
    [SerializeField] AudioSource footstepWalkSource;
    [SerializeField] AudioSource footstepRunSource;
    [SerializeField] List<AudioClip> footstepWalkClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> footstepRunClips = new List<AudioClip>();

    public bool footstepsPlaying;

    CharacterController cc;

    private void Start()
    {
        footstepsPlaying = false;
        cc = GetComponent<CharacterController>();

    }

    void Update()
    {

        if (footstepWalkSource.isPlaying || footstepRunSource.isPlaying)
        {
            footstepsPlaying = true;
        }
        else
        {
            footstepsPlaying = false;
        }

        if (cc.isGrounded == true && cc.velocity.magnitude <= 4.5f && cc.velocity.magnitude >= 2f && footstepsPlaying == false)
        {
            FootstepWalkSFX();
        }

        if (cc.isGrounded == true && cc.velocity.magnitude > 4.5f && footstepsPlaying == false)
        {
            FootstepRunSFX();
        }
    }
    public void FootstepWalkSFX()
    {
        AudioClip clip = footstepWalkClips[Random.Range(0, footstepWalkClips.Count)];
        footstepWalkSource.PlayOneShot(clip);
    }
    public void FootstepRunSFX()
    {
        AudioClip clip = footstepRunClips[Random.Range(0, footstepRunClips.Count)];
        footstepRunSource.PlayOneShot(clip);
    }
}
