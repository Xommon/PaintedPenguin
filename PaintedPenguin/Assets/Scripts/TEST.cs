﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using RTLTMPro;

public class TEST : MonoBehaviour
{
    public TMP_Text textComp;
    public TextGenerationSettings settings = new TextGenerationSettings();
    public int charIndex;
    public Canvas canvas;

    void PrintPos()
    {
        string text = textComp.text;

        if (charIndex >= text.Length)
            return;

        TextGenerator textGen = new TextGenerator(text.Length);
        Vector2 extents = textComp.gameObject.GetComponent<RectTransform>().rect.size;
        //textGen.Populate(text, textComp.);
        settings.generationExtents = extents;
        textGen.Populate(text, settings);

        int newLine = text.Substring(0, charIndex).Split('\n').Length - 1;
        int whiteSpace = text.Substring(0, charIndex).Split(' ').Length - 1;
        int indexOfTextQuad = (charIndex * 4) + (newLine * 4) - 4;
        if (indexOfTextQuad < textGen.vertexCount)
        {
            Vector3 avgPos = (textGen.verts[indexOfTextQuad].position +
                textGen.verts[indexOfTextQuad + 1].position +
                textGen.verts[indexOfTextQuad + 2].position +
                textGen.verts[indexOfTextQuad + 3].position) / 4f;

            print(avgPos);
            PrintWorldPos(avgPos);
        }
        else
        {
            Debug.LogError("Out of text bound");
        }
    }

    void PrintWorldPos(Vector3 testPoint)
    {
        Vector3 worldPos = textComp.transform.TransformPoint(testPoint);
        print(worldPos);
        new GameObject("point").transform.position = worldPos;
        Debug.Log(textComp.GetComponent<TMP_Text>().text.Substring(charIndex, 1));
        Debug.DrawRay(worldPos, Vector3.up, Color.red, 50f);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 80), "Test"))
        {
            PrintPos();
        }
    }
}