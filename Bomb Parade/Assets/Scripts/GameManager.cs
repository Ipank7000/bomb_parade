using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject pauseMenu;

    bool pause;

    int player1Score;
    int player2Score;

    float time;

    void Start () {
        player1Score = PlayerPrefs.GetInt("Player1Score");
        player2Score = PlayerPrefs.GetInt("Player2Score");
    }
	
	void Update () {

        if (pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BackToGame();
            }
            Time.timeScale = 0;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            Time.timeScale = 1;
          
        }
	}

    void CloseGame()
    {
        PlayerPrefs.DeleteKey("Player1Score");
        PlayerPrefs.DeleteKey("Player2Score");
    }

    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        pause = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pause = true;
    }

    public void Victory(string playerWin)
    {
        if (playerWin == "Player1")
        {
            PlayerPrefs.SetInt("Player1Score",++player1Score);
        }
        else
        {
            PlayerPrefs.SetInt("Player2Score",++player2Score);
        }
    }
}
