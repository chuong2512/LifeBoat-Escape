using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private const string LEVEL_KEY = "CurrentLevel";
    public int CurrentLevel => PlayerPrefs.GetInt(LEVEL_KEY, 1);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        if (!DoesLevelExist(CurrentLevel))
        {
            OpenMainMenu();
            return;
        }
        Game.Sound.PlayLevelBGM();
        SceneManager.LoadScene("Game/Scenes/Gameplay");
    }

    public bool DoesLevelExist(int levelNumber)
    {
        string levelPath = $"Levels/level_{levelNumber}";
        var levelAsset = Resources.Load<TextAsset>(levelPath);
        return levelAsset != null;
    }

    public void OpenLevelEditor()
    {
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Game/Scenes/Start");
    }

    public void CompleteLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, levelNumber + 1);
        PlayerPrefs.Save();
    }

    public void ResetProgress()
    {
        CompleteLevel(0);
    }
}

public static class Game
{
    public static GameManager Manager => GameManager.Instance;
    public static SoundController Sound => SoundController.Instance;
}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
