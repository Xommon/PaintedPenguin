using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 0.75f * Time.deltaTime;
    }
}
