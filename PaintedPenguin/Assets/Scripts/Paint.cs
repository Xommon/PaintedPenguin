using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //Paint keeps moving to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
