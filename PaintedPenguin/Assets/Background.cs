using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.name == "bg_clouds_BG")
        {
            transform.position -= new Vector3 (0.00005f, 0, 0);
        }
        else if (transform.name == "bg_mountains_lightened")
        {
            transform.position -= new Vector3(0.00012f, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_1_lightened")
        {
            transform.position -= new Vector3(0.0015f, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_2")
        {
            transform.position -= new Vector3(0.001f, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_3")
        {
            transform.position -= new Vector3(0.0005f, 0, 0);
        }
        else if (transform.name == "bg_cloud_lonely")
        {
            transform.position -= new Vector3(0.0001f, 0, 0);
        }

        if (transform.position.x <= -3.03f)
        {
            transform.position = new Vector3(0.8121f, 0.53f, 0);
        }
    }
}
