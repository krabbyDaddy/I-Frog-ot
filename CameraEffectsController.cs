using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.ImageEffects;

public class CameraEffectsController : MonoBehaviour
{
    public int randomNumberGenerator;

    public int rangeMax;
    public Camera mainCam;
    public Camera horrorCam;
    public GameObject horrorCamera;
    public GameObject upsideVolume;
    public GameObject horrorHouse;
    public Kino.DigitalGlitch glitchEffectMain;
    public Kino.DigitalGlitch glitchEffectHorror;

    public AudioMixer audioMixer;
    public const string Mixer_Cutoff = "CutoffFreq";
    public const string Mixer_Res = "Resonance";
    public const string Mixer_Depth = "Depth";

    public GameObject dialogueBox;

    public DialogueUI dialogueScript;

    public PostProcessVolume v;
    public ColorGrading colorEffects;

    private bool coroutineRunning;

    private float timeCounter = 0f;
    private float speed = 0.9f;
    private float height = 95f;
    private float width = 140f;
    private int waitForSeconds;
    private int minGlitch;
    private int maxGlicth;

    public FontController fontController;

    public AudioSource music;
    public AudioClip main;
    public AudioClip plusOne;
    public AudioClip plusTwo;
    public AudioClip plusThree;
    public AudioClip plusFour;
    public AudioClip minusOne;
    public AudioClip minusThree;
    public AudioClip minusFour;

    public AudioSource glitchSoft;
    public AudioSource glitchHard;
    public AudioSource glitchTransition;
    public AudioClip glitchTransitionClip;
    public Outline outlineBread;
    public Outline outlineKnife;
    public bool notIntro;

    // Update is called once per frame

    public void Awake()
    {
        rangeMax = 1;
        horrorCamera.SetActive(false);
        mainCam.targetDisplay = 0;
        horrorCam.targetDisplay = 1;

        coroutineRunning = false;

        horrorHouse.SetActive(false);
        v.profile.TryGetSettings(out colorEffects);
        VignetteAndChromaticAberration chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
        chromatic_Vignette.enabled = false;

        waitForSeconds = 3;
        minGlitch = 2;
        maxGlicth = 4;
        audioMixer.SetFloat(Mixer_Cutoff, 6000);
        audioMixer.SetFloat(Mixer_Res, 1);
        audioMixer.SetFloat(Mixer_Depth, 0);
        notIntro = false;


    }
    private void Update()
    {
        timeCounter += Time.deltaTime * speed;
    }
    public void GoodMeterUpdate()
    {

        if (SweetItems.GoodMeter == -4)
        {
            horrorCamera.SetActive(false);
            colorEffects.mixerRedOutRedIn.value = 200;
            colorEffects.mixerRedOutGreenIn.value = 200;
            colorEffects.mixerRedOutBlueIn.value = 200;
        }

        if (SweetItems.GoodMeter == -3)
        {
            music.clip = minusFour;
            music.Play();

            horrorCamera.SetActive(true);

            glitchEffectMain.intensity = 0.07f;
            glitchEffectHorror.intensity = 0.03f;
            glitchHard.Play();

            colorEffects.ldrLutContribution.value = 0f;
            colorEffects.saturation.value = 30;
            colorEffects.contrast.value = 50;

            colorEffects.mixerRedOutRedIn.value = 150;
            colorEffects.mixerRedOutGreenIn.value = 150;
            colorEffects.mixerRedOutBlueIn.value = 150;

            if (coroutineRunning == false)
            {
                StartCoroutine(Glitch());
                coroutineRunning = true;
            }

        }

        if (SweetItems.GoodMeter == -2)

        {
            music.clip = minusThree;
            music.Play();

            glitchEffectMain.intensity = 0.02f;
            glitchSoft.Play();
            glitchHard.Stop();

            colorEffects.ldrLutContribution.value = 0f;
            colorEffects.saturation.value = 0;
            colorEffects.contrast.value = 40;

            colorEffects.mixerRedOutRedIn.value = 100;
            colorEffects.mixerRedOutGreenIn.value = 80;
            colorEffects.mixerRedOutBlueIn.value = 80;

        }

        if (SweetItems.GoodMeter == -1)

        {
            music.clip = minusOne;
            music.Play();

            glitchEffectMain.intensity = 0f;
            glitchSoft.Stop();

            colorEffects.ldrLutContribution.value = 0f;
            colorEffects.saturation.value = -20;
            colorEffects.contrast.value = 20;

            colorEffects.mixerRedOutRedIn.value = 100;
            colorEffects.mixerRedOutRedIn.overrideState = true;
            colorEffects.mixerRedOutGreenIn.value = 50;
            colorEffects.mixerRedOutGreenIn.overrideState = true;
            colorEffects.mixerRedOutBlueIn.value = 0;
            colorEffects.mixerRedOutBlueIn.overrideState = true;
            notIntro = true;
        }


        if (SweetItems.GoodMeter == 0)
        {
            if (notIntro == true)
            {
                music.clip = main;
                music.Play();
            }


            colorEffects.ldrLutContribution.value = 0f;
            colorEffects.saturation.value = -20;
            colorEffects.contrast.value = 0;

            colorEffects.mixerRedOutRedIn.overrideState = false;
            colorEffects.mixerRedOutGreenIn.overrideState = false;
            colorEffects.mixerRedOutBlueIn.overrideState = false;
        }

        if (SweetItems.GoodMeter == 1)

        {
            audioMixer.SetFloat(Mixer_Cutoff, 6000);
            audioMixer.SetFloat(Mixer_Res, 1);
            audioMixer.SetFloat(Mixer_Depth, 0);
            music.clip = plusOne;
            music.Play();

            colorEffects.ldrLutContribution.value = 0.1f;
            colorEffects.saturation.value = -10;
            colorEffects.contrast.value = 5;
            colorEffects.brightness.value = 30;
            notIntro = true;
        }

        if (SweetItems.GoodMeter == 2)

        {
            audioMixer.SetFloat(Mixer_Cutoff, 3000);
            audioMixer.SetFloat(Mixer_Res, 1);
            audioMixer.SetFloat(Mixer_Depth, 0.1f);

            music.clip = plusTwo;
            music.Play();

            colorEffects.ldrLutContribution.value = 0.2f;
            colorEffects.saturation.value = 0;
            colorEffects.brightness.value = 30;
            colorEffects.contrast.value = 10;

            VignetteAndChromaticAberration chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
            chromatic_Vignette.enabled = false;
        }

        if (SweetItems.GoodMeter == 3)

        {
            audioMixer.SetFloat(Mixer_Cutoff, 2000);
            audioMixer.SetFloat(Mixer_Res, 1);
            audioMixer.SetFloat(Mixer_Depth, 0.3f);

            music.clip = plusThree;
            music.Play();

            colorEffects.ldrLutContribution.value = 0.3f;
            colorEffects.saturation.value = 10;
            colorEffects.brightness.value = 45;
            colorEffects.contrast.value = 10;

            VignetteAndChromaticAberration chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
            chromatic_Vignette.enabled = true;

            chromatic_Vignette.chromaticAberration = 25;
        }

        if (SweetItems.GoodMeter == 4)

        {
            audioMixer.SetFloat(Mixer_Cutoff, 1000);
            audioMixer.SetFloat(Mixer_Res, 2);
            audioMixer.SetFloat(Mixer_Depth, 0.5f);

            music.clip = plusFour;
            music.Play();

            colorEffects.ldrLutContribution.value = 0.35f;
            colorEffects.saturation.value = 10;
            colorEffects.brightness.value = 45;
            colorEffects.contrast.value = 100;

            VignetteAndChromaticAberration chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
            chromatic_Vignette.enabled = true;

            chromatic_Vignette.chromaticAberration = (Mathf.Sin(timeCounter) * height);
        }
        if (SweetItems.GoodMeter == 5)

        {
            audioMixer.SetFloat(Mixer_Cutoff, 500);
            audioMixer.SetFloat(Mixer_Res, 2);
            audioMixer.SetFloat(Mixer_Depth, 1);

            colorEffects.ldrLutContribution.value = 0.4f;
            colorEffects.saturation.value = 10;
            colorEffects.brightness.value = 45;
            colorEffects.contrast.value = 100;

            VignetteAndChromaticAberration chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
            chromatic_Vignette.enabled = true;

            chromatic_Vignette.chromaticAberration = (Mathf.Sin(timeCounter) * height) + width;
        }
    }

    public IEnumerator Glitch()
    {
        while (SweetItems.GoodMeter == -3)
        {
            yield return new WaitForSeconds(3);

            glitchTransition.Play();
            fontController.HorrorText();
            horrorHouse.SetActive(true);
            mainCam.targetDisplay = 1;
            horrorCam.targetDisplay = 0;
            dialogueBox.SetActive(false);
            outlineBread.enabled = false;
            outlineKnife.enabled = false;

            yield return new WaitForSeconds(waitForSeconds);

            glitchTransition.Play();
            fontController.DiegoText();
            mainCam.targetDisplay = 0;
            horrorCam.targetDisplay = 1;
            horrorHouse.SetActive(false);
            dialogueBox.SetActive(true);
            outlineBread.enabled = true;
            outlineKnife.enabled = true;

            yield return new WaitForSeconds(Random.Range(minGlitch, maxGlicth));

            if (SweetItems.GoodMeter == -2)
            {
                break;
            }
            if (SweetItems.GoodMeter == -4)
            {
                break;
            }
        }
    }
}
