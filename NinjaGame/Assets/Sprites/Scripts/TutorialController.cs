using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    int i = 1;
    bool oneJump = false;
    GameObject winPanel;
    GameObject tutorialPanel;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("CanvasPanels");
        if (canvas != null)
        {
            winPanel = canvas.transform.GetChild(2).gameObject;
            tutorialPanel = canvas.transform.GetChild(3).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartTutorial()
    {
        FindObjectOfType<GameController>().StartGame();
        tutorialPanel.SetActive(true);
    }
    public void JumpInTutorial()
    {
        if(oneJump == false)
        {
            tutorialPanel.SetActive(false);
            StartCoroutine("WaitAndWinTutorial");
            oneJump = true;
        }
        FindObjectOfType<GameController>().JumpOnClick();
        
    }
    IEnumerator WaitAndWinTutorial()
    {
        yield return new WaitForSeconds(2);
        WinTutorial();
    }

    public void WinTutorial()
    {
        Time.timeScale = 0;
        GameInfoController.ChangeStageLvl(1, 2);
        GameInfoController.ChangeCoinAmount(100);
        GameInfoController.ChangePowerAmount(1, 1);
        winPanel.SetActive(true);
    }
}
