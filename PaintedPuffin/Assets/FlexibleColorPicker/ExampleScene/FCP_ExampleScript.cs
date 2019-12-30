using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class FCP_ExampleScript : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Image image;

    private void Update() {
        if (fcp != null)
        {
            image.color = fcp.color;
        }
    }
}
