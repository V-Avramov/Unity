using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    public float timeOut = 1.0f;
    public bool detachChildren = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyNow", timeOut);
    }

    void DestroyNow()
    {
        if (detachChildren)
        { // detach the children before destroying if specified
            transform.DetachChildren();
        }

        // destory the game Object
        Destroy(gameObject);
    }
}
