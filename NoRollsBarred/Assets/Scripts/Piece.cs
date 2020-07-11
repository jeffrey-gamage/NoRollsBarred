using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // each piece is made up of a list of Cells, used for plate calculation.
    // i.e. a square would be [0,0],[0,1],[1,0],[1,1]
    // When attaching to cursor, grab based on the first gridSquare position so player is grabbing by the correct square.
    public Vector2[] cells;
    public string color;

}
