using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    GameObject winPanel;
    GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("CanvasPanels");
        if (canvas != null)
        {
            winPanel = canvas.transform.GetChild(2).gameObject;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameController>().SaveCoinAmount();
            if(FindObjectOfType<GameController>().stageNumber == 1)
            {
                //For demo!!!
                if(GameInfoController.GetStageLvl(1) == FindObjectOfType<GameController>().levelNumber)
                {
                    if(FindObjectOfType<GameController>().levelNumber == 4)
                    {
                        GameInfoController.ChangeStageLvl(2, 1);
                        GameInfoController.ChangeStageLvl(3, 1);
                    }
                    else
                    {
                        GameInfoController.ChangeStageLvl(1, FindObjectOfType<GameController>().levelNumber + 1);
                    }
                }
            }
            else if (FindObjectOfType<GameController>().stageNumber == 2)
            {
                if (GameInfoController.GetStageLvl(2) == FindObjectOfType<GameController>().levelNumber)
                {
                    //GameInfoController.ChangeStageLvl(2, FindObjectOfType<GameController>().levelNumber + 1);
                }
            }
            else if (FindObjectOfType<GameController>().stageNumber == 3)
            {
                if (GameInfoController.GetStageLvl(3) == FindObjectOfType<GameController>().levelNumber)
                {
                    //GameInfoController.ChangeStageLvl(3, FindObjectOfType<GameController>().levelNumber + 1);
                }
            }
            FindObjectOfType<GameInfoController>().checkpoint = 0;
            FindObjectOfType<GameInfoController>().isStartedFromCheckpoint = false;

            winPanel.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
