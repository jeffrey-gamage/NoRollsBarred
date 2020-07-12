using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioClip[] musicList;
    public AudioClip[] sfx;

    private AudioSource musicPlayer;
    private AudioSource sfxPlayer;

    public void playMusic(int i)
    {
        musicPlayer.clip = musicList[i];
        musicPlayer.Play();
    }
    public void playSfx(int i)
    {
        // play the AudioClip at sfx[i]
        sfxPlayer.clip = sfx[i];
        sfxPlayer.Play();
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        musicPlayer = this.transform.GetChild(0).GetComponent<AudioSource>();
        sfxPlayer = this.transform.GetChild(1).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // check which music should be playing, and play it if it's not playing
        if (SceneManager.GetActiveScene().name == "GameOver") musicPlayer.volume = 0.25f;
        else musicPlayer.volume = 1f;
        if (!musicPlayer.isPlaying)
        {
            string name = SceneManager.GetActiveScene().name;
            if (name == "StartupScreen") musicPlayer.clip = musicList[0];
            else if (name == "smallTables") { musicPlayer.clip = musicList[1]; musicPlayer.volume = 1f; }
            else if (name == "GameOver") { musicPlayer.clip = musicList[1]; musicPlayer.volume = 0.25f; }
            musicPlayer.Play();
        }
        // sfx aren't played here, they're called in a separate function from GameManager
    }
}
