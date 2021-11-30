using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool IsSoundOn = true;
    
    public void PlayGame(){SceneManager.LoadScene("SampleScene");}
    
    public void AudioOut()
    {
        if (IsSoundOn)
        {
            IsSoundOn = false;
            AudioListener.volume = 0;
        }
        else
        {
            IsSoundOn = true;
            AudioListener.volume = 1;
        }
    }
    
    public void GoToURL()
    {
        Application.OpenURL("https://yandex.ru/images/search?text=��������%20���&from=tabbar");
    }
}
