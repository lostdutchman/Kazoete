using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShuffle : MonoBehaviour {

    //To keep one constant soundtrack through entire game.
    static MusicShuffle instance = null;

    public AudioClip[] myMusic;
    private AudioSource audioSource;
    [Tooltip("In seconds, 0 for no delay")]
    public float startDelay;


    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("master_volume"))
        {
            PlayerPrefs.SetFloat("master_volume", .5f);
        }
        ChangeVolume(PlayerPrefs.GetFloat("master_volume"));
    }
    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("master_volume", value);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= startDelay)
        {
            if (!audioSource.isPlaying)
                playRandomMusic();
        }
    }

    public void playRandomMusic()
    {
        audioSource.clip = myMusic[Random.Range(0, myMusic.Length)];
        audioSource.Play();
    }


}
