using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class ButtonUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;
    private Color originalTextColor;

    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        originalTextColor = buttonText.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SaturateText(TextMeshProUGUI textMesh)
    {
        float hue, saturation, value;
        Color.RGBToHSV(textMesh.color, out hue, out saturation, out value);
        textMesh.color = Color.HSVToRGB(hue, saturation + 1.0f, value);

    }

    private void RestoreOriginalTextColor()
    {
        buttonText.color = originalTextColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SaturateText(buttonText);
        Debug.Log("The cursor entered the selectable UI element.");
        Debug.Log(eventData.pointerEnter.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RestoreOriginalTextColor();
        Debug.Log("The cursor exited the selectable UI element.");
    }
}
