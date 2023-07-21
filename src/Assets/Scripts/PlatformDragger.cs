using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformDragger : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Transform _transform;
    private bool _isDragging;
    private List<GameObject> _allPlatforms;
    private const float move = 0.05f;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Time.timeScale == 0.0f)
            return;
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = _transform.position.z;
        _transform.position = position;
        _isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _allPlatforms = GetAllProbablyIntersectObjects();

        // Fix
        foreach (var platform in _allPlatforms)
            FixIntersection(platform);

        // Postfix
        foreach (var platform in _allPlatforms)
            FixIntersection(platform);

        _isDragging = false;
    }

    private List<GameObject> GetAllProbablyIntersectObjects()
    {
        var objects = GameObject.FindGameObjectsWithTag("Platform").ToList();
        foreach (var platform in objects)
        {
            if (platform == gameObject)
            {
                objects.Remove(platform);
                break;
            }
        }
        return objects;
    }

    private void FixIntersection(GameObject other)
    {
        float moveX = GetMoveDirection(other);
        while (IsIntersects(other))
        {
            _transform.position -= new Vector3(moveX, 0, 0);
        }
    }

    private bool IsIntersects(GameObject other)
    {
        var mainPlatformBounds = GetComponent<Renderer>().bounds;
        var checkPlatformBounds = other.GetComponent<Renderer>().bounds;
        if (checkPlatformBounds.Intersects(mainPlatformBounds))
            return true;
        return false;
    }

    private float GetMoveDirection(GameObject other)
    {
        if (other.GetComponent<Renderer>().bounds.center.x <
                  GetComponent<Renderer>().bounds.center.x)
            return -move;
        return move;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isDragging)
            SceneSettingsManager.instance.ShowPlatformInfoPanel();
    }

    public void OnPointerDown(PointerEventData eventData) {}
}
