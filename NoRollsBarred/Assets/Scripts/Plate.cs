using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    // these are for checking what's full and empty.  when gridEmpty is empty, the plate is filled.
    // when the player drops a piece, each dropped square is checked against gridFilled; if any squares overlap, the drop fails.
    public Vector2[] gridEmpty;
    public Vector2[] gridFilled;
}
