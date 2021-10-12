using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI[] TMPros;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        index = 0;
        setIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            index = (index + 1) % 2;
            setIndex();
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0)
                StartGame();
            else if (index == 1)
                QuitGame();
        }
    }

    void setIndex()
    {
        foreach (var t in TMPros)
        {
            t.fontStyle &= ~TMPro.FontStyles.Underline;
            t.fontStyle = TMPro.FontStyles.Bold;
        }

        TMPros[index].fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.Bold;
    }

    void StartGame()
    {
        SceneManager.LoadScene("scenario");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
