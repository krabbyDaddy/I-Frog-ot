using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    //Speed at which letters are typed
    [SerializeField]
    private float typewriterSpeed = 50f;

    public bool santiagoIsTalking;
    public bool diegoIsTalking;
    public bool horrorIsTalking;
    public bool horrorIsTalking2;

    [SerializeField] AudioSource diegoSounds;
    [SerializeField] AudioSource santiagoSounds;

    private readonly List<Punctuation> punctuations = new List<Punctuation>()
    {

        new Punctuation(new HashSet<char>(){'.', '!', '?'}, 0.6f ),
        new Punctuation(new HashSet<char>(){',', ';', ')', '('}, 0.3f )

    };


    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(routine: TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        //Starts Dialogue box as white
        textLabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typewriterSpeed;

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLabel.text = textToType.Substring(startIndex: 0, length: i + 1);

                dialogueSound();

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }

            }
            yield return null;
        }

        textLabel.text = textToType;
    }

   public void dialogueSound()
    {
        if (santiagoIsTalking == true)
        {
            santiagoSounds.Play();
        }

        if(diegoIsTalking == true)
        {
            diegoSounds.Play();
        }
        if(horrorIsTalking == true)
        {
            diegoSounds.Play();
        }
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }

        waitTime = default;
        return false;
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }

}


