using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    private float shutterSpeed = 1f;
    GameManager manager;
    GameObject conveyor;
    float bottomY;
    float topY;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent("GameManager") as GameManager;
        conveyor = GameObject.Find("Conveyor");
        bottomY = GameObject.Find("Main Camera").transform.position.y - Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).y + this.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        topY = GameObject.Find("Main Camera").transform.position.y + Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).y + this.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        this.transform.position = new Vector3(conveyor.transform.position.x - 0.3f, topY, transform.position.z);
        // this 0.3f is eyeballed, change later
    }
    // Update is called once per frame
    void Update()
    {
        // move at a constant rate toward the true shutter value, which changes according to GameManager updates
        //this.transform.position = new Vector3(transform.position.x, 20-(manager.shutterValue / 5f * shutterSpeed), transform.position.z); // this changes value instantly instead of slowly shuttering
        
        // we'll lerp it, even if it's a bit goofy.
        // how to calculate bottom of the screen???  I guess it'd be camera.y - sceneHeight/2
        this.transform.position = Vector3.Lerp(transform.position, new Vector3(conveyor.transform.position.x-0.1f, (bottomY)*manager.shutterValue/100f + topY*(1-manager.shutterValue/100f), transform.position.z), 0.05f);
    }
}
