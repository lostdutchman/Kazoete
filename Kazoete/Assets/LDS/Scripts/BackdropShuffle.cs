using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackdropShuffle : MonoBehaviour {

    public Image image;
    public Sprite[] backdrops;

	// Use this for initialization
	void Start () {
        Change();
	}

    public void Change()
    {
        image.sprite = backdrops[Random.Range(0, backdrops.Length)];
    }
}
