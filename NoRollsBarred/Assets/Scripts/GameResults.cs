using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResults : MonoBehaviour
{
    public int score;
    public int level;
    private GameManager manager;
    public static GameResults instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            manager = FindObjectOfType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = manager.score;
        level =(int) manager.level;
    }
}
