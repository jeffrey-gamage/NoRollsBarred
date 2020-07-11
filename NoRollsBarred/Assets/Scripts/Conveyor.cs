using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    // in charge of rendering food in the correct spots and 
    public float conveyorSpeed = 1f; // how far pieces move on the belt per frame.
    public float timeBetweenPieces = 2.5f; // probably 3 seconds?
    // FOR NOW, whenever the Conveyor belt renders a piece of food, it removes it from the list and adds a new piece of food.
    private float timer = 0.0f;
    GameManager manager=null;

    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent("GameManager") as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // if it's time for a new piece, render one
        if (timer>=timeBetweenPieces)
        {
            timer = 0f;
<<<<<<< HEAD
            GameObject thing = Instantiate(manager.masterPieceList[manager.pieceList[0][0]], new Vector3(transform.localPosition.x,transform.localPosition.y+ GameObject.Find("Main Camera").transform.position.y + Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).y + 3, transform.localPosition.z+1), Quaternion.identity, this.transform);
            //thing.GetComponent<Sushi>().moving = true;
=======
            GameObject thing = Instantiate(manager.masterPieceList[manager.pieceList[0][0]], new Vector3(transform.localPosition.x,transform.localPosition.y+4,transform.localPosition.z+1), Quaternion.identity, this.transform);
            thing.GetComponent<Sushi>().onConveyor = true;
>>>>>>> origin/plateIntegration
            foreach (Transform child in thing.transform)
            {
                // change the color of the gridSquare to the appropriate color in pieceList[0][1]
                child.GetComponent<SpriteRenderer>().color = manager.colors[manager.pieceList[0][1]];
            }
            manager.pieceList.RemoveAt(0);
        }
        // move each piece of food on the belt down the belt.
        foreach (Transform child in this.transform)
        {
<<<<<<< HEAD
            //if (child.gameObject.GetComponent<Sushi>().moving) {
            if (true) { 
=======
            if (child.gameObject.GetComponent<Sushi>().onConveyor) {
>>>>>>> origin/plateIntegration
                child.Translate(Vector3.down * Time.deltaTime * conveyorSpeed);
                if (child.localPosition.y < GameObject.Find("Main Camera").transform.position.y - Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).y - 3) Destroy(child.gameObject);
            }
        }
    }
}
