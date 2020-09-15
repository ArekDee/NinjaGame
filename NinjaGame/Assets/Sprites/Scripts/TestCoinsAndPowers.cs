using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoinsAndPowers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInfoController.ChangePowerAmount(1, 50);
        GameInfoController.ChangePowerAmount(2, 50);
        GameInfoController.ChangePowerAmount(3, 50);
        GameInfoController.ChangeCoinAmount(500);
        GameInfoController.ChangeStageLvl(1, 1);
        GameInfoController.ChangeStageLvl(2, 0);
        GameInfoController.ChangeStageLvl(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
