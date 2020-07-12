using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject gridCellPrefab;
    [SerializeField] float cellSpacing = 5;
    [SerializeField] int width = 9;
    [SerializeField] int height = 9;
    internal GridCell[][] cells;
    // Start is called before the first frame update
    public int GetWidth() { return width; }
    public int GetHeight() { return height; }
    void Start()
    {
        cells = new GridCell[height][];
        for(int i = 0; i< height;i++)
        {
            cells[i] = new GridCell[width];
            for(int j=0;j<width;j++)
            {
                cells[i][j] = Instantiate(gridCellPrefab, 
                    gameObject.transform.position + cellSpacing * (i * Vector3.up + j * Vector3.right),
                    Quaternion.identity).GetComponent<GridCell>();
            }
        }
    }
}
