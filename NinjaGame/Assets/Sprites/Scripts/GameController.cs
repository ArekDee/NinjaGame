using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class GameController : MonoBehaviour
{
    public int stageNumber;
    public int levelNumber;
    public Player player;
    public bool isGameStarted;
    GameObject startPanel;
    public Slider gameSlider;
    public Text coinAmountText;

    GameInfoController gameInfoController;
    List<CheckpointController> Checkpoints;
    public Grid grid;
    public GameObject autoPlayObjects;

    public GameObject winBorder;
    public GameObject items;
    public Button fromCheckpointButton;
    float pathLength;
    int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        startPanel = GameObject.Find("CanvasPanels").transform.GetChild(0).gameObject;
        isGameStarted = false;
        Time.timeScale = 0;
        pathLength = System.Math.Abs(winBorder.transform.position.x - player.transform.position.x);
        coinAmount = GameInfoController.GetCoinAmount();
        gameInfoController = FindObjectOfType<GameInfoController>();
        coinAmountText.text = coinAmount.ToString();
        Checkpoints = FindObjectsOfType<CheckpointController>().ToList();
        MusicController.PlayGameMusic();
        if (gameInfoController.isStartedFromCheckpoint)
            StartFromCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliderValue();
        UpdateCoinAmount();
    }

    public void StartGame()
    {
        isGameStarted = true;
        player.myAnimator.SetBool("Run", true);
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }
    void UpdateSliderValue()
    {
        gameSlider.value = 1 - (System.Math.Abs(winBorder.transform.position.x - player.transform.position.x) / pathLength);
    }
    public void JumpOnClick()
    {
        if (player.grounded)
        {
            player.myRigidbody2D.velocity = new Vector3(0, 0, 0);
            player.myRigidbody2D.gravityScale = player.myRigidbody2D.gravityScale * -1;
            if (player.myRigidbody2D.gravityScale > 0)
                player.myRigidbody2D.AddForce(Vector3.down * player.jumpForce, ForceMode2D.Impulse);
            else
                player.myRigidbody2D.AddForce(Vector3.up * player.jumpForce, ForceMode2D.Impulse);
            player.myAnimator.SetTrigger("Jump");
        }
    }
    void UpdateCoinAmount()
    {
        coinAmountText.text = coinAmount.ToString();
    }
    public void AddCoin(int value)
    {
        coinAmount += value;
    }
    public void RemoveCoin(int value)
    {
        coinAmount -= value;
    }
    public int GetCoinAmount()
    {
        return coinAmount;
    }
    public void SaveCoinAmount()
    {
        GameInfoController.ChangeCoinAmount(coinAmount);
    }
    public void StartFromCheckpoint()
    {
        CheckpointController checkpointController = Checkpoints[gameInfoController.checkpoint - 1];
        float move = checkpointController.transform.position.x - player.transform.position.y;
        grid.transform.position = new Vector3(grid.transform.position.x - move, grid.transform.position.y, grid.transform.position.z);
        autoPlayObjects.transform.position = new Vector3(autoPlayObjects.transform.position.x - move, autoPlayObjects.transform.position.y, autoPlayObjects.transform.position.z);
        winBorder.transform.position = new Vector3(winBorder.transform.position.x - move, winBorder.transform.position.y, winBorder.transform.position.z);
        items.transform.position = new Vector3(items.transform.position.x - move, items.transform.position.y, items.transform.position.z);
        foreach (CheckpointController ckpc in Checkpoints)
        {
            ckpc.transform.position = new Vector3(ckpc.transform.position.x - move, ckpc.transform.position.y, ckpc.transform.position.z);
        }
    }
    public void StartFromCheckpointButtonController()
    {
        if (gameInfoController.checkpoint <= 0)
        {
            fromCheckpointButton.interactable = false;
        }
        else
        {
            fromCheckpointButton.interactable = true;
        }
    }
}
