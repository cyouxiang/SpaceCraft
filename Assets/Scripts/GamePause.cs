﻿using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickButton () {
        GameManager._instance.TransformGameState();
    }

    public void QuitGame () {
        print("QuitGame");
        Application.Quit();
    }

    //public void ButtonClickSound () {
    //    GetComponent<AudioSource>().Play();
    //}
}
