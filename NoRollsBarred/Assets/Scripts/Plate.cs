using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Vector2Int rootCoords;
    private List<GridCell> gridCells;

    private void Start()
    {
        Grid grid = FindObjectOfType<Grid>();
        gridCells = new List<GridCell>();
        foreach(Transform childTransform in gameObject.transform)
        {
            if(childTransform!=gameObject.transform)//only add gridCells at coordinates of children
            {
                GridCell cell = grid.cells[rootCoords.y + (int)childTransform.localPosition.y][rootCoords.x + (int)childTransform.localPosition.x];
                cell.SetPlate(this);
                gridCells.Add(cell);
            }
        }
    }

    private void Update()
    {
        foreach(GridCell cell in gridCells)
        {
            if(!cell.sushiInCell)
            {
                return;
            }
        }
        OnFill();
    }

    private void OnFill()
    {
        //TODO: update score            
        foreach (GridCell cell in gridCells)
        {
            cell.SetPlate(null);
        }
        FindObjectOfType<PlateSpawner>().plates.Remove(this);
        Destroy(gameObject);
    }
}
