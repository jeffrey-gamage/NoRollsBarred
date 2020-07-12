using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResults : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score: " + GameResults.instance.score.ToString();
        levelText.text = "score: " + GameResults.instance.level.ToString();
        Destroy(GameResults.instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
