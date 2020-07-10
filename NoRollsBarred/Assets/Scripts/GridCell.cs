using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public SushiCell sushiInCell = null;
    // Start is called before the first frame update

    private void Update()
    {
        if(sushiInCell)
        {
            Debug.Log("cell occupied");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SushiCell>())
        {
            sushiInCell = collision.GetComponent<SushiCell>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        sushiInCell = null;
    }

}
