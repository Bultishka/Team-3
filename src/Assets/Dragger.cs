using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 drafgoffset;
    private Camera maincam;
    [SerializeField] private float moveSpeed = 0f;

    private void Awake()
    {
        maincam = Camera.main;
    }

    private void OnMouseDown()
    {
        drafgoffset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos()+drafgoffset, moveSpeed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var MousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0;
        return MousePos;
    }
}
