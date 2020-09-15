using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentScene;
    public AudioClip sound;
    string scene;
    private void Start()
    {
        //Time.timeScale = 1;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
    public void LoadPrevioustScene()
    {
        SceneManager.LoadScene(currentScene - 1);
    }
    public void LoadChooseSelectScene()
    {
        SceneManager.LoadScene("ChooseMenu");
    }
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("ChooseStageMenu");
    }
    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void LoadStage1Scene()
    {
        SceneManager.LoadScene("ChooseLevelOnStage1");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void LoadLevelScene(string scene)
    {
        this.scene = scene;
        //MusicController.StopMusic();
        StartCoroutine("SoundBeforeLevelCorutine");
    }
    IEnumerator SoundBeforeLevelCorutine()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position,MusicController.GetMusicVolume() <= 0.75f? MusicController.GetMusicVolume() + 0.15f: MusicController.GetMusicVolume());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
    public void LoadCurrentScene()
    {
        FindObjectOfType<GameInfoController>().isStartedFromCheckpoint = false;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadCurrentSceneFromCheckpoint()
    {
        if(FindObjectOfType<GameController>().GetCoinAmount() >= 10)
        {
            FindObjectOfType<GameController>().RemoveCoin(10);
            FindObjectOfType<GameController>().SaveCoinAmount();
            FindObjectOfType<GameInfoController>().isStartedFromCheckpoint = true;
            SceneManager.LoadScene(currentScene);
        }
    }
    public void LoadMainMenuScene()
    {
        Time.timeScale = 1;
        MusicController.PlayMenuMusic();
        FindObjectOfType<GameInfoController>().isStartedFromCheckpoint = false;
        SceneManager.LoadScene(0);

    }

}
