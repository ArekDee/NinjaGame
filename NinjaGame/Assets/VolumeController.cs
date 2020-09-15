using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameInfoController.GetMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMusicVolume()
    {
        MusicController.ChangeMusicVolume(volumeSlider.value);
    }
    public void SaveOptionsAndExit()
    {
        GameInfoController.ChangeMusicVolume(volumeSlider.value);
        SceneManager.LoadScene(0);
    }
}
