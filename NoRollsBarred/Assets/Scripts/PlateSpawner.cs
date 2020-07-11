using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    private GameManager gameManager;
    private Grid grid;
    internal List<Plate> plates;
    [SerializeField] Vector2Int[] plateSpawnCoordinates;
    // Start is called before the first frame update

    private void Start()
    {
        plates = new List<Plate>();
        gameManager = FindObjectOfType<GameManager>();
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Vector2Int coords in plateSpawnCoordinates)
        {
            if(!PlateExistsAtCoordinates(coords))
            {
                SpawnPlateAtCoordinates(coords);
            }
        }
    }

    private bool PlateExistsAtCoordinates(Vector2Int coords)
    {
        foreach(Plate plate in plates)
        {
            if(plate.rootCoords==coords)
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnPlateAtCoordinates(Vector2Int coords)
    {
        GameObject plate = gameManager.GetNextPlate();
        Plate newPlate =Instantiate(plate, grid.cells[coords.y][coords.x].gameObject.transform.position, Quaternion.identity).GetComponent<Plate>();
        newPlate.rootCoords = coords;
        plates.Add(newPlate);
    }
}
