using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool GameIsPause;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameIsPause = false;
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
}
