using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInstansiatorAtPoint : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject instantiatingObject;

    [SerializeField]
    private uint maxInstances;
    private uint currentInstances = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentInstances++ >= maxInstances)
            return;   
        Vector3 instansiate_position = Camera.main.ScreenToWorldPoint(eventData.position);
        instansiate_position.z = instantiatingObject.transform.position.z;
        Instantiate(instantiatingObject, instansiate_position, Quaternion.identity);
    }
}
