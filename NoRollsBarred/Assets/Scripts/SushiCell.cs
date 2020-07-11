using System;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<SushiCell>())
        {
            if ((!parent.isStationary) && (parent != Sushi.selectedSushi) && collision.GetComponentInParent<Sushi>() != Sushi.selectedSushi) 
            {
                parent.RejectMove();
            }
        }
    }


    private void OnMouseDown()
    {
        parent.Select();
    }
    private void OnMouseUp()
    {
        parent.Deselect();
    }
}
