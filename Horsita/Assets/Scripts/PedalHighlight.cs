using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PedalHighlight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Material highlightMaterial;
    private Material _originalMaterial;
    private RawImage _pedalImage;

    private void Start()
    {
        _pedalImage = GetComponent<RawImage>();
        if (_pedalImage != null)
        {
            _originalMaterial = _pedalImage.material;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        HighlightPedal(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HighlightPedal(false);
    }

    private void HighlightPedal(bool highlight)
    {
        if (_pedalImage != null)
        {
            _pedalImage.material = highlight ? highlightMaterial : _originalMaterial;
        }
    }
}