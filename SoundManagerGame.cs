using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerGame : MonoBehaviour
{
    public static SoundManagerGame instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource footstepWalkSource;
    [SerializeField] AudioSource footstepRunSource;
    [SerializeField] List<AudioClip> footstepWalkClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> footstepRunClips = new List<AudioClip>();

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    public bool footstepsPlaying;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
        footstepsPlaying = false;
    }
    private void Update()
    {
        if (footstepWalkSource.isPlaying || footstepRunSource.isPlaying)
        {
            footstepsPlaying = true;
        }
        else
        {
            footstepsPlaying = false;
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

    void LoadVolume() //Volume saved in VolumeSettings.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSlider.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSlider.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
