using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text bestScore;
    [SerializeField] private Text LastScore;
    
    public void PlayGame(){SceneManager.LoadScene("SampleScene");}

    private void Start()
    {
        bestScore.text = $"Best score\n0";
        LastScore.text = Game.Score == 0 ? "" : $"Last\n{Game.Score}";
    }

    public void AudioOut()
    {
        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }
    
    public void GoToURL()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
