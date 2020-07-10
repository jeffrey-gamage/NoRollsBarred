using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject gridCellPrefab;
    [SerializeField] float cellSpacing = 5;
    [SerializeField] int width = 9;
    [SerializeField] int height = 9;
    private GridCell[][] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridCell[width][];
        for(int i = 0; i< height;i++)
        {
            grid[i] = new GridCell[width];
            for(int j=0;j<height;j++)
            {
                grid[i][j] = Instantiate(gridCellPrefab, 
                    gameObject.transform.position + cellSpacing * (i * Vector3.up + j * Vector3.right),
                    Quaternion.identity).GetComponent<GridCell>();
            }
        }
    }
}
