using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Game.Settings settings = Game.settings;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text LastScore;
    
    public void PlayGame(){SceneManager.LoadScene("SampleScene");}

    private void Start()
    {
        bestScore.text = $"Best score\n{settings.BestScore}";
        LastScore.text = Game.Score == 0 ? "" : $"Last\n{Game.Score}";
    }

    public void AudioOut()
    {
        if (Game.settings.SoundOn)
        {
            settings.SoundOn = false;
            File.WriteAllText(Application.streamingAssetsPath + "/settings.json", JsonUtility.ToJson(settings));
            AudioListener.volume = 0;
        }
        else
        {
            Game.settings.SoundOn = true;
            File.WriteAllText(Application.streamingAssetsPath + "/settings.json", JsonUtility.ToJson(settings));
            AudioListener.volume = 1;
        }
    }
    
    public void GoToURL()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
