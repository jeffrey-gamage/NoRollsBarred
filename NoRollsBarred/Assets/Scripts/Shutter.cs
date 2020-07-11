using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    private float shutterSpeed = 0.1f;
    GameManager manager;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent("GameManager") as GameManager;
    }
    // Update is called once per frame
    void Update()
    {
        // move at a constant rate toward the true shutter value, which changes according to GameManager updates
        this.transform.position = new Vector3(transform.position.x, 20-(manager.shutterValue / 5f), transform.position.z); // this changes value instantly instead of slowly shuttering
    }
}
