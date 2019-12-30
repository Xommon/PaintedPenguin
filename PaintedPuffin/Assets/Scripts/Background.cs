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
            transform.position -= new Vector3 (0.005f * Time.deltaTime, 0, 0);
        }
        else if (transform.name == "bg_mountains_lightened")
        {
            transform.position -= new Vector3(0.048f * Time.deltaTime, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_1_lightened")
        {
            transform.position -= new Vector3(0.15f * Time.deltaTime, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_2")
        {
            transform.position -= new Vector3(0.1f * Time.deltaTime, 0, 0);
        }
        else if (transform.name == "bg_clouds_MG_3")
        {
            transform.position -= new Vector3(0.05f * Time.deltaTime, 0, 0);
        }
        else if (transform.name == "bg_cloud_lonely")
        {
            transform.position -= new Vector3(0.06f * Time.deltaTime, 0, 0);
        }

        if (transform.position.x <= -3.03f)
        {
            transform.position = new Vector3(0.8121f, 0.53f, 0);
        }
    }
}
