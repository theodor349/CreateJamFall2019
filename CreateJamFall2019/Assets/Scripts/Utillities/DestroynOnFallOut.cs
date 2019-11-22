using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroynOnFallOut : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -10)
            Destroy(transform.gameObject);
    }
}
