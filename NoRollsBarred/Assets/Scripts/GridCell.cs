using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public SushiCell sushiInCell = null;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {

        Sushi sushiParent = collision.GetComponentInParent<Sushi>();
        if (sushiParent&&sushiParent != Sushi.selectedSushi)
        {
            if (!sushiInCell)
            {
                sushiInCell = collision.GetComponent<SushiCell>();
            }
            sushiParent.SnapToGrid(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(sushiInCell)
        {
            sushiInCell = null;
        }
    }

}
