using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGuide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 4.0f);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
