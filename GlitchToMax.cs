using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchToMax : MonoBehaviour
{
    public Kino.DigitalGlitch glitchEffectMain;
    public float myGlitchValue = 0.1f;
    public float glitchPerSecond = .1f;
    public float myPitchValue = 1f;
    public float pitchPerSecond = .2f;
    public bool disobedientCutscene;
    public AudioSource music;

    private void Awake()
    {
        disobedientCutscene = false;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        glitchEffectMain.intensity = myGlitchValue;
        music.volume = myGlitchValue;
        music.pitch = myPitchValue;

        if (disobedientCutscene == true)
        {
            if (myGlitchValue < 1f)
            {
                myGlitchValue += glitchPerSecond * Time.deltaTime;
            }


            if (myPitchValue < 3f)
            {
                myPitchValue += pitchPerSecond * Time.deltaTime;
            }

        }

    }
}
