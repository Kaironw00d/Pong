using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tab : MonoBehaviour, IPointerClickHandler
{
    public event Action<int> OnPointerClicked;
    [Range(0,99)] public int tabIndex;
    public bool isDefaultTab;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClicked?.Invoke(tabIndex);
    }
}
