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
        if(collision.GetComponent<SushiCell>())
        {
            sushiInCell = collision.GetComponent<SushiCell>();
            Sushi sushiParent = sushiInCell.GetComponentInParent<Sushi>();
            if (sushiParent != Sushi.selectedSushi)
            {
                sushiParent.SnapToGrid(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        sushiInCell = null;
    }

}
