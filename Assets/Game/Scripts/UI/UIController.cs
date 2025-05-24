using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField] private Canvas          gameCanvas;
	[SerializeField] private GameObject      winPopupPrefab;
	[SerializeField] private GameObject      losePopupPrefab;
	[SerializeField] private GameObject      tapToStart;
	private                  GameObject      activePopup;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI timerText;
	private                  Vector2         originalScale     =new Vector2(1f,1f);
	private                  float           minScaleMultiplier=1f;
	private                  float           maxScaleMultiplier=2f;


	public void SetLevelText(int currentLevel)
	{
		if(levelText!=null)
		{
			levelText.text=$"Level {currentLevel}";
		}
	}
	public void SetTimerText(float timeLeft)
	{
		if(timerText!=null)
		{
			timerText.text=timeLeft.ToString("0");
			if(timeLeft<=10f)
			{
				float currentMultiplier=Mathf.Lerp(minScaleMultiplier,maxScaleMultiplier,1f-(timeLeft/10f));
				Color currentColor     =Color.Lerp(Color.white,Color.red,1f-(timeLeft/10f));

				timerText.transform.localScale=originalScale*currentMultiplier;
				timerText.color               =currentColor;
			}
			else
			{
				timerText.transform.localScale=originalScale;
			}
		}
	}

	public void LevelWon()
	{
		if(activePopup!=null) Destroy(activePopup);
		HideHUD();
		activePopup=Instantiate(winPopupPrefab,gameCanvas.transform);
	}

	public void LevelFailed()
	{
		if(activePopup!=null) Destroy(activePopup);
		HideHUD();
		activePopup=Instantiate(losePopupPrefab,gameCanvas.transform);
	}

	public void HideHUD()
	{
		if(levelText!=null) levelText.enabled=false;
		if(timerText!=null) timerText.enabled=false;
	}

	public void RemoveTapToStart()
	{
		Game.Sound.PlaySound("bloop1");
		Destroy(tapToStart);
	}


	public void RestartLevel() { Game.Manager.StartGame(); }
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
