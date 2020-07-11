using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidPlacementDefaultLocation : MonoBehaviour
    //placeholder for location to put a sushi if the drop fails
{
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectsOfType<InvalidPlacementDefaultLocation>().Length>1)
        {
            Destroy(gameObject);
        }
    }
}
