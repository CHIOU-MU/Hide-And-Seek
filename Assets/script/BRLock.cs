using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class BRLock : MonoBehaviour
{
    // Define five different colors
    public Color[] colors;

    // Current color index for this button
    private int currentColorIndex = 0;

    // Reference to the button's Image component
    private Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        // Get the button's Image component
        buttonImage = GetComponent<Image>();

        // Set the default color to the first color in the array
        buttonImage.color = colors[0];

       
    }

    // Handle button click events
    public void OnClick()
    {
        // Increment the current color index
        currentColorIndex++;

        // If the index is greater than the number of colors, reset to zero
        if (currentColorIndex >= colors.Length)
        {
            currentColorIndex = 0;
        }

        // Set the button's color to the current color
        buttonImage.color = colors[currentColorIndex];

        // Check if the password is correct (yellow, green, blue)
        if (GameObject.Find("LeftButton").GetComponent<Image>().color == colors[2] &&
            GameObject.Find("MiddleButton").GetComponent<Image>().color == colors[1] &&
            GameObject.Find("RightButton").GetComponent<Image>().color == colors[5])
        {
            Flowchart.BroadcastFungusMessage("boyRoomOpen");
        }
    }

}
