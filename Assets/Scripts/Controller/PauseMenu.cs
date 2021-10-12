using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI[] TMPros;
    GameController gameController;
    int index; // 0 = resume, 1 = restart, 2 = back to menu

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        index = 0;
        setIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            switchIndex("up");
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            switchIndex("down");

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (index)
            {
                case 0:
                    gameController.Resume();
                    break;
                case 1:
                    gameController.Restart();
                    break;
                case 2:
                    gameController.BackToMenu();
                    break;
                default:
                    break;
            }
        }
    }

    void setIndex()
    {
        foreach(var t in TMPros)
        {
            t.fontStyle &= ~TMPro.FontStyles.Underline;
            t.fontStyle = TMPro.FontStyles.Bold;
        }

        TMPros[index].fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.Bold;
    }

    void switchIndex(string action)
    {
        switch (action)
        {
            case "up":
                index--;
                if (index < 0) index = 2;
                break;
            case "down":
                index = (index + 1) % 3;
                break;
            default:
                break;
        }
        setIndex();
    }
}
