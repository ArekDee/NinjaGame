using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelLockController : MonoBehaviour
{
    StageController stageController;
    public int stageNumber;
    public int lvlNumber;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        stageController = FindObjectOfType<StageController>();
        if(stageNumber == 1)
        {
            if(stageController.GetStage1Lvl() < lvlNumber)
            { 
                GetComponent<Button>().interactable = false;
            }
            if (stageController.GetStage1Lvl() > lvlNumber && lvlNumber == 1)
            {
                GetComponent<Button>().interactable = false;
            }
            if (stageController.GetStage1Lvl() == lvlNumber)
            {
                text.GetComponent<Animator>().enabled = true;
            }
        }
        else if(stageNumber == 2)
        {
            if (stageController.GetStage2Lvl() < lvlNumber)
            {
                GetComponent<Button>().interactable = false;
            }
            if (stageController.GetStage2Lvl() == lvlNumber)
            {
                text.GetComponent<Animator>().enabled = true;
            }
        }
        else if(stageNumber == 3)
        {
            if (stageController.GetStage3Lvl() < lvlNumber)
            {
                GetComponent<Button>().interactable = false;
            }
            if (stageController.GetStage3Lvl() == lvlNumber)
            {
                text.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
