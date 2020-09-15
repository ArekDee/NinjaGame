using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    int coinAmount;
    public Text coinAmountText;
    public Text power1AmountText;
    public Text power2AmountText;
    public Text power3AmountText;
    int power1, power2, power3;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        power1 = GameInfoController.GetPowerAmount(1);
        power2 = GameInfoController.GetPowerAmount(2);
        power3 = GameInfoController.GetPowerAmount(3);
        coinAmount = GameInfoController.GetCoinAmount();
        coinAmountText.text = coinAmount.ToString();
        power1AmountText.text = power1.ToString();
        power2AmountText.text = power2.ToString();
        power3AmountText.text = power3.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateCoinAmount()
    {
        coinAmountText.text = coinAmount.ToString();
    }
    public void SubtractCoin(int value)
    {
        coinAmount -= value;
        UpdateCoinAmount();
    }
    public void AddPower(int powerNumber)
    {
        if (powerNumber == 1)
        {
            power1 += 1;
            power1AmountText.text = power1.ToString();
        }
        else if (powerNumber == 2)
        {
            power2 += 1;
            power2AmountText.text = power2.ToString();
        }
        else if (powerNumber == 3)
        {
            power3 += 1;
            power3AmountText.text = power3.ToString();
        }
    }

    public void SaveCoinAmount()
    {
        GameInfoController.ChangeCoinAmount(coinAmount);
    }
    public void SavePowerAmount()
    {
        GameInfoController.ChangePowerAmount(1, power1);
        GameInfoController.ChangePowerAmount(2, power2);
        GameInfoController.ChangePowerAmount(3, power3);
    }
    public void BuyPower(int powerNumber)
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position, MusicController.GetMusicVolume() <= 0.85f? MusicController.GetMusicVolume() + 0.15f: MusicController.GetMusicVolume());
        if(powerNumber == 1)
        {
            if(coinAmount >= 50)
            {
                SubtractCoin(50);
                AddPower(powerNumber);
            }
        }
        else if(powerNumber == 2)
        {
            if (coinAmount >= 50)
            {
                SubtractCoin(50);
                AddPower(powerNumber);
            }
        }
        else if(powerNumber == 3)
        {
            if (coinAmount >= 50)
            {
                SubtractCoin(50);
                AddPower(powerNumber);
            }
        }
        
    }
    public void SaveAndExit()
    {
        SaveCoinAmount();
        SavePowerAmount();
        FindObjectOfType<LevelLoader>().LoadChooseSelectScene();
    }
    public void AddCoins(int amount)
    {
        coinAmount += amount;
        UpdateCoinAmount();
    }
}
