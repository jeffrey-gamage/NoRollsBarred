using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    GameManager manager;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent("GameManager") as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.transform.GetChild(0).GetComponent<Text>().text = "Level: " + manager.level.ToString();
        this.transform.GetChild(1).GetComponent<Text>().text = "Score: " + manager.score.ToString();
    }
}
