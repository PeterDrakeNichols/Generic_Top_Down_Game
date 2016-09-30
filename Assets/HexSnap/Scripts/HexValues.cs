using UnityEngine;
using System.Collections;
[System.Serializable]

public static class HexValues
{

    // add to an Empty Game object in Scene
    // Define the RADIUS of the Hexes your are using in scene (radius is equal to the length of one edge)
    // reference these values for anything involving Hex Coordinates or Tiles


    public const float RADIUS = 1f;

    public const float height = 2 * RADIUS,
                       rowheight = 1.5f * RADIUS,
                       extraHeight = height - rowheight,
                       halfWidth = RADIUS * 0.866025404f,
                       width = halfWidth * 2,
                       hypotenuse = extraHeight / halfWidth;
}
