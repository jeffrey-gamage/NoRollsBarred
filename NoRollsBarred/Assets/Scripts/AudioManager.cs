using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioClip[] musicList;
    public AudioClip[] sfx;

    private AudioSource musicPlayer;
    private AudioSource sfxPlayer;

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
            //DontDestroyOnLoad(gameObject);
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
        if (!musicPlayer.isPlaying)
        {
            musicPlayer.clip = musicList[1];
            musicPlayer.Play();
        }
        // sfx aren't played here, they're called in a separate function from GameManager
    }
}
