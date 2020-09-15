using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    GameObject losePanel;
    GameObject canvas;
    CheckpointController checkpointController;
    GameInfoController gameInfoController;
    PowersController powersController;
    int checkpoint = 0;
    private void Start()
    {
        canvas = GameObject.Find("CanvasPanels");
        if (canvas != null)
        {
            losePanel = canvas.transform.GetChild(1).gameObject;
        }
        checkpointController = FindObjectOfType<CheckpointController>();
        gameInfoController = FindObjectOfType<GameInfoController>();
        powersController = FindObjectOfType<PowersController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody" && !powersController.GetNoShuriken())
        {
            if (gameInfoController.checkpoint < checkpointController.checkpoint)
            {
                gameInfoController.checkpoint = checkpointController.checkpoint > 0 ? checkpointController.checkpoint / 2 : 0;
            }
            Debug.Log("checkpoint:" + gameInfoController.checkpoint);
            FindObjectOfType<GameController>().StartFromCheckpointButtonController();
            losePanel.SetActive(true);
            Time.timeScale = 0;
            GameInfoController.AddLose();
            FindObjectOfType<GameController>().SaveCoinAmount();
        }
    }
}
