using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private float plateValue = 10f; private float sameColorMulti = 2.5f; private float noSpillMulti = 3f;
    public Vector2Int rootCoords;
    private List<GridCell> gridCells;
    [HideInInspector] GameManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent("GameManager") as GameManager;
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
        CalculateScore();
        manager.shutterValue -= plateValue;
        ClearPlate();
    }

    private void ClearPlate()
    {
        foreach (GridCell cell in gridCells)
        {
            cell.SetPlate(null);
        }
        FindObjectOfType<PlateSpawner>().plates.Remove(this);
        Destroy(gameObject);
    }

    private void CalculateScore()
    {
        bool[] hasColor = new bool[3]; // this'll break if we add more than 3 colors.
        hasColor[0] = false; hasColor[1] = false; hasColor[2] = false;
        bool noSpill = true;
        foreach (Sushi sushi in GetComponentsInChildren<Sushi>())
        {
            for (int i = 0; i < manager.colors.Count; i++)
            {
                if (sushi.col == manager.colors[i]) hasColor[i] = true;
            }
            // check each piece's sushiCells to see if it's on the plate.
            Grid grid = FindObjectOfType<Grid>();
            while (noSpill)
            {
                for (int i = 0; i < grid.GetHeight() && noSpill; i++)
                {
                    for (int j = 0; j < grid.GetWidth() && noSpill; j++)
                    {
                        if (grid.cells[i][j].sushiInCell == sushi && !gridCells.Contains(grid.cells[i][j])) noSpill = false;
                    }
                }
                break;
            }
        }
        float toAdd = plateValue;
        if (noSpill) plateValue *= noSpillMulti;
        if ((hasColor[0] == false && hasColor[1] == false) || (hasColor[0] == false && hasColor[2] == false) || (hasColor[1] == false && hasColor[2] == false)) plateValue *= sameColorMulti;
    }
}
