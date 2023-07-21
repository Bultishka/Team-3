using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheBall : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale != 0.0f && Input.GetKeyDown(KeyCode.Space))
            gameObject.GetComponent<Rigidbody2D>().bodyType 
                = RigidbodyType2D.Dynamic;
    }
}
