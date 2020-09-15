using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public List<GameObject> levelCanvas;
    public List<Button> stageButtons;
    public List<Image> stageBg;
    GameObject activePanel;
    int stage1Lvl, stage2Lvl, stage3Lvl;
    // Start is called before the first frame update
    void Start()
    {
        activePanel = levelCanvas[0].transform.GetChild(0).gameObject;
        stage1Lvl = GameInfoController.GetStageLvl(1);
        stage2Lvl = GameInfoController.GetStageLvl(2);
        stage3Lvl = GameInfoController.GetStageLvl(3);
        if(stage2Lvl == 0)
        {
            stageButtons[0].interactable = false;
            stageBg[0].color = Color.gray;
        }
        if (stage3Lvl == 0)
        {
            stageButtons[1].interactable = false;
            stageBg[1].color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStage1Button()
    {
        activePanel.SetActive(false);
        activePanel = levelCanvas[1].transform.GetChild(0).gameObject;
        activePanel.SetActive(true);
    }
    public void ClickStage2Button()
    {
        activePanel.SetActive(false);
        activePanel = levelCanvas[2].transform.GetChild(0).gameObject;
        activePanel.SetActive(true);
    }
    public void ClickStage3Button()
    {
        activePanel.SetActive(false);
        activePanel = levelCanvas[3].transform.GetChild(0).gameObject;
        activePanel.SetActive(true);
    }
    public void ReturnToStartPanel()
    {
        activePanel.SetActive(false);
        activePanel = levelCanvas[0].transform.GetChild(0).gameObject;
        activePanel.SetActive(true);
    }
    public int GetStage1Lvl()
    {
        return stage1Lvl;
    }
    public int GetStage2Lvl()
    {
        return stage2Lvl;
    }
    public int GetStage3Lvl()
    {
        return stage3Lvl;
    }

}
