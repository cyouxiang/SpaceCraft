using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombManage : MonoBehaviour {

    public Text bombText;
    public int bombCount;
    public static BombManage _instance;
    public GameObject bombSound;

	void Start () {
        _instance = this;
        bombCount = 0;
	}
	
	void Update () {
	    if ((Input.GetKeyDown(KeyCode.Space) && bombCount > 0) || (Input.touchCount >= 2 && bombCount > 0)) {
            UseBomb();
            bombSound.GetComponent<AudioSource>().Play();
        }
	}

    public void AddBomb () {
        bombCount++;
        bombText.text = "" + bombCount;
    }

    public void UseBomb () {
        bombCount--;
        bombText.text = "" + bombCount;
    }
}
