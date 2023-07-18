using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformClickEvent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PlatformTypes platformType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (platformType == PlatformTypes.StaticPlatform)
            Debug.Log("Static Platform Clicked");
        else if (platformType == PlatformTypes.DynamicPlatform)
            Debug.Log("Dynamic Platform Clicked");
    }
}
