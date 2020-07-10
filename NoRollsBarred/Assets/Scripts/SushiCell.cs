using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCell : MonoBehaviour
{
    Sushi parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Sushi>();
    }

    private void OnMouseDown()
    {
        Debug.Log("dragging cell");
        parent.Select();
    }
    private void OnMouseUp()
    {
        Debug.Log("dropping cell");
        parent.Deselect();
    }
}
