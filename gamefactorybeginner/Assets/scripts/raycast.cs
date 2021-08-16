using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    RaycastHit _raycast;
    void Update()
    {
        if (Physics.Raycast(transform.position,-transform.right,out _raycast,10.0f))
        {
            if (_raycast.collider.gameObject.tag=="player")
            {
                Destroy(gameObject);
            }
        }
    }
}
