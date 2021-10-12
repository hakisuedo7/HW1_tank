using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private Text ScoreText;
    private bool GameIsPause;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameIsPause = false;
        score = 0;
        RefreshScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPause = !GameIsPause;
        }

        if (GameIsPause)
            Pause();
        else
            Resume();
    }

    public void Pause()
    {
        GameIsPause = true;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        GameIsPause = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("scenario");
    }

    public void addScore(int sc)
    {
        score += sc;
        RefreshScore();
    }

    void RefreshScore()
    {
        ScoreText.text = "Score: " + score;
    }
}
