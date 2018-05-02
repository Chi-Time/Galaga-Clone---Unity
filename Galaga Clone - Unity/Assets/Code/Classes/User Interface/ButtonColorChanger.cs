using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip ("The color the text will change to when hovered over.")]
    [SerializeField] private Color _HoverColor = Color.white;

    private Color _NormalColor = Color.white;

    private void Awake ()
    {
        // Get the current button's color.
        _NormalColor = GetComponentInChildren<Text> ().color;
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        // Set the button's text color that of the hover color when hovered over.
        GetComponentInChildren<Text> ().color = _HoverColor;
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        // Set the button's text color back to it's originalc color when it's no longer hovered over.
        GetComponentInChildren<Text> ().color = _NormalColor;
    }
}