using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    GameManager manager;
    private float timer;
    private float messageHangTime = 2f;
    // Start is called before the first frame update
    public void PieceDestroyed()
    {
        this.transform.GetChild(5).GetComponent<Text>().enabled = true;
        timer = messageHangTime;

    }
    public void PlatePassed(bool color, bool spill)
    {
        this.transform.GetChild(2).GetComponent<Text>().enabled = true;
        if (color)
            this.transform.GetChild(3).GetComponent<Text>().enabled = true;
        if (spill)
            this.transform.GetChild(4).GetComponent<Text>().enabled = true;
        timer = messageHangTime;
    }
    void Start()
    {
        this.transform.GetChild(2).GetComponent<Text>().enabled = false;
        this.transform.GetChild(3).GetComponent<Text>().enabled = false;
        this.transform.GetChild(4).GetComponent<Text>().enabled = false;
        this.transform.GetChild(5).GetComponent<Text>().enabled = false;
        manager = FindObjectOfType<GameManager>().GetComponent("GameManager") as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            this.transform.GetChild(2).GetComponent<Text>().enabled = false;
            this.transform.GetChild(3).GetComponent<Text>().enabled = false;
            this.transform.GetChild(4).GetComponent<Text>().enabled = false;
            this.transform.GetChild(5).GetComponent<Text>().enabled = false;
        }
        this.transform.GetChild(0).GetComponent<Text>().text = "Level: " + manager.level.ToString();
        this.transform.GetChild(1).GetComponent<Text>().text = "Score: " + manager.score.ToString();
    }
}
