using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    // Reference to Sprite Renderer component
    public Renderer rend;

    // Colour value that we can set in Inspector
    // It's 'white' by default
    [SerializeField]
    public Color colourToTurnTo = Color.white;

    // Use this for initialization
    public void Start()
    {
        // Assign Renderer component to rent variable
        rend = GetComponent<Renderer>();

        // Change sprite colour to selected colour
        rend.material.color = colourToTurnTo;
    }
}
