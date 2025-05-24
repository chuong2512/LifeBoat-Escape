using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject resetButton;

    private void Start()
    {
        SetLevelText();
        Game.Sound.PlayBGM("menubgm");
    }

    private void SetLevelText()
    {
        int currentLevel = Game.Manager.CurrentLevel;
        buttonText.text = Game.Manager.DoesLevelExist(currentLevel) ? "Level " + currentLevel.ToString() : "Completed!";
        if (currentLevel > 1){
            resetButton.SetActive(true);}
        else resetButton.SetActive(false);
    }

    public void LevelButtonClicked()
    {
        Game.Manager.StartGame();
    }

    public void EditorButtonClicked()
    {
        Game.Manager.OpenLevelEditor();
    }

    public void ResetButtonClicked()
    {
        Game.Manager.ResetProgress();
        SetLevelText();
    }

    public void LogoThud() {Game.Sound.PlaySound("thud");}
    public void ButtonPop() { Game.Sound.PlaySound("pop");}
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
