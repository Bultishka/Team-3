using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformDragger : MonoBehaviour, IDragHandler
{
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = _transform.position.z;
        _transform.position = position;
    }
}
