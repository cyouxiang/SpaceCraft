using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState {
    Running,
    Pause
}

public class GameManager : MonoBehaviour {
    public GameState gameState = GameState.Running;

    public static GameManager _instance;
    public int playerScore = 0;
    public Text scoreUI;

    void Awake () {
        _instance = this;
    }

	// Update is called once per frame
	void Update () {
        scoreUI.text = "Score:" + playerScore;
	}

    public void TransformGameState () {
        if (gameState == GameState.Running) {
            GamePause();
        } else if (gameState == GameState.Pause) {
            ContinueGame();
        }
    }

    public void GamePause () {
        Time.timeScale = 0;
        gameState = GameState.Pause;
    }

    public void ContinueGame () {
        Time.timeScale = 1;
        gameState = GameState.Running;
    }
}
