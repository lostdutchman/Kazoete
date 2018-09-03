using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("high_score"))
        {
            PlayerPrefs.SetFloat("high_score", 6039);
        }
    }

    public void Mode(int mode)
    {
        PlayerPrefs.SetInt("game_mode", mode);
        SceneManager.LoadScene("Game");
    }

    public void LevelSelect(string level)
    {
        SceneManager.LoadScene(level);

    }
}
