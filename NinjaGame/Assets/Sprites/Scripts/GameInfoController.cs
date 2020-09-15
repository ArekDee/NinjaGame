using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameInfoController : MonoBehaviour
{
    public int checkpoint = 0;
    public bool isStartedFromCheckpoint = false;
    public static int loseCounter = 0;
    public static GameInfoController instance = null;
    const string COIN_AMOUNT_KEY = "coin";
    const string POWER_1_AMOUNT_KEY = "power1";
    const string POWER_2_AMOUNT_KEY = "power2";
    const string POWER_3_AMOUNT_KEY = "power3";
    const string STAGE_1_KEY = "stage1";
    const string STAGE_2_KEY = "stage2";
    const string STAGE_3_KEY = "stage3";
    const string MUSIC_VOLUME = "volume";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(COIN_AMOUNT_KEY))
        {
            PlayerPrefs.SetInt(COIN_AMOUNT_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(POWER_1_AMOUNT_KEY))
        {
            PlayerPrefs.SetInt(POWER_1_AMOUNT_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(POWER_2_AMOUNT_KEY))
        {
            PlayerPrefs.SetInt(POWER_2_AMOUNT_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(POWER_3_AMOUNT_KEY))
        {
            PlayerPrefs.SetInt(POWER_3_AMOUNT_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(STAGE_1_KEY))
        {
            PlayerPrefs.SetInt(STAGE_1_KEY, 1);
        }
        if (!PlayerPrefs.HasKey(STAGE_2_KEY))
        {
            PlayerPrefs.SetInt(STAGE_2_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(STAGE_3_KEY))
        {
            PlayerPrefs.SetInt(STAGE_3_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 0.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static int GetCoinAmount()
    {
        return PlayerPrefs.GetInt(COIN_AMOUNT_KEY);
    }
    public static void ChangeCoinAmount(int value)
    {
        PlayerPrefs.SetInt(COIN_AMOUNT_KEY, value);
    }
    public static int GetPowerAmount(int powerNumber)
    {
        if (powerNumber == 1)
        {
            return PlayerPrefs.GetInt(POWER_1_AMOUNT_KEY);
        }
        else if (powerNumber == 2)
        {
            return PlayerPrefs.GetInt(POWER_2_AMOUNT_KEY);
        }
        else
        {
            return PlayerPrefs.GetInt(POWER_3_AMOUNT_KEY);
        }
    }
    public static void ChangePowerAmount(int powerNumber, int value)
    {
        if (powerNumber == 1)
        {
            PlayerPrefs.SetInt(POWER_1_AMOUNT_KEY, value);
        }
        else if (powerNumber == 2)
        {
            PlayerPrefs.SetInt(POWER_2_AMOUNT_KEY, value);
        }
        else
        {
            PlayerPrefs.SetInt(POWER_3_AMOUNT_KEY, value);
        }
    }
    public static int GetStageLvl(int stageNumber)
    {
        if (stageNumber == 1)
        {
            return PlayerPrefs.GetInt(STAGE_1_KEY);
        }
        else if (stageNumber == 2)
        {
            return PlayerPrefs.GetInt(STAGE_2_KEY);
        }
        else
        {
            return PlayerPrefs.GetInt(STAGE_3_KEY);
        }
    }
    public static void ChangeStageLvl(int stageNumber, int value)
    {
        if (stageNumber == 1)
        {
            PlayerPrefs.SetInt(STAGE_1_KEY, value);
        }
        else if (stageNumber == 2)
        {
            PlayerPrefs.SetInt(STAGE_2_KEY, value);
        }
        else
        {
            PlayerPrefs.SetInt(STAGE_3_KEY, value);
        }
    }
    public static void AddLose()
    {
        loseCounter++;
        if(loseCounter >= 5)
        {
            FindObjectOfType<InitializeAdsScript>().ShowInterstitialAd();
            loseCounter = 0;
        }
    }
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME);
    }
    public static void ChangeMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
    }
}
