using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Implement a high score system here?
	}

    public void Mode(int mode)
    {
        PlayerPrefs.SetInt("game_mode", mode);
        SceneManager.LoadScene("Game");
    }
}
