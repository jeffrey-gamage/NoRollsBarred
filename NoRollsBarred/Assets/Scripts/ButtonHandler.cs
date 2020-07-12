using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void StartGame()
    {
        // load the Game scene, or whichever scene we're using.
        SceneManager.LoadScene("Game");
    }

    public void ShowInstructions()
    {
        startupLoader s = GameObject.Find("Canvas").GetComponent(typeof(startupLoader)) as startupLoader;
        s.panel.SetActive(true);
    }
    public void HideInstructions()
    {
        startupLoader s = GameObject.Find("Canvas").GetComponent(typeof(startupLoader)) as startupLoader;
        s.panel.SetActive(false);
    }


}
