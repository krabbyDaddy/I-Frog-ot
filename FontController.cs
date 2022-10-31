using UnityEngine;
using TMPro;


public class FontController : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private TMP_FontAsset diegoFont;
    [SerializeField] private TMP_ColorGradient diegoGradient;
    [SerializeField] private TMP_FontAsset santiagoFont;
    [SerializeField] private TMP_ColorGradient santiagoGradient;
    [SerializeField] private TMP_FontAsset horrorFont;
    [SerializeField] private TMP_ColorGradient horrorGradient;

    [SerializeField]
    private GameObject canvas;
    public TypewriterEffect typerwriterScript;


    private void Awake()
    {
        typerwriterScript.diegoIsTalking = true;
        typerwriterScript.santiagoIsTalking = false;
        typerwriterScript.horrorIsTalking = false;
        typerwriterScript.horrorIsTalking2 = false;


    }

    public void DiegoText()
    {
        typerwriterScript.diegoIsTalking = true;
        typerwriterScript.santiagoIsTalking = false;
        typerwriterScript.horrorIsTalking = false;
        typerwriterScript.horrorIsTalking2 = false;
        text.font = diegoFont;
        text.fontSize = 85;
        text.colorGradientPreset = diegoGradient;
        text.lineSpacing = 20;
        RectTransform rt = canvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1500, 250);

    }

    public void SantiagoText()
    {
        typerwriterScript.diegoIsTalking = false;
        typerwriterScript.santiagoIsTalking = true;
        typerwriterScript.horrorIsTalking = false;
        typerwriterScript.horrorIsTalking2 = false;
        text.font = santiagoFont;
        text.colorGradientPreset = santiagoGradient;
        text.fontSize = 150;
        text.lineSpacing = -30;
        RectTransform rt = canvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1500, 250);
    }

    public void HorrorText()
    {
        typerwriterScript.diegoIsTalking = false;
        typerwriterScript.santiagoIsTalking = false;
        typerwriterScript.horrorIsTalking = true;
        typerwriterScript.horrorIsTalking2 = false;
        text.font = horrorFont;
        text.colorGradientPreset = horrorGradient;
        text.fontSize = 70;
        text.lineSpacing = 10;
        RectTransform rt = canvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1800, 250);
    }
    public void HorrorText2()
    {
        typerwriterScript.diegoIsTalking = false;
        typerwriterScript.santiagoIsTalking = false;
        typerwriterScript.horrorIsTalking = false;
        typerwriterScript.horrorIsTalking2 = true;
        text.font = horrorFont;
        text.colorGradientPreset = horrorGradient;
        text.fontSize = 70;
        text.lineSpacing = 10;
        RectTransform rt = canvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1800, 250);
    }
}
